import { Component } from "react";
import NodeOutputListItem from "./nodeOutputListItem";
import PropTypes from "prop-types";

class NodeOutputList extends Component {
    onMouseDown(i) {
        this.props.onStartConnector(i);
    }

    render() {
        let i = 0;

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

NodeOutputList.propTypes = {
    onStartConnector: PropTypes.func,
    items: PropTypes.arrayOf(PropTypes.object)
}

export default NodeOutputList