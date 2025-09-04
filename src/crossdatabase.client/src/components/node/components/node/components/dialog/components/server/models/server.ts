import { AuthType } from '../enum/authType';
import { ServerType } from '../enum/serverType';

export type ServerModel = {
    serverType: ServerType;
    host: string;
    port: string;
    instance: string;
    authType: AuthType;
    login: string;
    password: string;
};
