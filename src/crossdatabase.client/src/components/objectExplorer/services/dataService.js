import { NodeType } from "../components/tree/nodeType"
import { TreeNode } from "../components/tree/treeNodes"

export default class DataSource{
    getTree = async() => {
        return new TreeNode(){
        };
    }
}