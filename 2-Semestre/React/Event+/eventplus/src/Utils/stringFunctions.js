/**
 * Função que inverte a data do banco de dados
 * @param {*} data
 * @returns
 */

export const dateFormatDbToView = (data) => {
    // EX: 2023-12-10T00:00:00 para 10/12/2023
    data = data.substr(0, 10).split("-"); // retorna apenas a data (2023-10-12)
    // data = data.split("-"); // retorna um array [2023,10,12]
  
    return `${data[2]}/${data[1]}/${data[0]}`; //retorna  12/10/2023
  };

  export const dateFormatDbToDateValue = (data) => {
    // EX: 2023-12-10T00:00:00 para 10/12/2023
    return data.substr(0, 10)
  }