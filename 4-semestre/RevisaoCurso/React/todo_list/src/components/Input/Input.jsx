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