import { Component } from "react";
import classnames from 'classnames/bind';
import style from  './style.module.css';

const cn = classnames.bind(style);

type MenuProps = {
    isNode: boolean,
    top: number,
    left: number,
    onMouseLeave: () => any
}

class ContextMenu extends Component<MenuProps> {
    constructor(props: MenuProps) {
        super(props)
    }

    onMouseLeave() {
        this.props.onMouseLeave();
    }

    render() {
        let text = this.props.isNode ? `Test Node` : `Test`;

        return <div className={ style.menu }
            style={{top: `${this.props.top}px`, left: `${this.props.left}px`}}
            onMouseLeave={() => this.onMouseLeave()}>
            <ul className={ style.ul }>
                <li className={ style.li }>{text} 1</li>
                <li className={ style.li }>{text} 2</li>
            </ul>
        </div>
    }
}

export default ContextMenu;