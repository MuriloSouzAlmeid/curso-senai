// import moment from "moment/locale/pt-br.js";
import moment from "moment";
import "moment/locale/pt-br";
import { CreateNewTaskButton } from "../Button/Button";
import { NewTaskInput, SearchInput } from "../Input/Input";
import { ToDoList } from "../List/List";
import { Title } from "../Text/Text";
import "./style.css";
import { useState } from "react";

export const ToDoListBox = ({ data }) => {
  moment.locale("pt-br");

  return (
    <div className="todolist-box__box">
      <Title>
        <span style={{ textTransform: "capitalize" }}>
          {moment().format("dddd")},{" "}
        </span>
        <span style={{ color: "#8758FF", fontFamily: "Roboto Bold" }}>
          {moment().day()}{" "}
        </span>
        de{" "}
        <span style={{ textTransform: "capitalize" }}>
          {moment().format("MMMM")}
        </span>
      </Title>
      <SearchInput />
      <ToDoList toDoListArray={data} />
    </div>
  );
};

export const NewTaskModalBox = ({ data, closeModal }) => {
  const [taskDescription, setTaskDescription] = useState("");

  const AddTask = () => {
    data.push({ checked: false, description: taskDescription });
    closeModal();
  };

  return (
    <div className="newtask-modal-box">
      <Title>Descreva sua tarefa</Title>
      <NewTaskInput setDescription={setTaskDescription} />
      <CreateNewTaskButton onClick={() => AddTask()} />
    </div>
  );
};
