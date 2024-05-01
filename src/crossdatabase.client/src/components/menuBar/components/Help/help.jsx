import { Component } from "react";
import DropdownButton from "../../../common/dropdownButton/dropdownButton";

class Help extends Component {
    constructor() {
        super();
    }

    render() {
        return (
            <DropdownButton name="Help" elements={[{name:"About"}]}></DropdownButton>
        )
    }
}

export default Help;