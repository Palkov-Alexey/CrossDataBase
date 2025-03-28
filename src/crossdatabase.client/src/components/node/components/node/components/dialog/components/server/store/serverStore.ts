import { action, observable } from 'mobx';
import { AuthType } from '../enum/authType.ts';
import { ServerType } from '../enum/serverType.ts';
import { ServerModel } from '../models/server';
import dataService from '../service/dataService.ts';

class ServerStore {
    @observable accessor data: ServerModel = {
        authType: AuthType.WindowsCredentials,
        host: ``,
        instance: ``,
        login: ``,
        password: ``,
        port: ``,
        serverType: ServerType.MSSQL
    };

    @action getData = async (nid: number): Promise<void> => {
        const data = await dataService.getServerData(nid);

        if (data) {
            this.data = data;
        }
    };

    @action setServerType = (type: number): void => {
        this.data.serverType = type;
        
        if (type === ServerType.PostgreSQL) {
            this.setAuthType(AuthType.UserAndPass);
        }
    };

    @action setAuthType = (type: number): void => {
        this.data.authType = type;
    };

    @action setHost = (host: string): void => {
        this.data.host = host;
    };

    @action setPort = (port: string): void => {
        this.data.port = port;
    };

    @action setInstance = (instance: string): void => {
        this.data.instance = instance;
    };

    @action setLogin = (login: string): void => {
        this.data.login = login;
    };

    @action setPassword = (password: string): void => {
        this.data.password = password;
    };
}

export default ServerStore;
