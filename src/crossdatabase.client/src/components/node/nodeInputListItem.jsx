import { Component } from "react";
import PropTypes from "prop-types";

class NodeInputListItem extends Component {
    constructor(props) {
        super(props);
        this.state = {
            hover: false
        }
    }

    onMouseUp(e) {
        e.stopPropagation();
        e.preventDefault();

        this.props.onMouseUp(this.props.index);
    }

    onMouseOver() {
        this.setState({ hover: true });
    }

    onMouseOut() {
        this.setState({ hover: false });
    }

    noop(e) {
        e.stopPropagation();
        e.preventDefault();
    }

    render() {
        let { name } = this.props.item;
        let { hover } = this.state;

        return (
            <li>
                <a onClick={(e) => this.noop(e)} onMouseUp={(e) => this.onMouseUp(e)} href="#">
                    <i className={hover ? 'fa fa-circle-o hover' : 'fa fa-circle-o'}
                        onMouseOver={() => { this.onMouseOver() }}
                        onMouseOut={() => { this.onMouseOut() }}
                    ></i>
                    {name}
                </a>
            </li>
        );
    }
}

// NodeInputListItem.propTypes = {
//     onMouseUp: PropTypes.func.isRequired,
//     index: PropTypes.number.isRequired,
//     item: PropTypes.object.isRequired
// }

export default NodeInputListItem