import { Resource } from '@common/models/resourceType.ts';
import Select from '@common/select';
import grid from '@common/styles/grid.module.less';
import classnames from 'classnames/bind';
import { observer } from 'mobx-react';
import { Component, Fragment, ReactNode } from 'react';
import { AuthType } from './enum/authType.ts';
import { ServerType } from './enum/serverType.ts';
import { getAuthType, getServerType } from './helpers/resourceHelper';
import ServerStore from './store/serverStore';
import style from './style.module.css';

const cn = classnames.bind(style);

type ServerProps = {
    nid: number;
};

@observer
class ServerDialog extends Component<ServerProps> {
    store: ServerStore;

    serverTypes: Resource[];

    authTypes: Resource[];

    constructor(props: ServerProps) {
        super(props);

        this.store = new ServerStore();
        this.serverTypes = getServerType();
        this.authTypes = getAuthType();
    }

    async componentDidMount(): Promise<void> {
        await this.store.getData(this.props.nid);
    }

    setServerType = (type: number): void => {
        this.store.setServerType(type);
    };

    setAuthType = (type: number): void => {
        this.store.setAuthType(type);
    };

    setHost = (host: string): void => {
        this.store.setHost(host);
    };

    setPort = (port: string): void => {
        this.store.setPort(port);
    };

    setInstance = (instance: string): void => {
        this.store.setInstance(instance);
    };

    setLogin = (login: string): void => {
        this.store.setLogin(login);
    };

    setPassword = (password: string): void => {
        this.store.setPassword(password);
    };

    renderServerType(): ReactNode {
        const { serverType } = this.store.data;
        
        return <div className={style.row}>
            <label className={cn(grid.col_5, style.label)}>Server type:</label>
            <Select items={this.serverTypes}
                onChange={(number) => this.setServerType(number)}
                selectedItem={this.serverTypes.find(x => x.value === serverType)?.value}
                className={cn(grid.col_5, style.select)}/>
        </div>;    
    }
    
    renderInstance(instance: string): ReactNode {
        const { serverType } = this.store.data;
        
        if (serverType === ServerType.MSSQL) {
            return <div className={style.row}>
                <label className={cn(grid.col_5, style.label)}>Instance:</label>
                <input id={`Instance`} className={grid.col_19} value={instance} onChange={(e) => this.setInstance(e.target.value)}/>
            </div>;
        }
        
        return null;
    }

    renderAuth(): ReactNode {
        const { serverType, authType } = this.store.data;

        if (serverType === ServerType.MSSQL) {
            return <Select items={this.authTypes}
                onChange={(number) => this.setAuthType(number)}
                selectedItem={this.authTypes.find(x => x.value === authType)?.value}
                className={cn(grid.col_5, style.select)}/>;
        }
        
        return <label className={cn(grid.col_19, style.label)}>{this.authTypes[1].text}</label>;
    }

    renderLoginAndPassword(login: string, password: string): ReactNode {
        const { authType } = this.store.data;

        if (authType === AuthType.UserAndPass) {
            return <Fragment>
                <div className={style.row}>
                    <label className={cn(grid.col_5, style.label)}>User:</label>
                    <input id={`User`} className={grid.col_10} value={login} onChange={(e) => this.setLogin(e.target.value)}/>
                </div>
                <div className={style.row}>
                    <label className={cn(grid.col_5, style.label)}>Password:</label>
                    <input id={`Password`} className={grid.col_10} type={`password`} value={password} onChange={(e) => this.setPassword(e.target.value)}/>
                </div>
            </Fragment>;
        }

        return null;
    }

    render(): ReactNode {
        const { host, port, instance, login, password } = this.store.data;
        
        return <Fragment>
            {this.renderServerType()}
            <div className={style.row}>
                <label className={cn(grid.col_5, style.label)}>Host:</label>
                <input id={`Host`} className={grid.col_10} value={host} onChange={(e) => this.setHost(e.target.value)}/>
                <label className={cn(grid.col_5, style.label)}>Port:</label>
                <input id={`Port`} className={grid.col_4} type={`number`} value={port} onChange={(e) => this.setPort(e.target.value)}/>
            </div>
            {this.renderInstance(instance)}
            <div className={style.row}>
                <label className={cn(grid.col_5, style.label)}>Authentication:</label>
                {this.renderAuth()}
            </div>
            {this.renderLoginAndPassword(login, password)}
            <div className={style.row}>
                <label className={cn(grid.col_5, style.label)}>Database:</label>
                <input id={`Database`} className={grid.col_10}/>
            </div>
            <div className={style.row}>
                <button className={grid.col_10} type={`button`}>Test connection</button>
                <label className={grid.col_10}/>
            </div>
        </Fragment>;    
    }
}

export default ServerDialog;
