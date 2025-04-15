import { NodeElement } from '../models/NodeData.ts';
import { NodeInfo } from '../models/NodeInfo';

const urls = {
    // getNode: `api/node`,
    getNodeList: `api/node/GetNodeList`,
    getProcessId: `api/process`,
    node: `api/node`
};

export default {
    // async getNode(): Promise<NodeData> {
    //     const response = await fetch(urls.getNode, {
    //         method: `GET`
    //     });
    //     const json = await response.json()

    //     return json;
    // },

    async getInfo(): Promise<NodeInfo[]> {
        const response = await fetch(urls.getNodeList, {
            method: `GET`
        });

        return await response.json().then(data =>  data.data );
    },

    async getProcessId(): Promise<number> {
        const response = await fetch(urls.getProcessId, {
            method: `GET`
        });

        return await response.json().then(data =>  data.data );
    },

    async createNode(processId: number, node: NodeElement): Promise<number> {
        const response = await fetch(`${urls.node}?processId=${processId}`, {
            method: `POST`,
            body: JSON.stringify(node),
            headers: {
                "Content-Type": `application/json`
            }
        });

        return await response.json().then(data =>  data.data );
    }
};
