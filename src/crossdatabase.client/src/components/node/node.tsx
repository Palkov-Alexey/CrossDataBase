import { Component } from "react";
import Draggable, { DraggableData, DraggableEvent } from "react-draggable";
import onClickOutside from 'react-onclickoutside';
import NodeInputList from "./nodeInputList";
import NodeOutputList from "./nodeOutputList";
import { ConnectionPoint } from "./types/NodeType";
import { Position } from "./types/Position";
import ContextMenu from "./components/contextMenu";

type NodeProps = {
    onNodeSelect: (...args: any[]) => void;
    onNodeDeselect: (...args: any[]) => void,
    onNodeStart: (...args: any[]) => void,
    onNodeStop: (...args: any[]) => void,
    onNodeMove: (...args: any[]) => void,
    onStartConnector: (...args: any[]) => void,
    onCompleteConnector: (...args: any[]) => void,
    nid: number,
    pos: Position,
    title: string,
    index: number,
    inputs: ConnectionPoint[],
    outputs: ConnectionPoint[]
}

interface IState {
    selected: boolean
}

class Node extends Component<NodeProps, IState> {
    isClicked: boolean = false;
    menuPos = {
        top: 0,
        left: 0
    }

    constructor(props: NodeProps) {
        super(props);
        this.state = {
            selected: false
        }
    }

    handleDragStart(event: DraggableEvent, ui: DraggableData) {
        this.props.onNodeStart(this.props.nid, ui);
    }

    handleDragStop(event: DraggableEvent, ui: DraggableData) {
        const position = { x: ui.lastX, y: ui.lastY }
        this.props.onNodeStop(this.props.index, position);
    }

    handleDrag = (event: DraggableEvent, ui: DraggableData) => {
        const position = { x: ui.deltaX, y: ui.deltaY }
        this.props.onNodeMove(this.props.index, position);
    }

    shouldComponentUpdate(nextProps: NodeProps, nextState: IState,) {
        return this.state.selected !== nextState.selected;
    }

    onStartConnector(index: number) {
        this.props.onStartConnector(this.props.nid, index);
    }

    onCompleteConnector(index: number) {
        this.props.onCompleteConnector(this.props.nid, index);
    }

    handleClick() {
        this.setState({ selected: true });
        if (this.props.onNodeSelect) {
            this.props.onNodeSelect(this.props.nid);
        }
    }

    handleClickOutside() {
        let { selected } = this.state;
        if (this.props.onNodeDeselect && selected) {
            this.props.onNodeDeselect(this.props.nid);
        }
        this.setState({ selected: false });
    }

    setClicked(isClicked: boolean) {
        this.isClicked = isClicked;
    }

    setMenuPos(x: number, y: number) {
        this.menuPos.top = y;
        this.menuPos.left = x;
    }

    onMouseLeave(){
        this.isClicked = false;
    }

    render() {
        let { selected } = this.state;

        let nodeClass = 'node' + (selected ? ' selected' : '');

        return (
            <div onDoubleClick={() => { this.handleClick() }}
                onContextMenu={(e) => {
                    e.preventDefault();
                    this.handleClick();
                    this.setClicked(true);
                    this.setMenuPos(e.pageX, e.pageY);
                }}      >
                <Draggable
                    defaultPosition={{ x: this.props.pos.x, y: this.props.pos.y }}
                    handle=".node-header"
                    scale={1}
                    //onStart={(event, ui) => this.handleDragStart(event, ui)}
                    onStop={(event, ui) => this.handleDragStop(event, ui)}
                    onDrag={(event, ui) => this.handleDrag(event, ui)}>
                    <section className={nodeClass} style={{ zIndex: 10000 }}>
                        <header className="node-header">
                            <span className="node-title">{this.props.title}</span>
                        </header>
                        <div className="node-content">
                            <NodeInputList items={this.props.inputs} onCompleteConnector={(index: number) => this.onCompleteConnector(index)} />
                            <NodeOutputList items={this.props.outputs} onStartConnector={(index: number) => this.onStartConnector(index)} />
                        </div>

                    </section>
                </Draggable>
                {this.isClicked && (
                    <ContextMenu isNode={true} top={this.menuPos.top} left={this.menuPos.left} onMouseLeave={() => this.onMouseLeave()}/>
                )}
            </div>
        );
    }
}



export default onClickOutside(Node);