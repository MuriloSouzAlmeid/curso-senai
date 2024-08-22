import { useState } from "react"
import { ToDoListBox } from "../../components/Box/Box"
import { NewTaskButton } from "../../components/Button/Button"
import { ContainerHome, ToDoListContainer } from "../../components/Container/style"
import { NewTaskModal } from "../../components/Modal/Modal"

export const HomePage = () => {
    const [showModal, setShowModal] = useState(false);

    const [todoListArray, setTodoListArray] = useState([
        {checked: false, description: "Começar a execução de um projeto"}
    ])

    return (
        <ContainerHome>
            <ToDoListContainer>
                <ToDoListBox data={todoListArray}/>
                <NewTaskButton onClick={() => setShowModal(true)}/>
            </ToDoListContainer>

            <NewTaskModal toDoListArray={todoListArray} showModal={showModal} setShowModal={setShowModal}/>
        </ContainerHome>
    )
}