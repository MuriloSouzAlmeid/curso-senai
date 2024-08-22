import CheckedIcon from "../../assets/icons/checked-icon.svg";
import DeleteIconBlack from "../../assets/icons/delete-icon.svg";
import UpdateIconBlack from "../../assets/icons/update-icon.svg";
import DeleteIconWhite from "../../assets/icons/delete-icon-white.svg";
import UpdateIconWhite from "../../assets/icons/update-icon-white.svg";

import "./style.css";

export const ToDoList = ({ toDoListArray }) => {
    return (
        <div className="list__container">
            {toDoListArray.map((task, index) =>
                <div key={index} className={`${task.checked ? "list__element--checked" : "list__element"}`}>
                    <div className="list__element__description">
                        <button className="list__element__description__checkbox">
                            {task.checked ? (
                                <img className="list__element__description__checkbox__checked-icon" src={CheckedIcon} alt="ícone de check"/>
                            ) : null}
                        </button>
                        <p className="list__element__description__text">
                            {task.description}
                        </p>
                    </div>
                    <div className="list__element__actions">
                        <button className="list__element__actions__delete" >
                            <img className="list__element__actions__image" src={task.checked ? DeleteIconWhite : DeleteIconBlack} alt="ícone da letra x" />
                        </button>
                        <button className="list__element__actions__update" >
                            <img className="list__element__actions__image" src={task.checked ? UpdateIconWhite : UpdateIconBlack} alt="ícone de um lápis" />
                        </button>
                    </div>
                </div>)
            }
        </div>
    )
}