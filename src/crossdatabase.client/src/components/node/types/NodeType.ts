export type NodeData = {
    nodes: NodeElement[];
    connectors: Connector[];
}

export type NodeElement = {
    id: number;
    name: string;
    posX: number;
    posY: number;
    fields: Fields;
}

export type Connector = {
    id: number;
    fromNode: number;
    from: string;
    toNode: number;
    to: string;
}

export type Fields = {
    inputs: string[];
    outputs: string[];
}

export type ConnectionPoint = {
    name: string;
}