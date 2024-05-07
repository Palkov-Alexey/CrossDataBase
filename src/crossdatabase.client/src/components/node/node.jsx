import React, { useState } from "react";
import Draggable from "react-draggable";
import onClickOutside from 'react-onclickoutside';
import NodeInputList from "./nodeInputList";
import NodeOutputList from "./nodeOutputList";
import PropTypes from "prop-types";

const Node = ({ 
    onNodeDeselect,
    onNodeSelect,
    onNodeStart,
    onNodeStop,
    onNodeMove,
    onStartConnector,
    onCompleteConnector,
    index,
    inputs,
    outputs,
    nid,
    pos,
    title
}) => {
    const [selected, setSelected] = useState(false);

    // useEffect(() => {}, [selected]);

    const handleDragStart = (eve, ui) => {
        onNodeStart(nid, ui);
    }

    const handleDragStop = (eve, ui) => {
        onNodeStop(nid, {x: ui.x, y: ui.y});
    }

    const handleDrag = (eve, ui) => {
        // console.log(ui);
        onNodeMove(index, {x: ui.x, y: ui.y});
    }

    const handleOnStartConnector = idx => {
        onStartConnector(nid, idx);
    }

    const handleOnCompleteConnector = idx => {
        onCompleteConnector(nid, idx);
    }

    const handleClick = () => {
        setSelected(true);
        if (onNodeSelect) {
            onNodeSelect(nid);
        }
    }

    Node.handleClickOutside = () => {
        if (onNodeDeselect && selected) {
            onNodeDeselect(nid);
        }
        setSelected(false);
    }

    let nodeClass = `node ${selected ? ' selected' : ''}`

    return (
        <div onDoubleClick={() => handleClick()}>
            <Draggable
                position={{ x: pos.x, y: pos.y }}
                handle={".node-header"}
                onStart={(eve, ui) => handleDragStart(eve, ui)}
                onStop={(eve, ui) => handleDragStop(eve, ui)}
                onDrag={(eve, ui) => handleDrag(eve, ui)}>
                <section className={nodeClass} style={{zIndex: 10000}}>
                    <header className={"node-header"}>
                        <span className={"node-title"}>{title}</span>
                    </header>
                    <div className={"node-content"}>
                        <NodeInputList 
                            items={inputs}
                            onCompleteConnector={idx => handleOnCompleteConnector(idx)} />
                        <NodeOutputList
                            items={outputs}
                            onStartConnector={idx => handleOnStartConnector(idx)} />
                    </div>
                </section>
            </Draggable>
        </div>
    );
}

// Node.propTypes = {
//     onNodeSelect: PropTypes.func,
//     onNodeDeselect: PropTypes.func,
//     onNodeStart: PropTypes.func,
//     onNodeStop: PropTypes.func,
//     onNodeMove: PropTypes.func,
//     onStartConnector: PropTypes.func,
//     onCompleteConnector: PropTypes.func,
//     nid: PropTypes.number,
//     pos: PropTypes.object,
//     title: PropTypes.string,
//     index: PropTypes.number,
//     inputs: PropTypes.arrayOf(PropTypes.object),
//     outputs: PropTypes.arrayOf(PropTypes.object)
// }

const handleClickConfig = {
    handleClickOutside: (instance) => instance.handleClickOutside
}

let event = onClickOutside(Node, handleClickConfig)

export default event;