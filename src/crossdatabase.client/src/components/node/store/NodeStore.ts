import { observable, action, computed } from "mobx";
import dataService from "../services/dataService";
import { NodeData, Connectors } from "../types/NodeType";
import { Position } from "../types/Position";

class NodeStore {
    @observable accessor data!: NodeData;
    @observable accessor maxValue = 0;

    @computed get isLoading() {
        return !this.data; 
    }

    @action
    getData = async () => {
        this.data = await dataService.getNode();
        const connIds = this.data.connectors.map(c => c.id);
        this.maxValue = Math.max(...connIds);
    }

    @action
    onNodeMove = (index: number, pos: Position) => {
        this.data.nodes[index].x += pos.x;
        this.data.nodes[index].y += pos.y;
    };

    @action
    onNodeStop = (index: number, pos: Position) => {
        this.data.nodes[index].x = pos.x;
        this.data.nodes[index].y = pos.y;
    };

    @action
    onNewConnector = async (fromNode: number, from: string, toNode: number, to: string) => {
        let connection: Connectors = { id: ++this.maxValue, fromNode: fromNode, from: from, toNode: toNode, to: to };
        this.data.connectors.push(connection);
    }

    @action
    onRemoveConnector = async (connector: Connectors) => {
        let connectors = this.data.connectors.filter(c => c.id !== connector.id)

        this.data.connectors = connectors;
    }

    @action
    getNodebyId = (id: number) => {
        const node = this.data.nodes.filter(n => n.id === id)[0];
        if (node.name === `Timer`) {
            console.log(node);
        }
        return node;
    }    
}

export default NodeStore;