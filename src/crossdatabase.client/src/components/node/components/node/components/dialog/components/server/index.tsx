import { Resource } from '@common/models/resourceType.ts';
import Select from '@common/select';
import grid from '@common/styles/grid.module.less';
import classnames from 'classnames/bind';
import { observable } from 'mobx';
import { Component, Fragment, ReactNode } from 'react';
import { getServerType } from './helpers/resourceHelper';
import ServerStore from './store/serverStore';
import style from './style.module.css';

const cn = classnames.bind(style);

type ServerProps = {
    nid: number;
};

// @observable
class ServerDialog extends Component<ServerProps> {
    store: ServerStore;

    serverTypes: Resource[];

    constructor(props: ServerProps) {
        super(props);

        this.store = new ServerStore();
        this.serverTypes = getServerType();
    }

    async componentDidMount(): Promise<void> {
        await this.store.getData(this.props.nid);
    }

    setServerType = (type: number): void => {
        this.store.setServerType(type);
    };

    renderServerType(): ReactNode {
        return <div className={style.row}>
            <label className={cn(grid.col_5, style.label)}>Server type: </label>
            <Select items={this.serverTypes} onChange={(number) => this.setServerType(number)} className={cn(grid.col_5, style.select)} />
        </div>;
    }

    render(): ReactNode {
        return <Fragment>
            {this.renderServerType()}
            <div className={style.row}>
                <label className={cn(grid.col_5, style.label)}>Host: </label>
                <input id={`Host`} className={grid.col_10}/>
                <label className={cn(grid.col_5, style.label)}>Port :</label>
                <input id={`Port`} className={grid.col_4}/>
            </div>
        </Fragment>;
    }
}

export default ServerDialog;
