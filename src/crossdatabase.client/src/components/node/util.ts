export function computeInOffsetByIndex(x: number, y: number, index: number = 0) {
	let outx = x + 15;
	let outy = y + 47 + (index * 20);

	return { x: outx, y: outy };
}

export function computeOutOffsetByIndex(x: number, y: number, index: number = 0) {
	let outx = x + 166;
	let outy = y + 49 + (index * 22);

	return { x: outx, y: outy };
}