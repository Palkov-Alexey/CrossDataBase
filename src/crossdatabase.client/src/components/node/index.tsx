import React, { Component, createRef } from 'react';
import { computeOutOffsetByIndex, computeInOffsetByIndex } from './util';
import Spline from './spline';
import Node from './node';
import SVGComponent from './SVGComponent';
import NodeStore from './store/NodeStore';
import { ConnectionPoint } from './types/NodeType';
import { Position } from './types/Position';
import { observer } from 'mobx-react';
import ContextMenu from './components/contextMenu';

interface IState {
    source: any[];
    dragging: boolean;
    mousePos: Position;
    isClicked: boolean;
}

@observer
class index extends Component<any,IState> {
    store: NodeStore;
    ref!: any;
    isNodeSelected: boolean = false;
    menuPos = {
        top: 0,
        left: 0
    }

    constructor(props: any) {
        super(props);

        this.store = new NodeStore();

        this.state = {
            source: [],
            dragging: false,
            mousePos: { x: 0, y: 0 },
            isClicked: false
        }

        this.ref = createRef()

        this.onMouseMove = this.onMouseMove.bind(this);
        this.onMouseUp = this.onMouseUp.bind(this);

        this.handleClick = this.handleClick.bind(this);
    }

    handleClick() {
        console.log(`LC`);
        this.setClicked(false);
    }

    async componentDidMount() {
        await this.store.getData();
        document.addEventListener('mousemove', this.onMouseMove);
        document.addEventListener('mouseup', this.onMouseUp);
        document.addEventListener(`click`, this.handleClick);
    }

    componentWillUnmount() {
        document.removeEventListener('mousemove', this.onMouseMove);
        document.removeEventListener('mouseup', this.onMouseUp);
        document.removeEventListener(`click`, this.handleClick);
    }

    // componentWillReceiveProps(nextProps: NodeStore) {
    //     this.store.data = nextProps.data;
    //     //this.setState({ data: nextProps.data });
    // }

    onMouseUp(e: any) {
        this.setState({ dragging: false });
    }

    onMouseMove(e: any) {
        e.stopPropagation();
        e.preventDefault();
        const svg = this.ref.current.ref.current;

        //Get svg element position to substract offset top and left 
        const svgRect = svg.getBoundingClientRect();

        this.setState({
            mousePos: {
                x: e.pageX - svgRect.left,
                y: e.pageY - svgRect.top
            }
        });
    }

    handleStartConnector(nid: number, outputIndex: number) {
        this.setState({ dragging: true, source: [nid, outputIndex] });
    }

    handleCompleteConnector(nid: number, inputIndex: number) {
        if (this.state.dragging) {
            let fromNode = this.store.getNodebyId(this.state.source[0]);
            let fromPinName = fromNode.fields.outputs[this.state.source[1]].name;
            let toNode = this.store.getNodebyId(nid);
            let toPinName = toNode.fields.inputs[inputIndex].name;

            this.store.onNewConnector(fromNode.id, fromPinName, toNode.id, toPinName);
        }
        this.setState({ dragging: false });
    }

    computePinIndexfromLabel(pins: ConnectionPoint[], pinLabel: string) {
        return pins.findIndex(p => p.name === pinLabel);
    }

    setClicked(isClicked: boolean) {
        if (this.isNodeSelected) return;
        this.setState({ isClicked: isClicked });
    }

    setMenuPos(x: number, y: number) {
        this.menuPos.top = y;
        this.menuPos.left = x;
    }

    handleNodeSelect(nid: any) {
        this.isNodeSelected = true;
        this.handleClick();
    }

    handleNodeDeselect(nid: any) {
        this.isNodeSelected = false;
        this.handleClick();
    }

    render() {
        var { isLoading } = this.store;
        var { isClicked } = this.state;

        if (isLoading) {
            return <div /*className={style.emptyPage}><Loader width={150} className={style.loader}*/ />;
        }

        let { nodes, connectors } = this.store.data;
        let { mousePos, dragging } = this.state;

        let i = 0;
        let newConnector!: React.JSX.Element;

        if (dragging) {
            let sourceNode = this.store.getNodebyId(this.state.source[0]);
            let connectorStart = computeOutOffsetByIndex(sourceNode.posX, sourceNode.posY, this.state.source[1]);
            let connectorEnd = { x: this.state.mousePos.x, y: this.state.mousePos.y };

            newConnector = <Spline
                start={connectorStart}
                end={connectorEnd}
                mousePos={{
                    x: 0,
                    y: 0
                }} onRemove={function (...args: any[]) {
                    throw new Error('Function not implemented.');
                }} />
        }

        let splineIndex = 0;

        return (
            <div className={dragging ? 'dragging' : ''}
                onContextMenu={(e) => {
                    e.preventDefault();
                    this.setClicked(true);
                    this.setMenuPos(e.pageX, e.pageY);
                }} >
                {isClicked && (
                    <ContextMenu isNode={false} top={this.menuPos.top} left={this.menuPos.left} onMouseLeave={() => this.handleClick()} />
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

                        onNodeSelect={(nid) => { this.handleNodeSelect(nid) }}
                        onNodeDeselect={(nid) => { this.handleNodeDeselect(nid) }}
                    />
                })}

                {/* render our connectors */}

                <SVGComponent height="100%" width="100%" ref={this.ref} >

                    {connectors.map((connector) => {
                        let fromNode = this.store.getNodebyId(connector.fromNode);
                        let toNode = this.store.getNodebyId(connector.toNode);

                        let splinestart = computeOutOffsetByIndex(fromNode.posX, fromNode.posY, this.computePinIndexfromLabel(fromNode.fields.outputs, connector.from));
                        let splineend = computeInOffsetByIndex(toNode.posX, toNode.posY, this.computePinIndexfromLabel(toNode.fields.inputs, connector.to));

                        return <Spline
                            start={splinestart}
                            end={splineend}
                            key={splineIndex++}
                            mousePos={mousePos}
                            onRemove={() => { this.store.onRemoveConnector(connector) }}
                        />

                    })}

                    {/* this is our new connector that only appears on dragging */}
                    {newConnector}

                </SVGComponent>
            </div>
        );
    }


}

export default index;