import { React, useContext, useEffect, useState } from "react";
import ImageIllustrator from "../../components/ImageIllustrator/ImageIllustrator";
import loginImage from "../../assets/images/login.svg";
import logo from "../../assets/images/logo-pink.svg";
import { Input, Button } from "../../components/FormComponents/FormComponents";
import Notification from '../../components/Notification/Notification';
import api from "../../services/Service";

import "./LoginPage.css";
import { UserTokenDecoder, UserContext } from "../../context/AuthContext";
import { useNavigate } from "react-router-dom";
import { ActivatedPage } from "../../context/ActivatedPage";

const LoginPage = () => {
  const {setActivatedPage} = useContext(ActivatedPage);

  const {userData, setUserData} = useContext(UserContext);

  const [user, setUser] = useState({
    email: "",
    senha: "",
  });

  const navigate = useNavigate();

  const [notifyUser, setNotifyUser] = useState({})

  useEffect(() => {
    setActivatedPage('login')

    if(userData.nome) navigate('/');
  }, 
  //devemos colocar o userData como dependência para observar qualquer alteração no mesmo
  [userData])

  async function handleSubmit(e) {
    e.preventDefault();

    if (user.email.length <= 3 && user.senha.length <= 3) {
      alert("Dados preenchidos inválidos");
      return;
    }

    try {
      const promisse = await api.post(
        "/Login",
        {
          email: user.email,
          senha: user.senha,
        }
        //user
      );

      setNotifyUser({
        titleNote: "Usuário Logado Com Sucesso",
        textNote: `O Login foi efetuado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true
      })

      const userFullToken = UserTokenDecoder(promisse.data.token);
      setUserData(userFullToken); //guarda os dados que foram decodificados no escopo global

      console.log('DADOS DO USUÁRIO');
      console.log(userData);

      localStorage.setItem('token', JSON.stringify(userFullToken))//transforma o objeto em json

      navigate('/') //redireciona para a página home 

    } catch (error) {
      setNotifyUser({
        titleNote: "Erro ao se logar com o usuário",
        textNote: `Usuário ou senhas incorretos`,
        imgIcon: "warning",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true
      })
      console.log(error);
    }

    setUser({email:'', senha:''});
  }

  return (
    <div className="layout-grid-login">
      <div className="login">
        <div className="login__illustration">
          <div className="login__illustration-rotate"></div>
          <ImageIllustrator
            imageRender={loginImage}
            altText="Imagem de um homem em frente de uma porta de entrada"
            additionalClass="login-illustrator "
          />
        </div>

        <div className="frm-login">
          <img src={logo} className="frm-login__logo" alt="" />

          <form className="frm-login__formbox" onSubmit={handleSubmit}>
            <Input
              additionalClass="frm-login__entry"
              type="email"
              id="login"
              name="login"
              required={true}
              value={user.email}
              manipulationFunction={(e) => {
                setUser({
                  //restOperator
                  ...user,
                  email: e.target.value.trim(),
                });
              }}
              placeholder="Username"
            />
            <Input
              additionalClass="frm-login__entry"
              type="password"
              id="senha"
              name="senha"
              required={true}
              value={user.senha}
              manipulationFunction={(e) => {
                setUser({
                  //restOperator
                  ...user,
                  senha: e.target.value.trim(),
                });
              }}
              placeholder="****"
            />

            <a href="https://www.kabum.com.br/" className="frm-login__link">
              Esqueceu a senha?
            </a>

            <Button
              textButton="Login"
              id="btn-login"
              name="btn-login"
              type="submit"
              additionalClass="frm-login__button"
            />
          </form>
        </div>
      </div>

      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
    </div>
  );
};

export default LoginPage;
