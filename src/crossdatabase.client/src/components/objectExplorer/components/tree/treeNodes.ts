import { NodeType } from "./nodeType";

export class TreeNode {
    constructor(id, parent, name, type) {
        this.id = id;
        this.setParent(parent);
        this.name = name;
        this.type = type ? type : undefined;
        this.children = [];
    }

    id: string;
    parentNode: TreeNode;
    name: string;
    type: NodeType;
    children: TreeNode[];
    path: string


    setParent(parent) {
        this.parentNode = parent;
        this.path = this.id;

        if (this.id) {
            if (parent !== null && parent !== undefined && parent.path !== undefined) {
                this.path = parent.path + '/' + this.id;
            } else {
                this.path = '/Root/' + this.id;
            }
        }
    }

    getName() {
        return this.name;
    }
}
