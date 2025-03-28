import { MenuItem } from '@common/contextMenu/types/MenuTypes.ts';
import { Component, ReactNode } from 'react';
import Draggable, { DraggableData, DraggableEvent } from 'react-draggable';
import onClickOutside from 'react-onclickoutside';
import ContextMenu from '../../../common/contextMenu';
import { NodeType } from '../../enums/nodeTypes.ts';
import { Position } from '../../models/Position';
import Dialog from './components/dialog';
import NodeInputList from './components/inputs/nodeInputList';
import NodeOutputList from './components/outputs/nodeOutputList';

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
    type: NodeType;
};

interface IState {
    selected: boolean;
    isClicked: boolean;
    dialogVisible: boolean;
}

class Node extends Component<NodeProps, IState> {
    constructor(props: NodeProps) {
        super(props);

        this.state = {
            selected: false,
            isClicked: false,
            dialogVisible: false
        };
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
        const position = { x: ui.lastX, y: ui.lastY };
        this.props.onNodeStop(this.props.index, position);
    }

    handleDrag = (event: DraggableEvent, ui: DraggableData): void => {
        const position = { x: ui.deltaX, y: ui.deltaY };
        this.props.onNodeMove(this.props.index, position);
    };

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
        const { selected } = this.state;

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
    
    setDialogVisible(isVisible: boolean = false): void {
        this.setState({ dialogVisible: isVisible });
    }

    render(): ReactNode {
        const { title, inputs, outputs, pos: { x: posX, y: posY }, nid, type } = this.props;
        const { selected, isClicked, dialogVisible } = this.state;

        const nodeClass = `node` + (selected ? ` selected` : ``);

        return (
            <div onDoubleClick={() => { this.handleClick(); this.setDialogVisible(true); }}
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
                <div>
                    {dialogVisible && <Dialog dialogType={type} nid={nid} visible={dialogVisible} width={`auto`} needCloseIcon={false} onClose={() => this.setDialogVisible()}/>}
                </div>
            </div>
        );
    }
}

export default onClickOutside(Node);
