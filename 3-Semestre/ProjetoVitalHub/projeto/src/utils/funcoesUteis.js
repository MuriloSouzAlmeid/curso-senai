import moment from "moment"

export const ObjetoEstaVazio = (objeto) => {
    //retorna o número de chaves/propriedades que o objeto possui e verifica seu tamanho
    return (Object.keys(objeto).length === 0) ? true : false
}

export const GerarNotaClinica = () => {
    numeroAleatorio = Math.random()

    while (numeroAleatorio > 0.5 || numeroAleatorio < 0.3) {
        numeroAleatorio = Math.random()
    }

    numeroGerado = numeroAleatorio * 10

    return numeroGerado.toFixed(1)
}

export const verificarCamposFormulario = (objetoForm) => {
    let formValido = true
    const arrayForm = Object.values(objetoForm)
    arrayForm.forEach(item => {
        if (item === "") {
            formValido = false
        }
    })

    return formValido
}

export const validarData = valor => {
    // Verifica se a entrada é uma string
    // if (typeof valor !== 'string') {
    //   return false
    // }
  
    // // Verifica formado da data
    // if (!/^\d{2}\/\d{2}\/\d{4}$/.test(valor)) {
    //   return false
    // }
  
    // Divide a data para o objeto "data"
    const partesData = valor.split('/')
    const data = { 
      dia: partesData[0], 
      mes: partesData[1], 
      ano: partesData[2] 
    }
    
    // Converte strings em número
    const dia = parseInt(data.dia)
    const mes = parseInt(data.mes)
    const ano = parseInt(data.ano)
    
    // Dias de cada mês, incluindo ajuste para ano bissexto
    const diasNoMes = [ 0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 ]
  
    // Atualiza os dias do mês de fevereiro para ano bisexto
    if (ano % 400 === 0 || ano % 4 === 0 && ano % 100 !== 0) {
      diasNoMes[2] = 29
    }

    const anoMinimo = (moment().year() - 18)
    
    // Regras de validação:
    // Mês deve estar entre 1 e 12, e o dia deve ser maior que zero
    if (mes < 1 || mes > 12 || dia < 1 || ano > anoMinimo ) {
      return false
    }
    // Valida número de dias do mês
    else if (dia > diasNoMes[mes]) {
      return false
    }
    
    // Passou nas validações
    return true
  }
