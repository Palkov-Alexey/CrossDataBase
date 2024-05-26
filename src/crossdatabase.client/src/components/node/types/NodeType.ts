type NodeData = {
    nodes: NodeElement[];
    connectors: Connectors[];
}

type NodeElement = {
    id: number;
    Name: string;
    x: number;
    y: number;
    fields: Fields;
}

type Connectors = {
    id: number;
    fromNode: number;
    from: string;
    toNode: number;
    to: string;
}

type Fields = {
    inputs: ConnectionPoint[]
    outputs: ConnectionPoint[]
}

type ConnectionPoint = {
    name: string
}