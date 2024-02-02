import axios from "axios";

const externalUrl = 'https://brasilaberto.com/api/v1/zipcode/'
const internalUrl = 'http://localhost:300/cep/'

export const api = axios.create({
    baseURL: externalUrl
});