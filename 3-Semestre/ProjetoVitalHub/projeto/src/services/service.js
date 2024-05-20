import axios from "axios";

// const ip = "192.168.1.12";
const ip = "192.168.21.95";

const portaApi = "4466";

const apiUrlLocal = `http://${ip}:${portaApi}/api`;

export const api = axios.create({
    baseURL: apiUrlLocal
})

const viaCepUrl = `https://viacep.com.br/ws/`

export const apiViaCep = axios.create({
    baseURL: viaCepUrl
})

