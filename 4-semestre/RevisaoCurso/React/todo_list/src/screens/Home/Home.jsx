import { useEffect, useState } from "react"
import { ToDoListBox } from "../../components/Box/Box"
import { NewTaskButton } from "../../components/Button/Button"
import { ContainerHome, ToDoListContainer } from "../../components/Container/style"
import { NewTaskModal } from "../../components/Modal/Modal"

export const HomePage = () => {
    const [showModal, setShowModal] = useState(false);
    const [editModal, setEdiModal] = useState(false);
    const [index, setIndex] = useState(null);

    const [todoListArray, setTodoListArray] = useState([]);
    const [taskSearch, setTaskSearch] = useState(null)

    const AddTask = (taskDescription) => {
        setTodoListArray([...todoListArray,
        {
            description: taskDescription,
            checked: false
        }])

        setShowModal(false)
    }
 
    const CheckTask = (index, value) => {
        const auxArray = todoListArray;
        auxArray[index].checked = value;
        setTodoListArray(auxArray);
    }


    const UpdateTask = (index, value) => {
        const auxArray = todoListArray;
        auxArray[index].description = value;
        setTodoListArray(auxArray);
    }


    const DeleteTask = (index) => {
        const auxArray = todoListArray.filter(
            task => task != todoListArray[index]
        )

        setTodoListArray(auxArray)
    }

    const OpenModalEdit = (index) => {
        setEdiModal(true)
        setShowModal(true)
    }

 
    const SearchTask = (descriptionTask) => {
        const auxArray = todoListArray.filter( 
            task => task.description == descriptionTask
        )
        setTaskSearch(auxArray[0])
    }  


    useEffect(() => {
        setTodoListArray(todoListArray)
    }, [todoListArray, showModal])
 
    return ( 
        <ContainerHome>
            <ToDoListContainer>
                <ToDoListBox openModalUpdate={OpenModalEdit} updateTask={UpdateTask} deleteTask={DeleteTask} checkTask={CheckTask} data={todoListArray} />
                <NewTaskButton onClick={() => setShowModal(true)} />
            </ToDoListContainer>

            <NewTaskModal editModal={editModal} addTask={AddTask} updateTask={UpdateTask} toDoListArray={todoListArray} showModal={showModal} setShowModal={setShowModal} />
        </ContainerHome>
    )
}