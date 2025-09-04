import { ServerModel } from '../models/server';

const urls = {
    getServerModel: `api/node/GetNodeList/`
};

export default {
    async getServerData(nid: number): Promise<ServerModel> {
        const response = await fetch(urls.getServerModel + nid, {
            method: `GET`
        });
        const json = await response.json();

        return json;
    }
};