import { Component } from "react";
import PropTypes from 'prop-types';
import { TreeNode } from "./treeNodes";
import React from "react";

type NodeProp = {
    node: TreeNode;
}

export function Node({node}: NodeProp) {
    let name = node.name;
    let children = node.children;

    return (
        <>
            <li key={node.path}>
                <div>
                    {name}
                </div>
                {
                    children?.length && (
                        <ul>
                            {children.map(node => <Node node={node} />)}
                        </ul>
                    )
                }
            </li>
        </>
    )
}