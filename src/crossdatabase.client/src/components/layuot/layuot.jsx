import { Component } from "react";
import MenuBar from "../menuBar/menuBar";
import PropTypes from 'prop-types';
import style from './style.module.less'

class Layout extends Component {
    constructor(props) {
        super(props)
        this.store = {
            children: props.children
        }
    }

    render() {
        return (
            <>
                <MenuBar />
                <div className={style.doc}>
                    <div className={style.HBox}>
                        <div className={style.VBox}>{this.store.children}</div>
                        <div className={style.VBox}></div>
                    </div>
                </div>
            </>
        )
    }
}

Layout.propTypes = {
    children: PropTypes.node
}

export default Layout;