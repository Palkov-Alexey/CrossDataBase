import { Component, MouseEvent } from "react";
import style from './style.module.css';
import { MenuItem } from "./types/MenuTypes";
import { Position } from "../../node/types/Position";

type MenuProps = {
    top: number,
    left: number,
    onMouseLeave: () => void,
    items: MenuItem[]
}

class ContextMenu extends Component<MenuProps> {
    constructor(props: MenuProps) {
        super(props)
    }

    onMouseLeave(): void {
        this.props.onMouseLeave();
    }

    onClick(item: MenuItem, e: MouseEvent): void {
        const pos: Position = {x: e.pageX, y: e.pageY} 
        item.action(pos);
        this.onMouseLeave();
    }

    renderItem(item: MenuItem): JSX.Element {
        return <li className={style.li}
            onClick={(e) => {this.onClick(item, e)}}>
            {item.name}
        </li>;
    }

    render(): JSX.Element {
        const { items } = this.props;

        return <div className={style.menu}
            style={{ top: `${this.props.top}px`, left: `${this.props.left}px` }}
            onMouseLeave={() => this.onMouseLeave()}>
            <ul className={style.ul}>
                {items.sort(item => item.id).map(item => this.renderItem(item))}
            </ul>
        </div>
    }
}

export default ContextMenu;