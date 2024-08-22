import { SearchIcon } from "../Icon/Icon"
import "./style.css"

export const SearchInput = () => {
    return(
        <div className="search-input__box">
            <SearchIcon/>
            <input className="search-input__field" placeholder="Buscar tarefa" type="text"/>
        </div>
    )
}

export const NewTaskInput = ({setDescription}) => {
    return(
        <textarea className="newtask-input" onChange={(e) => setDescription(e.target.value)} placeholder="Digite aqui sua nova tarefa..."></textarea>
    )
}