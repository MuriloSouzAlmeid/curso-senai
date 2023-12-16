import React, { useEffect, useState } from "react";
import trashDelete from "../../assets/images/trash-delete-red.png";

import { Button, Input } from "../FormComponents/FormComponents";
import "./Modal.css";

const Modal = (
    {

        modalTitle = "Feedback",
        comentaryText = "Não informado. Não informado. Não informado.",
        userId = null,
        eventId = null,
        showHideModal = false,
        fnDelete = null,
        fnPost = null,
        fnGet = null,
        idComentario = null
    }
) => {
    const [descricaoComentario, setDescricaoComentario] = useState("");

    useEffect(() => {
      carregarComentario();
    }, [])

    const carregarComentario = async () => {
      await fnGet(userId, eventId);
    }

    return (
        <div className="modal">
      <article className="modal__box">
        
        <h3 className="modal__title">
          {modalTitle}
          <span className="modal__close" onClick={() => {
            showHideModal(null)
          }}>x</span>
        </h3>

        <div className="comentary">
          <h4 className="comentary__title">Comentário</h4>
          <img
            src={trashDelete}
            className="comentary__icon-delete"
            alt="Ícone de uma lixeira"
            onClick={ async () => {
              await fnDelete(idComentario, eventId, userId);
            }}
          />

          <p className="comentary__text">{comentaryText}</p>

          <hr className="comentary__separator" />
        </div>

        <Input
          placeholder={ idComentario === "" ? "Escreva seu comentário..." : "Só é possível escrever um comentário por evento"}
          additionalClass={`comentary__entry ${idComentario === "" ? "" : "comentary__entry--blocked"}`}
          value={idComentario === "" ? descricaoComentario : ""}
          manipulationFunction={(e) => {
            if(idComentario === ""){
              setDescricaoComentario(e.target.value)
            }else{
              setDescricaoComentario("")
            }
          }}
        />

        <Button
          textButton="Comentar"
          additionalClass="comentary__button"
          manipulationFunction={ async () => {
            await fnPost(descricaoComentario, eventId, userId, idComentario)
          }}
        />
      </article>
    </div>
    );
};

export default Modal;