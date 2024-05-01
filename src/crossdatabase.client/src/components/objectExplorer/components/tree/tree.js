import { NodeType } from "./nodeType";

export class Tree{
    constructor(tree, manageTree, type){
        this.tree = tree;
        this.tree.type = type || `browser`
    }
}