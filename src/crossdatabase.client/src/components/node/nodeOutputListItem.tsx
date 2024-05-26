import React, { Component } from "react";
import PropTypes from "prop-types";

type NodeOutputListItemProps = {
    onMouseDown: (...args: any[]) => void,
    index: number,
    item: ConnectionPoint
}

interface IState {
    hover: boolean;
}

class NodeOutputListItem extends Component<NodeOutputListItemProps, IState> {
    onMouseDown(e) {
        e.stopPropagation();
        e.preventDefault();

        this.props.onMouseDown(this.props.index);
    }

    noop(e) {
        e.stopPropagation();
        e.preventDefault();
    }

    render() {
        return (
            <li onMouseDown={(e) => this.onMouseDown(e)}>
                <a href="#" onClick={(e) => this.noop(e)}>{this.props.item.name} <i className="fa fa-circle-o"></i></a>
            </li>
        );
    }
}

export default NodeOutputListItem