import React from 'react';
import './NextEvent.css';

const NextEvent = ({title, description, eventDate, idEvento}) => {
    //função que recebe o evento a se conectar pela api
    function conectar (idEvento){
        alert(`Deu certo Aqui. Conetado ao Evento: ${idEvento}`)
    }

    return (
        <article className='event-card'>
            <h2 className="event-card__title">{title}</h2>

            <p className='event-card__description'>{description}</p>
            <p className='event-card__description'>{eventDate}</p>
            
            <a 
                onClick={() => {
                    conectar(idEvento);
                }}
                href="" className='event-card__connect-link'
            >
                Conectar
            </a>
        </article>
    );
};

export default NextEvent;