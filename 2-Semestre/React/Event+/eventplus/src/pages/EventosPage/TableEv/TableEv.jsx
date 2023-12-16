import React from "react";
import '../TableEv/TableEv.css';

//import dos ícones
import trashIcon from "../../../assets/images/trash-delete.svg";
import editIcon from "../../../assets/images/edit-pen.svg";
import detalhesIcon from "../../../assets/images/detail-icon.svg";

//import das funções transformadoras
import { dateFormatDbToView } from "../../../Utils/stringFunctions";
import { Tooltip } from "react-tooltip";

const TableEv = ({ dados, fnDelete, fnUpdate, carregarDetalhes = null }) => {
  return (
    <table className="table-data">
      <thead className="table-data__head">
        <tr className="table-data__head-row">
          <th className="table-data__head-title table-data__head-title--big">
            Evento
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Descrição
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Tipo Evento
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Data
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Detalhes
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Editar
          </th>
          <th className="table-data__head-title table-data__head-title--little">
            Excluir
          </th>
        </tr>
      </thead>

      <tbody className="table-data__body">
        {dados.map((dado) => {
          return (
            <tr key={dado.idEvento} className="table-data__head-row">
              <td className="table-data__data table-data__data--big">
                {dado.nomeEvento}
              </td>
              <td className="table-data__data table-data__data--little">
                <p
                  data-tooltip-id={dado.idEvento}
                  data-tooltip-content={dado.descricao}
                  data-tooltip-place="top"
                >
                  <Tooltip id={dado.idEvento} className="custom-tootip" />
                  {dado.descricao.substr(0, 14)}...
                </p>
              </td>
              <td className="table-data__data table-data__data--little">
                {dado.tiposEvento.titulo}
              </td>
              <td className="table-data__data table-data__data--little">
                {dateFormatDbToView(dado.dataEvento)}
              </td>
              <td className="table-data__data table-data__data--little">
                <img
                  className="table-data__icon"
                  src={detalhesIcon}
                  alt=""
                  onClick={() => {
                    carregarDetalhes(dado.idEvento);
                  }}
                />
              </td>
              <td className="table-data__data table-data__data--little">
                <img
                  className="table-data__icon"
                  src={editIcon}
                  alt=""
                  onClick={() => {
                    fnUpdate(dado);
                  }}
                />
              </td>
              <td className="table-data__data table-data__data--little">
                <img
                  src={trashIcon}
                  alt=""
                  className="table-data__icon"
                  onClick={() => {
                    fnDelete(dado.idEvento);
                  }}
                />
              </td>
            </tr>
          );
        })}
      </tbody>
    </table>
  );
};

export default TableEv;
