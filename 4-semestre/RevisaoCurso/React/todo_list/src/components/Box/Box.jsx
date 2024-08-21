// import moment from "moment/locale/pt-br.js";
import { CreateNewTaskButton } from "../Button/Button";
import { SearchInput } from "../Input/Input"
import { ToDoList } from "../List/List";
import { Title } from "../Text/Text";
import "./style.css"

export const ToDoListBox = () => {
    return (
        <div className="todolist-box__box">
            {/* <Title>{moment().locale()}</Title> */}
            <Title>Quarta-Feira, 21 de Agosto</Title>
            <SearchInput/>
            <ToDoList/>
        </div>
    )
}

export const NewTaskModalBox = () => {
    return(
        <div className="newtask-modal-box">
            <Title>Descreva sua tarefa</Title>
            {/* <NewTaskInput/> */}
            <CreateNewTaskButton/>
        </div>
    )
}