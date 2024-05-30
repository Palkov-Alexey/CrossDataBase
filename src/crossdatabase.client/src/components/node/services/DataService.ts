import { NodeData } from "../types/NodeType";

const urls = {
    getNode: `api/node`
}


export default {
    async getNode(): Promise<NodeData> {
        const response = await fetch(urls.getNode, {
            method: `GET`
        });
        const json = await response.json()

        return json;
    }
}
