import { jwtDecode } from 'jwt-decode';
import React, {createContext} from 'react';

export const UserContext = createContext(null);

export const UserTokenDecoder = (token) => {
    const decoded = jwtDecode(token); //aqui vem o payload do jwt

    return {
        perfil: decoded.role,
        nome: decoded.name,
        email: decoded.email,
        userId: decoded.jti,
        token: token
    }
}