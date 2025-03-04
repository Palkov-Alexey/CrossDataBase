import { Component, MouseEvent } from "react";

type NodeOutputListItemProps = {
    onMouseDown: (...args: any[]) => void;
    index: number;
    item: string;
}

interface IState {
    hover: boolean;
}

class NodeOutputListItem extends Component<NodeOutputListItemProps, IState> {
    onMouseDown(e: MouseEvent): void {
        e.stopPropagation();
        e.preventDefault();

        this.props.onMouseDown(this.props.index);
    }

    noop(e: MouseEvent): void {
        e.stopPropagation();
        e.preventDefault();
    }

    render(): JSX.Element {
        return (
            <li onMouseDown={(e) => this.onMouseDown(e)}>
                <a href="#" onClick={(e) => this.noop(e)}>{this.props.item} <i className="fa fa-circle-o"></i></a>
            </li>
        );
    }
}

export default NodeOutputListItem