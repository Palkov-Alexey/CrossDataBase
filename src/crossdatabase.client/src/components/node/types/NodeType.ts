export type NodeData = {
    nodes: NodeElement[];
    connectors: Connectors[];
}

export type NodeElement = {
    id: number;
    name: string;
    PosX: number;
    PosY: number;
    fields: Fields;
}

export type Connectors = {
    id: number;
    fromNode: number;
    from: string;
    toNode: number;
    to: string;
}

export type Fields = {
    inputs: ConnectionPoint[]
    outputs: ConnectionPoint[]
}

export type ConnectionPoint = {
    name: string
}