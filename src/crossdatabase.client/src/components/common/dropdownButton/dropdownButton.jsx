import { Component } from 'react';
import PropTypes from 'prop-types';
import './style.less'
import { Dropdown } from 'react-bootstrap';

class DropdownButton extends Component {
    constructor(props) {
        super(props);
        this.name = props.name,
        this.elements = props.elements
    }

    render() {
        let items = this.elements.map((x, i) => <Dropdown.Item key={i}>{x.name}</Dropdown.Item>)

        return (
            <Dropdown>
                <Dropdown.Toggle>{this.name}</Dropdown.Toggle>

                <Dropdown.Menu>
                    {items}
                </Dropdown.Menu>
            </Dropdown>
        );
    }
}


DropdownButton.propTypes = {
    name: PropTypes.string,
    elements: PropTypes.arrayOf(PropTypes.shape({
        name: PropTypes.string,
        //Action: PropTypes.func
    })).isRequired
};

export default DropdownButton;