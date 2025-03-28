import { AuthType } from '../enum/authType';
import { ServerType } from '../enum/serverType';

export type ServerModel = {
    ServerType: ServerType;
    Host: string;
    Port: string;
    Instance: string;
    AuthType: AuthType;
    Login: string;
    Password: string;
};
