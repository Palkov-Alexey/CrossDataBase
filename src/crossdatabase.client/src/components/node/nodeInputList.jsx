import { Component } from "react";
import NodeInputListItem from "./nodeInputListItem";
import PropTypes from "prop-types";

class NodeInputList extends Component {

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

// NodeInputList.propTypes = {
//     onCompleteConnector: PropTypes.func.isRequired,
//     items: PropTypes.arrayOf(PropTypes.object.isRequired).isRequired
// }

export default NodeInputList