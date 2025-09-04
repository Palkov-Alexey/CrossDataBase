import { Component, ReactNode } from 'react';
import { Dropdown } from 'react-bootstrap';
import './style.less';
import { Resource } from '../models/resourceType.ts';

type DropdownProp = {
    name: string,
    elements: Resource[]
};

class DropdownButton extends Component<DropdownProp> {
    constructor(props: DropdownProp) {
        super(props);
    }

    render(): ReactNode {
        const items = this.props.elements.map((x, i) => <Dropdown.Item key={i}>{x.text}</Dropdown.Item>);

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

export default DropdownButton;
