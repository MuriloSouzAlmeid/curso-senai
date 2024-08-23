import { useState } from "react"
import { SearchIcon } from "../Icon/Icon"
import "./style.css"

export const SearchInput = ({searchTask, setSearchText, searchText}) => {
    return(
        <div className="search-input__box">
            <SearchIcon onClick={() => searchTask(searchText)}/>
            <input className="search-input__field" placeholder="Buscar tarefa" type="text" value={searchText} onChange={(e) => setSearchText(e.target.value)}/>
        </div>
    )
}

export const NewTaskInput = ({setDescription, descriptionEdit = ""}) => {
    return(
        <textarea className="newtask-input" onChange={(e) => setDescription(e.target.value)} placeholder="Digite aqui sua nova tarefa...">
            {descriptionEdit}
        </textarea>
    )
}