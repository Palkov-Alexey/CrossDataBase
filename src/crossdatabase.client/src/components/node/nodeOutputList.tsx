import { Component } from "react";
import NodeOutputListItem from "./nodeOutputListItem";
import { ConnectionPoint } from "./types/NodeType";

type NodeOutputListProps = {
    onStartConnector: (index: number) => void;
    items: string[];
}

class NodeOutputList extends Component<NodeOutputListProps> {
    onMouseDown(i: number): void {
        this.props.onStartConnector(i);
    }

    render(): JSX.Element | null {
        let i = 0;

        if(!this.props.items){
			return null;
		}

        return (
            <div className="nodeOutputWrapper">
                <ul className="nodeOutputList">
                    {this.props.items.map((item) => {
                        return (
                            <NodeOutputListItem onMouseDown={(i) => this.onMouseDown(i)} key={i} index={i++} item={item} />
                        )
                    })}
                </ul>
            </div>
        );
    }
}

export default NodeOutputList