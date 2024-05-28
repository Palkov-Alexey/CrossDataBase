import { NodeData } from "../types/NodeType";

const urls = {
    getNode: `api/node`
}


export default {
    async getNode(): Promise<NodeData> {
        const result = await fetch(urls.getNode, {
            method: `GET`
        }).then(response => response.json());

        return result;
    }
}
