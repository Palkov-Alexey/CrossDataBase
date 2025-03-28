import { Resource } from '@common/models/resourceType.ts';
import { Component, Fragment, ReactNode } from 'react';

type SelectProps = {
    items: Resource[];
    onChange: (target: number) => void;
    className: string;
};

class Select extends Component<SelectProps> {
    constructor(props: SelectProps) {
        super(props);
    }
    
    onChange = (value: number): void => {
        this.props.onChange(value);
    };

    renderOptions = (resource: Resource, index: number): ReactNode => {
        return <option value={resource.value} selected={index === 0}>{resource.text}</option>;
    };

    render(): ReactNode {
        const { items, className } = this.props;

        return <Fragment>
            <select onChange={(e) => this.onChange(Number(e.target.value))} className={className}>
                {items.map((x, i) =>  this.renderOptions(x, i++))}
            </select>
        </Fragment>;
    }
}

export default Select;
