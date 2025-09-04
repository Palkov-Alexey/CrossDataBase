import { Component } from "react";
import DropdownButton from "../../../common/dropdownButton/dropdownButton.js";

class File extends Component {
    constructor() {
        super();
    }

    render() {
        return (
            <DropdownButton name="File" elements={[{name:"Preference"}]}></DropdownButton>
        )
    }
}

export default File;