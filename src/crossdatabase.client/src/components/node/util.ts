export function computeInOffsetByIndex(x: number, y: number, index: number = 0): { x: number; y: number } {
    const outx = x + 15;
    const outy = y + 47 + (index * 20);

    return { x: outx, y: outy };
}

export function computeOutOffsetByIndex(x: number, y: number, index: number = 0): { x: number; y: number } {
    const outx = x + 166;
    const outy = y + 49 + (index * 22);

    return { x: outx, y: outy };
}