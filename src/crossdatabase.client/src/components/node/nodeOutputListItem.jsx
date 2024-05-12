import { Component } from "react";
import PropTypes from "prop-types";

class NodeOutputListItem extends Component {
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

NodeOutputListItem.propTypes = {
    onMouseDown: PropTypes.func,
    index: PropTypes.number,
    item: PropTypes.object
}

export default NodeOutputListItem