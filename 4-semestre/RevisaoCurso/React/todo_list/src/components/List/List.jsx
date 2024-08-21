import CheckedIcon from "../../assets/icons/checked-icon.svg";
import DeleteIconBlack from "../../assets/icons/delete-icon.svg";
import UpdateIconBlack from "../../assets/icons/update-icon.svg";
import DeleteIconWhite from "../../assets/icons/delete-icon-white.svg";
import UpdateIconWhite from "../../assets/icons/update-icon-white.svg";

import "./style.css";

export const ToDoList = ({ toDoListArray = [
    {checked: false, description: "Começar a execução de um projeto"},
    {checked: true, description: "Começar a execução de um projeto"},
    {checked: false, description: "Começar a execução de um projeto"},
    {checked: false, description: "Começar a execução de um projeto"},
    {checked: false, description: "Começar a execução de um projeto"},
    {checked: true, description: "Começar a execução de um projeto"},
    {checked: false, description: "Começar a execução de um projeto"}
] }) => {
    return (
        <div className="list__container">
            {toDoListArray.map(task =>
                <div className={`${task.checked ? "list__element--checked" : "list__element"}`}>
                    <div className="list__element__description">
                        <button className="list__element__description__checkbox">
                            {task.checked ? (
                                <img className="list__element__description__checkbox__checked-icon" src={CheckedIcon} />
                            ) : null}
                        </button>
                        <p className="list__element__description__text">
                            {task.description}
                        </p>
                    </div>
                    <div className="list__element__actions">
                        <button className="list__element__actions__delete" >
                            <img className="list__element__actions__image" src={task.checked ? DeleteIconWhite : DeleteIconBlack} />
                        </button>
                        <button className="list__element__actions__update" >
                            <img className="list__element__actions__image" src={task.checked ? UpdateIconWhite : UpdateIconBlack} />
                        </button>
                    </div>
                </div>)
            }
        </div>
    )
}