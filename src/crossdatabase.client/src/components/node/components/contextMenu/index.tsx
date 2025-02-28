import { observer } from "mobx-react";
import { Component } from "react";

type MenuProps = {
    isNode: boolean,
    top: number,
    left: number,
    onMouseLeave: () => any
}

@observer
class ContextMenu extends Component<MenuProps> {
    constructor(props: MenuProps) {
        super(props)
    }

    onMouseLeave(){
        this.props.onMouseLeave();
    }

    render() {
        let text = this.props.isNode ? `Test Node` : `Test`;
        console.log("R1C");
        return <div style={{top: `${this.props.top}px`, left: `${this.props.left}px`, boxSizing: `border-box`, position: `absolute`, width: `200px`, backgroundColor: `black`, zIndex: 10020}}
        onMouseLeave={() => this.onMouseLeave()}>
            <ul>
                <li>{text} 1</li>
                <li>{text} 2</li>
            </ul>
        </div>
    }
}

export default ContextMenu;