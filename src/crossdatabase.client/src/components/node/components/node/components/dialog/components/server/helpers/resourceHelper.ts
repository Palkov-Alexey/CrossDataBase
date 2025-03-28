import { Resource } from '@common/models/resourceType.ts';
import { AuthType } from '../enum/authType.ts';
import { ServerType } from '../enum/serverType';

export const getServerType = (): Resource[] => [
    { value: ServerType.MSSQL, text: `Microsoft SQL Server` },
    { value: ServerType.PostgreSQL, text: `PostgreSQL` }
];

export const getAuthType = (): Resource[] => [
    { value: AuthType.WindowsCredentials, text: `Windows Credentials` },
    { value: AuthType.UserAndPass, text: `User & Password` }
];

export default {
    getServerType,
    getAuthType
};
