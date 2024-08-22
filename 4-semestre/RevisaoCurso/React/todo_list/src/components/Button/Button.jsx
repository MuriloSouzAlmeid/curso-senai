import "./style.css"

export const NewTaskButton = ({onClick}) => {
    return(
        <button className="new-task-button" onClick={onClick}>
            Nova Tarefa
        </button>
    )
}

export const CreateNewTaskButton = ({onClick, editModal}) => {
    return(
        <button className="crate-new-task-button" onClick={onClick}>
            {editModal ? "Atualizar tarefa" : "Confirmar tarefa"}
        </button>
    )
}