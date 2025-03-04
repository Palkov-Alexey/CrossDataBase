import { NodeInfo } from "../types/NodeInfo";

const urls = {
    // getNode: `api/node`,
    getNodeList: `api/node/GetNodeList`
}

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
        const json = await response.json()

        return json;
    }
}
