import { ToDoListBox } from "../../components/Box/Box"
import { ContainerHome, ToDoListContainer } from "../../components/Container/style"

export const HomePage = () => {
    return (
        <ContainerHome>
            <ToDoListContainer>
                <ToDoListBox />
            </ToDoListContainer>
        </ContainerHome>
    )
}