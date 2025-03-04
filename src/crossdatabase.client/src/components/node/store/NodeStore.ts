import { observable, action, computed } from "mobx";
import dataService from "../services/dataService";
import { NodeData, Connector, NodeElement } from "../types/NodeType";
import { Position } from "../types/Position";
import { MenuItem } from "../../common/contextMenu/types/MenuTypes";
import { NodeInfo } from "../types/NodeInfo";

class NodeStore {
    @observable accessor data: NodeData = {
        nodes: [],
        connectors: []
    };
    @observable accessor maxNodeId: number = 0;
    @observable accessor maxValue: number = 0;
    @observable accessor menuItems: MenuItem[] = [];

    @computed get isLoading(): boolean {
        return !this.data;
    }

    @action
    getData = async (): Promise<void> => {
        this.data = await dataService.getNode();
        const infos = await dataService.getInfo();

        this.maxValue = Math.max(...this.data.connectors.map(c => c.id));
        this.maxNodeId = Math.max(...this.data.nodes.map(n => n.id))

        infos.map(i => this.menuItems.push({
            id: i.type,
            name: i.name,
            action: (position: Position) => this.addNode(i, position)
        }))
    }

    @action
    onNodeMove = (index: number, pos: Position): void => {
        this.data.nodes[index].posX += pos.x;
        this.data.nodes[index].posY += pos.y;
    };

    @action
    onNodeStop = (index: number, pos: Position): void => {
        this.data.nodes[index].posX = pos.x;
        this.data.nodes[index].posY = pos.y;
    };

    @action
    onNewConnector = async (fromNode: number, from: string, toNode: number, to: string): Promise<void> => {
        let connection: Connector = { id: ++this.maxValue, fromNode, from, toNode, to };
        this.data.connectors.push(connection);
    }

    @action
    onRemoveConnector = async (connector: Connector): Promise<void> => {
        let connectors = this.data.connectors.filter(c => c.id !== connector.id);

        this.data.connectors = connectors;
    }

    @action
    getNodebyId = (id: number): NodeElement => {
        const node = this.data.nodes.filter(n => n.id === id)[0];

        return node;
    }

    @action
    addNode = (info: NodeInfo, position: Position): void => {
        this.data.nodes.push({
            id: ++this.maxNodeId, name: info.name, posX: position.x, posY: position.y,
            fields: {
                inputs: info.inputs,
                outputs: info.outputs
            }
        })
    }

    @action
    onRemoveNode = (nid: number): void => {
        this.data.nodes = this.data.nodes.filter(n => n.id !== nid);
        this.data.connectors = this.data.connectors.filter(c => c.fromNode !== nid && c.toNode !== nid);
    }
}

export default NodeStore;