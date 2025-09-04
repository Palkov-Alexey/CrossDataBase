import { observable, action } from 'mobx';
import { MenuItem } from '../../common/contextMenu/types/MenuTypes.ts';
import { NodeData, Connector, NodeElement } from '../models/NodeData';
import { NodeInfo } from '../models/NodeInfo';
import { Position } from '../models/Position';
import dataService from '../services/dataService';

class NodeStore {
    @observable accessor data: NodeData = {
        nodes: [],
        connectors: []
    };

    @observable accessor processId: number = 0;

    @observable accessor maxNodeId: number = 0;

    @observable accessor maxValue: number = 0;

    @observable accessor menuItems: MenuItem[] = [];

    @observable accessor isLoading: boolean = false;

    @action
        getData = async (): Promise<void> => {
            this.processId = await dataService.getProcessId();
            const infos = await dataService.getInfo();

            if (this.data.nodes) {
                this.maxValue = Math.max(...this.data.connectors.map(c => c.id));
                this.maxNodeId = Math.max(...this.data.nodes.map(n => n.id));
            }

            this.setMenuItem(infos.map((i): MenuItem => ({
                id: i.type,
                name: i.name,
                action: (position) => this.addNode(i, position)
            })));
        };

    @action
        setMenuItem = (items: MenuItem[]): void => {
            this.menuItems = items;
        };

    @action
        onNodeMove = (index: number, pos: Position): void => {
            this.data.nodes[index].posX += pos.x;
            this.data.nodes[index].posY += pos.y;
        };

    @action
        onNodeStop = async (index: number, pos: Position): Promise<void> => {
            this.data.nodes[index].posX = pos.x;
            this.data.nodes[index].posY = pos.y;

            await this.onUpdateNode(this.data.nodes[index]);
        };

    @action
        onNewConnector = async (fromNode: number, from: string, toNode: number, to: string): Promise<void> => {
            const connectors = this.data.connectors.filter(c => c.toNode !== toNode);
            connectors.push({ id: ++this.maxValue, fromNode, from, toNode, to });

            this.data.connectors = connectors;
        };

    @action
        onRemoveConnector = async (connector: Connector): Promise<void> => {
            const connectors = this.data.connectors.filter(c => c.id !== connector.id);

            this.data.connectors = connectors;
        };

    @action
        getNodebyId = (id: number): NodeElement => {
            const node = this.data.nodes.filter(n => n.id === id)[0];

            return node;
        };

    @action
        addNode = async (info: NodeInfo, position: Position): Promise<void> => {
            const node: NodeElement = {
                id: 0,
                name: info.name,
                posX: position.x,
                posY: position.y,
                type: info.type,
                fields: {
                    inputs: info.inputs,
                    outputs: info.outputs
                }
            };

            node.id = await dataService.createNode(this.processId, node);

            this.data.nodes.push(node);
        };

    @action
        onRemoveNode = (nid: number): void => {
            this.data.nodes = this.data.nodes.filter(n => n.id !== nid);
            this.data.connectors = this.data.connectors.filter(c => c.fromNode !== nid && c.toNode !== nid);
        };

    onUpdateNode = async (node: NodeElement):Promise<void> => {
        await dataService.updateNode(this.processId, node);
    }
}

export default NodeStore;
