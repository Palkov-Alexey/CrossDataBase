import { Resource } from '@common/models/resourceType.ts';
import { Component, Fragment, ReactNode } from 'react';

type SelectProps = {
    items: Resource[];
    selectedItem: number | undefined;
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

    renderOptions = (resource: Resource, selectedItem: number | undefined, index: number): ReactNode => {
        const isSelected = selectedItem !== undefined ? selectedItem === resource.value : index === 0;

        return <option value={resource.value} selected={isSelected}>{resource.text}</option>;
    };

    render(): ReactNode {
        const { items, className, selectedItem } = this.props;

        return <Fragment>
            <select onChange={(e) => this.onChange(Number(e.target.value))} className={className}>
                {items.map((x, i) =>  this.renderOptions(x, selectedItem, i++))}
            </select>
        </Fragment>;
    }
}

export default Select;
