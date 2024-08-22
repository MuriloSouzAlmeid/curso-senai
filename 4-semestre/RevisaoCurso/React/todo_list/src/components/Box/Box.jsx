// import moment from "moment/locale/pt-br.js";
import moment from "moment";
import "moment/locale/pt-br";
import { CreateNewTaskButton } from "../Button/Button";
import { NewTaskInput, SearchInput } from "../Input/Input";
import { ToDoList } from "../List/List";
import { Title } from "../Text/Text";
import "./style.css";
import { useState } from "react";

export const ToDoListBox = ({ data, checkTask, deleteTask, openModalUpdate }) => {
  moment.locale("pt-br");

  return (
    <div className="todolist-box__box">
      <Title>
        <span style={{ textTransform: "capitalize" }}>
          {moment().format("dddd")},{" "}
        </span>
        <span style={{ color: "#8758FF", fontFamily: "Roboto Bold" }}>
          {moment().format("DD")}{" "}
        </span>
        de{" "}
        <span style={{ textTransform: "capitalize" }}>
          {moment().format("MMMM")}
        </span>
      </Title>
      <SearchInput />
      <ToDoList openModalUpdate={openModalUpdate} checkTask={checkTask} deleteTask={deleteTask} toDoListArray={data} />
    </div>
  );
};

export const NewTaskModalBox = ({addTask, updateTask, editModal }) => {
  const [taskDescription, setTaskDescription] = useState("");

  return (
    <div className="newtask-modal-box">
      <Title>{editModal ? "Descreva sua nova tarefa" : "Descreva sua tarefa"}</Title>
      <NewTaskInput setDescription={setTaskDescription} />
      <CreateNewTaskButton editModal={editModal} onClick={editModal ? () => updateTask(index, taskDescription) : () => addTask(taskDescription) }/>
    </div>
  );
};
