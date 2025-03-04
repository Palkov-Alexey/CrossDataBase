import { Component, MouseEvent } from "react";
import NodeInputListItem from "./nodeInputListItem";

type NodeInputListProps = {
	onCompleteConnector: (...args: any[]) => void;
	items: string[];
}

class NodeInputList extends Component<NodeInputListProps> {
	onMouseUp(i: MouseEvent): void {
		this.props.onCompleteConnector(i);
	}

	render(): JSX.Element | null {
		let i = 0;

		if (!this.props.items) {
			return null;
		}

		return (
			<div className="nodeInputWrapper">
				<ul className="nodeInputList">
					{this.props.items.map((item) => {
						return (
							<NodeInputListItem onMouseUp={(e) => this.onMouseUp(e)} key={i} index={i++} item={item} />
						)
					})}
				</ul>
			</div>
		);
	}
}

export default NodeInputList