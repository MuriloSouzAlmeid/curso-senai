import "./style.css"

export const NewTaskButton = ({onClick}) => {
    return(
        <button className="new-task-button" onClick={onClick}>
            Nova Tarefa
        </button>
    )
}

export const CreateNewTaskButton = ({onClick}) => {
    return(
        <button className="crate-new-task-button" onClick={onClick}>
            Confirmar tarefa
        </button>
    )
}