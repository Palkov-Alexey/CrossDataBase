import { Component, Fragment } from 'react';
import './App.css';

class App extends Component {
    constructor() {
        super();
        this.state = {
            users: []
        };
    }

    getUsers = async () => {
        let response = await fetch("api/user",
            {
                method: "get"
            })
        let result = await response.json();

        this.setState({
            users: result
        })
    }

    render() {
        const users = this.state.users.map((item, index) => <li key={index}>{item.name}</li>);

        return <Fragment>
                <button onClick={this.getUsers}>Получить сотрудников</button>
                <ul>{users}</ul>
            </Fragment>
        ;
    }
}

export default App;