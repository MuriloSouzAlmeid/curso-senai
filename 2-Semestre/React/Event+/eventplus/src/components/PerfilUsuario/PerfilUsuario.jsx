import React, { useContext } from 'react';
import './PerfilUsuario.css'

import { Link } from 'react-router-dom';

import iconeLogout from '../../assets/images/icone-logout.svg'
import { UserContext } from '../../context/AuthContext';
import { useNavigate } from 'react-router-dom';

const PerfilUsuario = () => {
    const {userData, setUserData} = useContext(UserContext);

    const navigate = useNavigate();

    const logout = () => {
        localStorage.removeItem('token');
        setUserData({})
        navigate('/')
    }

    return (
        <div className="perfil-usuario">
            {userData.nome ? (
                <>
                <span className="perfil-usuario__menuitem">{userData.nome}</span>
          
                  {/* <Link to="/" className="perfil-usuario__menuitem"> */}
                    <img
                      title="Deslogar"
                      className="perfil-usuario__icon"
                      src={iconeLogout}
                      alt="imagem ilustrativa de uma porta de saída do usuário "
                      onClick={logout}
                    />
                </>
            ) : (
                // <span className="perfil-usuario__menuitem">Login</span>
                <Link to="/login" className='perfil-usuario__menuitem'>Login</Link>
            )
            }
    </div>
    );
};

export default PerfilUsuario;