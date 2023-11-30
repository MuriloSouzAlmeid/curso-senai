import { jwtDecode } from 'jwt-decode';
import {createContext} from 'react';

export const UserContext = createContext(null);

//método que recebe o token e instancia um objeto em javascript com as informações do token que serão usadas
export const UserTokenDecoder = (token) => {
    const decoded = jwtDecode(token); //aqui retorna o payload do jwt

    return {
        perfil: decoded.role,
        nome: decoded.name,
        email: decoded.email,
        userId: decoded.jti,
        token: token
    }
}