import { Component } from "react";
import Draggable from "react-draggable";
import onClickOutside from 'react-onclickoutside';
import NodeInputList from "./nodeInputList";
import NodeOutputList from "./nodeOutputList";
import PropTypes from "prop-types";

class Node extends Component {
    constructor(props) {
        super(props);

        this.state = {
            selected: false
        };
    }

    handleDragStart(event, ui) {
        this.props.onNodeStart(this.props.nid, ui);
    }

    handleDragStop(event, ui) {
        this.props.onNodeStop(this.props.nid, ui.position);
    }

    handleDrag(event, ui) {
        this.props.onNodeMove(this.props.index, ui.position);
    }

    shouldComponentUpdate(nextProps, nextState) {
        return this.state.selected !== nextState.selected;
    }

    onStartConnector(index) {
        this.props.onStartConnector(this.props.nid, index);
    }

    onCompleteConnector(index) {
        this.props.onCompleteConnector(this.props.nid, index);
    }

    handleClick() {
        this.setState({ selected: true });
        if (this.props.onNodeSelect) {
            this.props.onNodeSelect(this.props.nid);
        }
    }

    handleClickOutside() {
        let { selected } = this.state;
        if (this.props.onNodeDeselect && selected) {
            this.props.onNodeDeselect(this.props.nid);
        }
        this.setState({ selected: false });
    }

    render() {
        let { selected } = this.state;

        let nodeClass = `node` + (selected ? ` selected` : ``);

        return (
            <div onDoubleClick={() => { this.handleClick() }}>
                <Draggable
                    start={{ x: this.props.pos.x, y: this.props.pos.y }}
                    handle=".node-header"
                    onStart={(event, ui) => this.handleDragStart(event, ui)}
                    onStop={(event, ui) => this.handleDragStop(event, ui)}
                    onDrag={(event, ui) => this.handleDrag(event, ui)}>
                    <section className={nodeClass} style={{ zIndex: 10000 }}>
                        <header className="node-header">
                            <span className="node-title">{this.props.title}</span>
                        </header>
                        <div className="node-content">
                            <NodeInputList items={this.props.inputs} onCompleteConnector={(index) => this.onCompleteConnector(index)} />
                            <NodeOutputList items={this.props.outputs} onStartConnector={(index) => this.onStartConnector(index)} />
                        </div>
                    </section>
                </Draggable>
            </div>

        )
    }
}

Node.propTypes = {
    onNodeSelect: PropTypes.func.isRequired,
    onNodeDeselect: PropTypes.func.isRequired,
    onNodeStart: PropTypes.func.isRequired,
    onNodeStop: PropTypes.func.isRequired,
    onNodeMove: PropTypes.func.isRequired,
    onStartConnector: PropTypes.func.isRequired,
    onCompleteConnector: PropTypes.func.isRequired,
    nid: PropTypes.number.isRequired,
    pos: PropTypes.object.isRequired,
    title: PropTypes.string.isRequired,
    index: PropTypes.number.isRequired,
    inputs: PropTypes.object.isRequired,
    outputs: PropTypes.object.isRequired
}

export default onClickOutside(Node);