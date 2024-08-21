import { NewTaskModalBox } from "../Box/Box"
import { ContainerModal } from "../Container/style"
import { Title } from "../Text/Text"

export const NewTaskModal = ({toDoListArray}) => {
    return(
        <ContainerModal>
            <NewTaskModalBox/>
        </ContainerModal>
    )
}