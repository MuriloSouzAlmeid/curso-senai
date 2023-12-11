import axios from "axios";

//const apiPort = "5000";
//const localApi = `http://localhost:${apiPort}/api`;
const externalApi = "https://eventmurilosouza-api.azurewebsites.net/api";

const api = axios.create({
    baseURL : externalApi
})

export default api;