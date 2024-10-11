import { useEffect, useState } from "react";
import { ToDoListBox } from "../../components/Box/Box";
import { NewTaskButton } from "../../components/Button/Button";
import {
  ContainerHome,
  ToDoListContainer,
} from "../../components/Container/style";
import { NewTaskModal } from "../../components/Modal/Modal";

export const HomePage = () => {
  const [showModal, setShowModal] = useState(false);
  const [editModal, setEdiModal] = useState(false);
  const [index, setIndex] = useState(null);
  const [searchText, setSearchText] = useState("")

  const [todoListArray, setTodoListArray] = useState([]);
  const [taskSearch, setTaskSearch] = useState([]);
  const [descriptionEdit, setDescriptionEdit] = useState("")

  const ResetModal = () => {
    setShowModal(false);
    setEdiModal(false);
    setIndex(null);
    setDescriptionEdit("");
  }

  const AddTask = (taskDescription) => {
    setTodoListArray([
      ...todoListArray,
      {
        description: taskDescription,
        checked: false,
      },
    ]);

    setShowModal(false);
  };

  const CheckTask = (index, value) => {
    const auxArray = todoListArray;
    auxArray[index].checked = value;
    setTodoListArray([...auxArray]);
  };

  const UpdateTask = (index, value) => {
    const auxArray = todoListArray;
    auxArray[index].description = value;
    setTodoListArray([...auxArray]);

    ResetModal()
  };

  const DeleteTask = (index) => {
    const auxArray = todoListArray.filter(
      (task) => task !== todoListArray[index]
    );

    setTodoListArray(auxArray);
  };

  const OpenModalEdit = (index, description) => {
    setEdiModal(true);
    setShowModal(true);
    setIndex(index);
    setDescriptionEdit(description)
  };

  const SearchTask = (descriptionTask) => {
    if (descriptionTask === "") {
      setTaskSearch([]);
    } else {
      const auxArray = todoListArray.filter(
        (task) => task.description === descriptionTask
      );
      setTaskSearch([...auxArray]);
    }
  };

  useEffect(() => {
    setTodoListArray(todoListArray);
  }, [todoListArray, showModal, taskSearch.length]);

  useEffect(() => {
    if(searchText === ""){
        setTaskSearch([])
    }else{
        
    }
  }, [searchText])

  return (
    <ContainerHome>
      <ToDoListContainer>
        <ToDoListBox
          setSearchText={setSearchText}
          searchText={searchText}
          searchTask={SearchTask}
          openModalUpdate={OpenModalEdit}
          updateTask={UpdateTask}
          deleteTask={DeleteTask}
          checkTask={CheckTask}
          data={taskSearch.length !== 0 ? taskSearch : todoListArray}
        />
        <NewTaskButton onClick={() => setShowModal(true)} />
      </ToDoListContainer>

      <NewTaskModal
        descriptionEdit={descriptionEdit}
        index={index}
        editModal={editModal}
        addTask={AddTask}
        updateTask={UpdateTask}
        toDoListArray={todoListArray}
        showModal={showModal}
        closeModal={ResetModal}
      />
    </ContainerHome>
  );
};
