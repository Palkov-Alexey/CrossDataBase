import { Component, createRef, ReactNode, RefObject } from 'react';
import { createPortal } from 'react-dom';
import { NodeType } from '../../../../enums/nodeTypes.ts';
import ServerDialog from './components/server';
import style from './style.module.css';

type DialogProp = {
    dialogType: NodeType;
    nid: number;
    visible: boolean;
    width: string;
    needCloseIcon: boolean;
    className?: string;
    onClose: () => void;
};

interface IState {
    container: boolean;
    isVisible: boolean;
}

class Dialog extends Component<DialogProp, IState> {
    ref: RefObject<HTMLDivElement>;

    constructor(props: DialogProp) {
        super(props);

        const { visible } = this.props;
        this.state = {
            container: true,
            isVisible: visible
        };

        this.ref = createRef();

        this.handleClick = this.handleClick.bind(this);
    }

    componentDidMount(): void {
        document.addEventListener(`click`, this.handleClick);
    }

    componentWillUnmount(): void {
        document.addEventListener(`click`, this.handleClick);
    }

    getDialog = (): ReactNode => {
        const { dialogType: type, nid } = this.props;

        switch (type) {
            case NodeType.Server:
                return <ServerDialog nid={nid}></ServerDialog>;
        }
    };

    handleClick(e: MouseEvent): void {
        const { target } = e;

        if (target instanceof Node && this.ref.current === target) {
            this.props.onClose();
        }
    }

    render(): ReactNode {
        const { dialogType
        } = this.props;

        return createPortal(
            <div className={style.dialog} ref={this.ref}>
                <div className={style.dialogContent}>
                    <h3>{NodeType[dialogType]}</h3>
                    {this.getDialog()}
                    <div>
                        <button type={`button`}>Save</button>
                        <button type={`button`} onClick={this.props.onClose}>Cancel</button>
                    </div>
                </div>
            </div>, document.body);
    }
}

export default Dialog;
