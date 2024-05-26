import React, { Component } from 'react';
import ReactNodeGraph from './components/node/index'
import './node.css'

class App extends Component {
    constructor(props: any) {
        super(props);
    }

    // getNodeIndex = (nodes, nid) => {
    //     return nodes.findIndex(x => x.nid === nid)
    // }

    // onNewConnector = (fromNode, fromPin, toNode, toPin) => {
    //     let connections = [this.state.connections, {
    //         from_node: fromNode,
    //         from: fromPin,
    //         to_node: toNode,
    //         to: toPin
    //     }];
    //     let state = this.state;

    //     console.log({ state, connections });
    //     this.setState(old => {
    //         return {
    //             old,
    //             "connections": connections
    //         }
    //     });
    // }

    // onRemoveConnector = (connector) => {
    //     let connections = this.state.connections;
    //     connections = connections
    //         .filter(connection => connection.from_node !== connector.from_node && connection.to_node !== connector.to_node);

    //     this.setState({ connections: connections });
    // }

    // onNodeMove = (index, pos) => {
    //     let nodes = this.state.nodes;
    //     nodes[index].x = pos.x;
    //     nodes[index].y = pos.y;
    //     this.setState({ nodes: nodes });
    //     console.log(`end move:`, index, pos);
    // }

    // onNodeStartMove = nid => {
    //     console.log(`start move:`, nid);
    // }

    // handleNodeSelect = nid => {
    //     console.log(`node selected:`, nid);
    // }

    // handleNodeDeselect = nid => {
    //     console.log(`node deselected:`, nid);
    // }

    render() {
        return <ReactNodeGraph
        />;
    }
}

// class App extends Component {
//     constructor() {
//         super();
//         this.state = {
//             users: []
//         };
//     }

//     getUsers = async () => {
//         let response = await fetch("api/user",
//             {
//                 method: "get"
//             })
//         let result = await response.json();

//         this.setState({
//             users: result
//         })
//     }

//     render() {
//         const users = this.state.users.map((item, index) => <li key={index}>{item.name}</li>);

//         return <Fragment>
//                 <button onClick={this.getUsers}>Получить сотрудников</button>
//                 <ul>{users}</ul>
//             </Fragment>
//         ;
//     }
// }

export default App;