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
        }
    }

    handleDragStart(event, ui) {
        this.props.onNodeStart(this.props.nid, ui);
    }

    handleDragStop(event, ui) {
        this.props.onNodeStop(this.props.nid, ui.position);
    }

    handleDrag(event, ui) {
        const position = {x: ui.deltaX, y: ui.deltaY}
        this.props.onNodeMove(this.props.index, position);
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
        console.log(`x: ${this.props.pos.x}, y: ${this.props.pos.y}`)

        let nodeClass = 'node' + (selected ? ' selected' : '');

        return (
            <div onDoubleClick={() => { this.handleClick() }}>
                <Draggable
                    position={{ x: this.props.pos.x, y: this.props.pos.y }}
                    handle=".node-header"
                    scale={1}
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
        );
    }
}

Node.propTypes = {
    onNodeSelect: PropTypes.func,
    onNodeDeselect: PropTypes.func,
    onNodeStart: PropTypes.func,
    onNodeStop: PropTypes.func,
    onNodeMove: PropTypes.func,
    onStartConnector: PropTypes.func,
    onCompleteConnector: PropTypes.func,
    nid: PropTypes.number,
    pos: PropTypes.object,
    title: PropTypes.string,
    index: PropTypes.number,
    inputs: PropTypes.arrayOf(PropTypes.object),
    outputs: PropTypes.arrayOf(PropTypes.object)
}

export default onClickOutside(Node);