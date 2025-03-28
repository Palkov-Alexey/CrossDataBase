import { Component, MouseEvent, ReactNode } from 'react';
import { Position } from '../../node/models/Position';
import { MenuItem } from './types/MenuTypes';
import style from './style.module.less';

type MenuProps = {
    top: number;
    left: number;
    onMouseLeave: () => void;
    items: MenuItem[]
};

class ContextMenu extends Component<MenuProps> {
    constructor(props: MenuProps) {
        super(props);
    }

    onMouseLeave(): void {
        this.props.onMouseLeave();
    }

    onClick(item: MenuItem, e: MouseEvent): void {
        const pos: Position = { x: e.pageX, y: e.pageY };
        item.action(pos);
        this.onMouseLeave();
    }

    renderItem(item: MenuItem): ReactNode {
        return <li className={style.li}
            onClick={(e) => { this.onClick(item, e); }}>
            {item.name}
        </li>;
    }

    render(): ReactNode {
        const { items } = this.props;

        return <div className={style.menu}
            style={{ top: `${this.props.top}px`, left: `${this.props.left}px` }}
            onMouseLeave={() => this.onMouseLeave()}>
            <ul className={style.ul}>
                {items.sort((a, b) => a.id - b.id).map(item => this.renderItem(item))}
            </ul>
        </div>;
    }
}

export default ContextMenu;
