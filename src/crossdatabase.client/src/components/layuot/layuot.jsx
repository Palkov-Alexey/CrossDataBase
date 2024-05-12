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
                {this.store.children}                       
            </>
        )
    }
}

Layout.propTypes = {
    children: PropTypes.node
}

export default Layout;