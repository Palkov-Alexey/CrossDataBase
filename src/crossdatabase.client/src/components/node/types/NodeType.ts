export type NodeData = {
    nodes: NodeElement[];
    connectors: Connectors[];
}

export type NodeElement = {
    id: number;
    name: string;
    posX: number;
    posY: number;
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