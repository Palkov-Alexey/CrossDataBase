import { Component } from "react";
import Draggable, { DraggableData, DraggableEvent } from "react-draggable";
import onClickOutside from 'react-onclickoutside';
import NodeInputList from "./nodeInputList";
import NodeOutputList from "./nodeOutputList";
import { ConnectionPoint } from "./types/NodeData";
import { Position } from "./types/Position";
import ContextMenu from "../common/contextMenu";
import { MenuItem } from "../common/contextMenu/types/MenuTypes";

type NodeProps = {
    onNodeSelect: () => void;
    onNodeDeselect: () => void;
    //onNodeStart: () => void;
    onNodeStop: (index: number, pos: Position) => void;
    onNodeMove: (index: number, pos: Position) => void;
    onStartConnector: (nid: number, outputIndex: number) => void;
    onCompleteConnector: (nid: number, outputIndex: number) => void;
    onRemoveNode: () => void;
    nid: number;
    pos: Position;
    title: string;
    index: number;
    inputs: string[];
    outputs: string[];
}

interface IState {
    selected: boolean;
    isClicked: boolean;
}


class Node extends Component<NodeProps, IState> {
    constructor(props: NodeProps) {
        super(props);

        this.state = {
            selected: false,
            isClicked: false
        }
    }

    menuPos = {
        top: 0,
        left: 0
    };

    menuItems: MenuItem[] = [
        {
            id: 1,
            name: `Delete`,
            action: () => this.props.onRemoveNode()
        }
    ];

    // handleDragStart(event: DraggableEvent, ui: DraggableData) {
    //     this.props.onNodeStart(this.props.nid, ui);
    // }

    handleDragStop(event: DraggableEvent, ui: DraggableData): void {
        const position = { x: ui.lastX, y: ui.lastY }
        this.props.onNodeStop(this.props.index, position);
    }

    handleDrag = (event: DraggableEvent, ui: DraggableData): void => {
        const position = { x: ui.deltaX, y: ui.deltaY }
        this.props.onNodeMove(this.props.index, position);
    }

    onStartConnector(index: number): void {
        this.props.onStartConnector(this.props.nid, index);
    }

    onCompleteConnector(index: number): void {
        this.props.onCompleteConnector(this.props.nid, index);
    }

    handleClick(): void {
        this.setState({ selected: true });
        if (this.props.onNodeSelect) {
            this.props.onNodeSelect();
        }
    }

    handleClickOutside(): void {
        let { selected } = this.state;
        if (this.props.onNodeDeselect && selected) {
            this.props.onNodeDeselect();
        }
        this.setState({ selected: false });
    }

    setClicked(isClicked: boolean): void {
        this.setState({ isClicked });
    }

    setMenuPos(x: number, y: number): void {
        this.menuPos.top = y;
        this.menuPos.left = x;
    }

    onMouseLeave(): void {
        this.setClicked(false);
    }

    render(): JSX.Element {
        const { title, inputs, outputs, pos: { x: posX, y: posY } } = this.props;
        let { selected, isClicked } = this.state;

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
                    defaultPosition={{ x: posX, y: posY }}
                    handle=".node-header"
                    scale={1}
                    //onStart={(event, ui) => this.handleDragStart(event, ui)}
                    onStop={(event, ui) => this.handleDragStop(event, ui)}
                    onDrag={(event, ui) => this.handleDrag(event, ui)}>
                    <section className={nodeClass} style={{ zIndex: 2 }}>
                        <header className="node-header">
                            <span className="node-title">{title}</span>
                        </header>
                        <div className="node-content">
                            <NodeInputList items={inputs} onCompleteConnector={(index: number) => this.onCompleteConnector(index)} />
                            <NodeOutputList items={outputs} onStartConnector={(index: number) => this.onStartConnector(index)} />
                        </div>

                    </section>
                </Draggable>
                {isClicked && (
                    <ContextMenu
                        top={this.menuPos.top}
                        left={this.menuPos.left}
                        onMouseLeave={() => this.onMouseLeave()}
                        items={this.menuItems} />
                )}
            </div>
        );
    }
}

export default onClickOutside(Node);