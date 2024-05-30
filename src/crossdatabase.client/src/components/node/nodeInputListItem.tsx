import React, { Component } from "react";
import { ConnectionPoint } from "./types/NodeType";

type NodeInputListItemProps = {
    onMouseUp: (...args: any[]) => void,
    index: number,
    item: ConnectionPoint
}

interface IState {
    hover: boolean;
}

class NodeInputListItem extends Component<NodeInputListItemProps, IState> {
    constructor(props: NodeInputListItemProps) {
        super(props);
        this.state = {
            hover: false
        }
    }

    onMouseUp(e: any) {
        e.stopPropagation();
        e.preventDefault();

        this.props.onMouseUp(this.props.index);
    }

    onMouseOver() {
        this.setState({ hover: true });
    }

    onMouseOut() {
        this.setState({ hover: false });
    }

    noop(e) {
        e.stopPropagation();
        e.preventDefault();
    }

    render() {
        let { name } = this.props.item;
        let { hover } = this.state;

        return (
            <li>
                <a onClick={(e) => this.noop(e)} onMouseUp={(e) => this.onMouseUp(e)} href="#">
                    <i className={hover ? 'fa fa-circle-o hover' : 'fa fa-circle-o'}
                        onMouseOver={() => { this.onMouseOver() }}
                        onMouseOut={() => { this.onMouseOut() }}
                    ></i>
                    {name}
                </a>
            </li>
        );
    }
}



export default NodeInputListItem