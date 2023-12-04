import React, { useContext } from "react";
import { Link } from "react-router-dom";
import "./Navbar.css";

import logoMobile from "../../assets/images/logo-white.svg";
import logoDesktop from "../../assets/images/logo-pink.svg";
import { UserContext } from "../../context/AuthContext";
import { ActivatedPage } from "../../context/ActivatedPage";

const Navbar = ({ setExibeNavbar, exibeNavbar }) => {
  const { userData } = useContext(UserContext);
  const {activatedPage} = useContext(ActivatedPage)

  return (
    <nav className={`navbar ${exibeNavbar ? "exibeNavbar" : ""}`}>
      <span
        className="navbar__close"
        onClick={() => {
          setExibeNavbar(false);
        }}
      >
        x
      </span>

      <Link to="/" exact>
        <img
          className="eventlogo__logo-image"
          src={window.innerWidth >= 992 ? logoDesktop : logoMobile}
          alt="Event Plus Logo"
        />
      </Link>

      <div className="navbar__items-box">
        <Link className={`navbar__items-box__link ${(activatedPage === 'home') ? `navbar__items-box__link--activated` : ``}`} to="/" exact>
          Home
        </Link>

        {userData.userId && userData.perfil === "Administrador" ? (
          <>
            <Link className={`navbar__items-box__link ${(activatedPage === 'eventos') ? `navbar__items-box__link--activated` : ``}`} to="/eventos">
              Eventos
            </Link>
            <Link className={`navbar__items-box__link ${(activatedPage === 'tipos-eventos') ? `navbar__items-box__link--activated` : ``}`} to="/tipos-eventos">
              Tipos de Eventos
            </Link>
          </>
        ) : (
          userData.perfil === "Comun" ? (
            <Link className={`navbar__items-box__link ${(activatedPage === 'eventos-aluno') ? `navbar__items-box__link--activated` : ``}`} to="/eventos-aluno">
              Eventos
            </Link>
          ) : (null)
        )}
      </div>
    </nav>
  );
};

export default Navbar;
