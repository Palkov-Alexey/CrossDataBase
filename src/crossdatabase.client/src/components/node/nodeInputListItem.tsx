import { Component, MouseEvent } from "react";

type NodeInputListItemProps = {
    onMouseUp: (...args: any[]) => void;
    index: number;
    item: string;
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

    onMouseUp(e: MouseEvent): void {
        e.stopPropagation();
        e.preventDefault();

        this.props.onMouseUp(this.props.index);
    }

    onMouseOver(): void {
        this.setState({ hover: true });
    }

    onMouseOut(): void {
        this.setState({ hover: false });
    }

    noop(e: MouseEvent): void {
        e.stopPropagation();
        e.preventDefault();
    }

    render(): JSX.Element {
        let { item } = this.props;
        let { hover } = this.state;

        return (
            <li>
                <a onClick={(e) => this.noop(e)} onMouseUp={(e) => this.onMouseUp(e)} href="#">
                    <i className={hover ? 'fa fa-circle-o hover' : 'fa fa-circle-o'}
                        onMouseOver={() => { this.onMouseOver() }}
                        onMouseOut={() => { this.onMouseOut() }}
                    ></i>
                    {item}
                </a>
            </li>
        );
    }
}

export default NodeInputListItem