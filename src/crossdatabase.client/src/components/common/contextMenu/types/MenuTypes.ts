import { Position } from '../../../node/models/Position.ts';

export type MenuItem = {
    id: number;
    name: string;
    action: (position: Position) => void;
};
