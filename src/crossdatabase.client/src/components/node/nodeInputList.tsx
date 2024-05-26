import React, { Component } from "react";
import NodeInputListItem from "./nodeInputListItem";
import PropTypes from "prop-types";

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