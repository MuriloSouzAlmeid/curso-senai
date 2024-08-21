import { ToDoListBox } from "../../components/Box/Box"
import { NewTaskButton } from "../../components/Button/Button"
import { ContainerHome, ToDoListContainer } from "../../components/Container/style"
import { NewTaskModal } from "../../components/Modal/Modal"

export const HomePage = () => {
    return (
        <ContainerHome>
            <ToDoListContainer>
                <ToDoListBox/>
                <NewTaskButton/>
            </ToDoListContainer>

            {/* <NewTaskModal/> */}
        </ContainerHome>
    )
}