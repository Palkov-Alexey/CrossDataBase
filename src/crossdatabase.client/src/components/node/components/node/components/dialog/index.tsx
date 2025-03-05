import { Component, ReactNode } from "react";
import style from './style.module.css'

type DialogProp = {

}

interface IState {

}

class Dialog extends Component<DialogProp, IState> {
    constructor(props: DialogProp) {
        super(props)
    }

    render(): ReactNode {
        return <div className={style.dialog}></div>
    }
}

export default Dialog;