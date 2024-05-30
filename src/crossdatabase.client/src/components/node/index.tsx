import React, { Component, createRef } from 'react';
import { computeOutOffsetByIndex, computeInOffsetByIndex } from './util';
import Spline from './spline';
import Node from './node';
import SVGComponent from './SVGComponent';
import NodeStore from './store/NodeStore';
import { ConnectionPoint } from './types/NodeType';
import { Position } from './types/Position';
import { observer } from 'mobx-react';

interface IState {
    source: any[];
    dragging: boolean;
    mousePos: Position
}

@observer
class index extends Component<any, IState> {
    store: NodeStore;
    ref!: any

    constructor(props: any) {
        super(props);

        this.store = new NodeStore();

        this.state = {
            source: [],
            dragging: false,
            mousePos: { x: 0, y: 0 }
        }

        this.ref = createRef()

        this.onMouseMove = this.onMouseMove.bind(this);
        this.onMouseUp = this.onMouseUp.bind(this);
    }

    async componentDidMount() {
        await this.store.getData();
        document.addEventListener('mousemove', this.onMouseMove);
        document.addEventListener('mouseup', this.onMouseUp);
    }

    componentWillUnmount() {
        document.removeEventListener('mousemove', this.onMouseMove);
        document.removeEventListener('mouseup', this.onMouseUp);
    }

    // componentWillReceiveProps(nextProps: NodeStore) {
    //     this.store.data = nextProps.data;
    //     //this.setState({ data: nextProps.data });
    // }

    onMouseUp(e) {
        this.setState({ dragging: false, });
    }

    onMouseMove(e) {
        e.stopPropagation();
        e.preventDefault();
        console.log(this.ref.current)
        const svg= this.ref.current.ref.current;
        console.log(svg)

        //Get svg element position to substract offset top and left 
        const svgRect = svg.getBoundingClientRect();

        this.setState({
            mousePos: {
                x: e.pageX - svgRect.left,
                y: e.pageY - svgRect.top
            }
        });
    }

    handleStartConnector(nid: number, outputIndex: number){
        this.setState({dragging: true, source:[nid, outputIndex]});
    }

    handleCompleteConnector(nid: number, inputIndex: number) {
        if (this.state.dragging) {
            console.log(this.state.source)

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

    render() {
        var {isLoading} = this.store;
        if(isLoading){
            return <div /*className={style.emptyPage}><Loader width={150} className={style.loader}*/ />;
        }

        let { nodes, connectors } = this.store.data;
        let { mousePos, dragging } = this.state;

        let i = 0;
        let newConnector!: React.JSX.Element;

        if (dragging) {
            let sourceNode = this.store.getNodebyId(this.state.source[0]);
            let connectorStart = computeOutOffsetByIndex(sourceNode.x, sourceNode.y, this.state.source[1]);
            let connectorEnd = { x: this.state.mousePos.x, y: this.state.mousePos.y };

            newConnector = <Spline
                start={connectorStart}
                end={connectorEnd}
            />
        }

        let splineIndex = 0;

        return (
            <div className={dragging ? 'dragging' : ''} >
                {nodes.map((node) => {
                    return <Node
                        index={i++}
                        nid={node.id}
                        title={node.name}
                        inputs={node.fields.inputs}
                        outputs={node.fields.outputs}
                        pos={{ x: node.x, y: node.y }}
                        key={node.id}

                        //onNodeStart={(nid) => this.handleNodeStart(nid)}
                        onNodeStop={(index: number, pos: Position) => this.store.onNodeStop(index, pos)}
                        onNodeMove={(index: number, pos: Position) => this.store.onNodeMove(index, pos)}

                        onStartConnector={(nid: number, outputIndex: number) => this.handleStartConnector(nid, outputIndex)}
                        onCompleteConnector={(nid: number, inputIndex: number) => this.handleCompleteConnector(nid, inputIndex)}

                        //onNodeSelect={(nid) => { this.handleNodeSelect(nid) }}
                        //onNodeDeselect={(nid) => { this.handleNodeDeselect(nid) }}
                    />
                })}

                {/* render our connectors */}

                <SVGComponent height="100%" width="100%" ref={this.ref} >

                    {connectors.map((connector) => {
                        let fromNode = this.store.getNodebyId(connector.fromNode);
                        let toNode = this.store.getNodebyId(connector.toNode);

                        let splinestart = computeOutOffsetByIndex(fromNode.x, fromNode.y, this.computePinIndexfromLabel(fromNode.fields.outputs, connector.from));
                        let splineend = computeInOffsetByIndex(toNode.x, toNode.y, this.computePinIndexfromLabel(toNode.fields.inputs, connector.to));

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