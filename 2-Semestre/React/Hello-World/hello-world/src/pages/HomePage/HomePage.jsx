import React, {useEffect, useState} from "react";
import './HomePage.css';

const HomePage = () => {
    const [contador, setContador] = useState(0);

    useEffect(() =>{
        setContador(contador + 1)
        console.log('teste')
    });

    return(
        <div>
            <h1>Página Home</h1>
        </div>
    )
}

export default HomePage;