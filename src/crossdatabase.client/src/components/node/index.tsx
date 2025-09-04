import ContextMenu from '@common/contextMenu';
import { observer } from 'mobx-react';
import { Component, createRef, ReactNode, RefObject } from 'react';
import Node from './components/node/node';
import Spline from './components/svg/component/spline/spline';
import SVGComponent from './components/svg/SVGComponent';
import { Position } from './models/Position';
import NodeStore from './store/NodeStore';
import { computeOutOffsetByIndex, computeInOffsetByIndex } from './util';

interface IState {
    source: [ nid: number, outputIndex: number ];
    dragging: boolean;
    mousePos: Position;
    isClicked: boolean;
}

@observer
class index extends Component<object, IState> {
    store: NodeStore;

    ref: RefObject<SVGComponent>;

    isNodeSelected: boolean = false;

    menuPos = {
        top: 0,
        left: 0
    };

    constructor(props: object) {
        super(props);

        this.store = new NodeStore();

        this.state = {
            source: [0, 0],
            dragging: false,
            mousePos: { x: 0, y: 0 },
            isClicked: false
        };

        this.ref = createRef();

        this.onMouseMove = this.onMouseMove.bind(this);
        this.onMouseUp = this.onMouseUp.bind(this);

        this.handleClick = this.handleClick.bind(this);
    }

    handleClick(): void {
        this.setClicked(false);
    }

    async componentDidMount(): Promise<void> {
        await this.store.getData();
        document.addEventListener(`mousemove`, this.onMouseMove);
        document.addEventListener(`mouseup`, this.onMouseUp);
        document.addEventListener(`click`, this.handleClick);
    }

    componentWillUnmount(): void {
        document.removeEventListener(`mousemove`, this.onMouseMove);
        document.removeEventListener(`mouseup`, this.onMouseUp);
        document.removeEventListener(`click`, this.handleClick);
    }

    onMouseUp(e: MouseEvent): void {
        this.setState({ dragging: false });
    }

    onMouseMove(e: MouseEvent): void {
        e.stopPropagation();
        e.preventDefault();
        const svg = this.ref.current?.ref.current;

        //Get svg element position to substract offset top and left 
        const svgRect = svg?.getBoundingClientRect();

        this.setState({
            mousePos: {
                x: e.pageX - (svgRect?.left ?? 0),
                y: e.pageY - (svgRect?.top ?? 0)
            }
        });
    }

    handleStartConnector(nid: number, outputIndex: number): void {
        this.setState({ dragging: true, source: [nid, outputIndex] });
    }

    handleCompleteConnector(nid: number, inputIndex: number): void {
        if (this.state.dragging) {
            const fromNode = this.store.getNodebyId(this.state.source[0]);
            const fromPinName = fromNode.fields.outputs[this.state.source[1]];
            const toNode = this.store.getNodebyId(nid);
            const toPinName = toNode.fields.inputs[inputIndex];

            this.store.onNewConnector(fromNode.id, fromPinName, toNode.id, toPinName).then();
        }

        this.setState({ dragging: false });
    }

    computePinIndexfromLabel(pins: string[], pinLabel: string): number {
        return pins.findIndex(p => p === pinLabel);
    }

    setClicked(isClicked: boolean): void {
        if (this.isNodeSelected) return;

        this.setState({ isClicked: isClicked });
    }

    setMenuPos(x: number, y: number): void {
        this.menuPos.top = y;
        this.menuPos.left = x;
    }

    handleNodeSelect(nid: number): void {
        this.isNodeSelected = true;
        this.handleClick();
    }

    handleNodeDeselect(nid: number): void {
        this.isNodeSelected = false;
        this.handleClick();
    }

    onRemoveNode(nid: number): void {
        this.store.onRemoveNode(nid);
    }

    render(): ReactNode {
        const { isLoading, menuItems } = this.store;
        const { isClicked } = this.state;

        if (isLoading) {
            return <div /*className={style.emptyPage}><Loader width={150} className={style.loader}*/ />;
        }

        const { nodes, connectors } = this.store.data;
        const { mousePos, dragging } = this.state;

        let i = 0;
        let newConnector: ReactNode;

        if (dragging) {
            const sourceNode = this.store.getNodebyId(this.state.source[0]);
            const connectorStart = computeOutOffsetByIndex(sourceNode.posX, sourceNode.posY, this.state.source[1]);
            const connectorEnd = { x: this.state.mousePos.x, y: this.state.mousePos.y };

            newConnector = <Spline
                start={connectorStart}
                end={connectorEnd}
                mousePos={{
                    x: 0,
                    y: 0
                }} onRemove={function () {
                    throw new Error(`Function not implemented.`);
                }} />;
        }

        let splineIndex = 0;

        return (
            <div className={dragging ? `dragging` : ``}
                onContextMenu={(e) => {
                    e.preventDefault();
                    this.setClicked(true);
                    this.setMenuPos(e.pageX, e.pageY);
                }} >
                {isClicked && (
                    <ContextMenu
                        top={this.menuPos.top}
                        left={this.menuPos.left}
                        onMouseLeave={() => this.handleClick()}
                        items={menuItems}
                    />
                )}
                {nodes.map((node) => {
                    return <Node
                        index={i++}
                        nid={node.id}
                        title={node.name}
                        inputs={node.fields.inputs}
                        outputs={node.fields.outputs}
                        pos={{ x: node.posX, y: node.posY }}
                        key={node.id}

                        //onNodeStart={(nid) => this.handleNodeStart(nid)}
                        onNodeStop={(index: number, pos: Position) => this.store.onNodeStop(index, pos)}
                        onNodeMove={(index: number, pos: Position) => this.store.onNodeMove(index, pos)}

                        onStartConnector={(nid: number, outputIndex: number) => this.handleStartConnector(nid, outputIndex)}
                        onCompleteConnector={(nid: number, inputIndex: number) => this.handleCompleteConnector(nid, inputIndex)}

                        onNodeSelect={() => this.handleNodeSelect(node.id)}
                        onNodeDeselect={() => this.handleNodeDeselect(node.id)}

                        onRemoveNode={() => this.onRemoveNode(node.id)}

                        type={node.type}
                    />;
                })}

                {/* render our connectors */}

                <SVGComponent height="100%" width="100%" ref={this.ref} >

                    {connectors.map((connector) => {
                        const fromNode = this.store.getNodebyId(connector.fromNode);
                        const toNode = this.store.getNodebyId(connector.toNode);

                        const splineStart = computeOutOffsetByIndex(fromNode.posX, fromNode.posY,
                            this.computePinIndexfromLabel(fromNode.fields.outputs, connector.from));
                        const splineEnd = computeInOffsetByIndex(toNode.posX, toNode.posY,
                            this.computePinIndexfromLabel(toNode.fields.inputs, connector.to));

                        return <Spline
                            start={splineStart}
                            end={splineEnd}
                            key={splineIndex++}
                            mousePos={mousePos}
                            onRemove={() => { this.store.onRemoveConnector(connector); }}
                        />;
                    })}

                    {/* this is our new connector that only appears on dragging */}
                    {newConnector}

                </SVGComponent>
            </div>
        );
    }
}

export default index;
