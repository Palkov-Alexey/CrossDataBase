import { action, observable } from 'mobx';
import { AuthType } from '../enum/authType.ts';
import { ServerType } from '../enum/serverType.ts';
import { ServerModel } from '../models/server';

class ServerStore {
    @observable accessor data: ServerModel ={
        AuthType: AuthType.WindowsCredentials,
        Host: ``,
        Instance: ``,
        Login: ``,
        Password: ``,
        Port: ``,
        ServerType: ServerType.MSSQL
    }

    @action getData = async (nid: number): Promise<void> => {
        //this.data = await dataService.getServerData(nid);
    };

    @action setServerType = (type: number): void => {
        this.data.ServerType = type;
    };
}

export default ServerStore;
