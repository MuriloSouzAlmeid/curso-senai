import React from "react";
import "./Footer.css";

//passando valores padrões eu posso já criar o componente sendo um componente padrão para ser reutilizado em outros  projetos
const Footer = ({ textRights = "Site desenvolvido pelo Senai de Informática - 2023. Todos os direitos reservados" }) => {
  return( 
    <footer className="footer-page"> 
        <p className='footer-page__rights'>{textRights}</p> 
    </footer>
    )
};

export default Footer;
