import { Resource } from '@common/models/resourceType.ts';
import { ServerType } from '../enum/serverType';

export const getServerType = (): Resource[] => [
    { value: ServerType.MSSQL, text: `MSSQL` },
    { value: ServerType.PostgreSQL, text: `PostgreSQL` }
];

export default {
    getServerType
};
