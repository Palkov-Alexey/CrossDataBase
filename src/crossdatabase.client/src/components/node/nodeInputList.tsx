import { Component } from "react";
import NodeInputListItem from "./nodeInputListItem";
import { ConnectionPoint } from "./types/NodeType";

type NodeInputListProps = {
    onCompleteConnector: (...args: any[]) => void;
    items: ConnectionPoint[]
}

class NodeInputList extends Component<NodeInputListProps> {
	onMouseUp(i) {
		this.props.onCompleteConnector(i);
	}
	
	render() {
		let i = 0;

		if(!this.props.items){
			return null;
		}

		return (
			<div className="nodeInputWrapper">
				<ul className="nodeInputList">
					{this.props.items.map((item) => {
						return (
							<NodeInputListItem onMouseUp={(i)=>this.onMouseUp(i)} key={i} index={i++} item={item} />
						)
					})}
				</ul>
			</div>
		);
	}
}



export default NodeInputList