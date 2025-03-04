export type MenuItem = {
    id: number;
    name: string;
    action: (...args: any) => void
}