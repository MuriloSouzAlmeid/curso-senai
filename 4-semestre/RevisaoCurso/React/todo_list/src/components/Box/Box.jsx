import { SearchInput } from "../Input/Input"
import { Title } from "../Text/Text";
import moment from "moment";
import "./style.css"

export const ToDoListBox = () => {
    return (
        <div className="todolist-box__box">
            <Title>{moment()}</Title>
            <SearchInput/>
        </div>
    )
}