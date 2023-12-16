import React from "react";
import { dateFormatDbToView } from "../../Utils/stringFunctions";
import { Tooltip } from "react-tooltip";
import "./NextEvent.css";

const NextEvent = ({ title, description, eventDate, idEvento, carregarDetalhes = null }) => {
  //função que recebe o evento a se conectar pela api
  function conectar(idEvento) {
    alert(`Deu certo Aqui. Conetado ao Evento: ${idEvento}`);
  }

  return (
    <article className="event-card">
      <h2 className="event-card__title">{title}</h2>

      <p
        className="event-card__description"
        data-tooltip-id={idEvento}
        data-tooltip-content={description}
        data-tooltip-place="top"
      >
        <Tooltip id={idEvento} />
        {description.substr(0, 16)}...
      </p>
      <p className="event-card__description">{dateFormatDbToView(eventDate)}</p>
      {/* <p className="event-card__description">{new Date(eventDate).toLocaleDateString()</p> */}

      <p
        onClick={() => {
          carregarDetalhes(idEvento);
        }}
        className="event-card__connect-link"
      >
        Detalhes
      </p>
    </article>
  );
};

export default NextEvent;
