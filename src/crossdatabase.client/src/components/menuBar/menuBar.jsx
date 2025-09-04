import { Component } from "react";
import styles from './styles.module.less';
import File from "./components/file/file";
import Help from "./components/Help/help";
class MenuBar extends Component {
    render() {
        return (
            <div className={styles.menu_bar}>
                <File />
                <Help />
            </div>
        )
    }
}

export default MenuBar;