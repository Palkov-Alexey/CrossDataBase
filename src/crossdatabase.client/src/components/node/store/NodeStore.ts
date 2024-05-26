import { action, observable } from "mobx";
import DataSource from "../services/DataService";

class NodeStore {
    // @observable data: NodeData = {
    //     nodes: [
    //         { "id": 1, "type": "WebGLRenderer", "x": 1479, "y": 351, "fields": { "in": [{ "name": "width" }, { "name": "height" }, { "name": "scene" }, { "name": "camera" }, { "name": "bg_color" }, { "name": "postfx" }, { "name": "shadowCameraNear" }, { "name": "shadowCameraFar" }, { "name": "shadowMapWidth" }, { "name": "shadowMapHeight" }, { "name": "shadowMapEnabled" }, { "name": "shadowMapSoft" }], "out": [] } },
    //         { "id": 14, "type": "Camera", "x": 549, "y": 478, "fields": { "in": [{ "name": "fov" }, { "name": "aspect" }, { "name": "near" }, { "name": "far" }, { "name": "position" }, { "name": "target" }, { "name": "useTarget" }], "out": [{ "name": "out" }] } },
    //         { "id": 23, "type": "Scene", "x": 1216, "y": 217, "fields": { "in": [{ "name": "children" }, { "name": "position" }, { "name": "rotation" }, { "name": "scale" }, { "name": "doubleSided" }, { "name": "visible" }, { "name": "castShadow" }, { "name": "receiveShadow" }], "out": [{ "name": "out" }] } },
    //         { "id": 35, "type": "Merge", "x": 948, "y": 217, "fields": { "in": [{ "name": "in0" }, { "name": "in1" }, { "name": "in2" }, { "name": "in3" }, { "name": "in4" }, { "name": "in5" }], "out": [{ "name": "out" }] } },
    //         { "id": 45, "type": "Color", "x": 950, "y": 484, "fields": { "in": [{ "name": "rgb" }, { "name": "r" }, { "name": "g" }, { "name": "b" }], "out": [{ "name": "rgb" }, { "name": "r" }, { "name": "g" }, { "name": "b" }] } },
    //         { "id": 55, "type": "Vector3", "x": 279, "y": 503, "fields": { "in": [{ "name": "xyz" }, { "name": "x" }, { "name": "y" }, { "name": "z" }], "out": [{ "name": "xyz" }, { "name": "x" }, { "name": "y" }, { "name": "z" }] } },
    //         { "id": 65, "type": "ThreeMesh", "x": 707, "y": 192, "fields": { "in": [{ "name": "children" }, { "name": "position" }, { "name": "rotation" }, { "name": "scale" }, { "name": "doubleSided" }, { "name": "visible" }, { "name": "castShadow" }, { "name": "receiveShadow" }, { "name": "geometry" }, { "name": "material" }, { "name": "overdraw" }], "out": [{ "name": "out" }] } },
    //         { "id": 79, "type": "Timer", "x": 89, "y": 82, "fields": { "in": [{ "name": "reset" }, { "name": "pause" }, { "name": "max" }], "out": [{ "name": "out" }] } },
    //         { "id": 84, "type": "MathMult", "x": 284, "y": 82, "fields": { "in": [{ "name": "in" }, { "name": "factor" }], "out": [{ "name": "out" }] } },
    //         { "id": 89, "type": "Vector3", "x": 486, "y": 188, "fields": { "in": [{ "name": "xyz" }, { "name": "x" }, { "name": "y" }, { "name": "z" }], "out": [{ "name": "xyz" }, { "name": "x" }, { "name": "y" }, { "name": "z" }] } }
    //     ],
    //     connections: [
    //         { id: 1, "fromNode": 23, "from": "out", "toNode": 1, "to": "scene" },
    //         { id: 2, "fromNode": 14, "from": "out", "toNode": 1, "to": "camera" },
    //         { id: 3, "fromNode": 14, "from": "out", "toNode": 35, "to": "in5" },
    //         { id: 4, "fromNode": 35, "from": "out", "toNode": 23, "to": "children" },
    //         { id: 5, "fromNode": 45, "from": "rgb", "toNode": 1, "to": "bg_color" },
    //         { id: 6, "fromNode": 55, "from": "xyz", "toNode": 14, "to": "position" },
    //         { id: 7, "fromNode": 65, "from": "out", "toNode": 35, "to": "in0" },
    //         { id: 8, "fromNode": 79, "from": "out", "toNode": 84, "to": "in" },
    //         { id: 9, "fromNode": 89, "from": "xyz", "toNode": 65, "to": "rotation" },
    //         { id: 10, "fromNode": 84, "from": "out", "toNode": 89, "to": "y" }
    //     ]
    // };

    @observable data: NodeData;

    @observable maxValue = 0;

    constructor() {
        //this.getData();
    }

    getData = () => {
        this.data = Promise.call(DataSource.getNode())

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
        if (node.Name === `Timer`) {
            console.log(node);
        }
        return node;
    }
}

export default NodeStore;