import React from 'react';
import './ContactSection.css'
import Titulo from '../Titulo/Titulo';

import contatoMap from '../../assets/images/contato-map.png';

const ContactSection = () => {
    return (
        <section className='contato'>
            <Titulo titleText={'Contato'}/>

            <div className="contato__endereco-box">
                <img
                    className='contato__img-map' 
                    src={contatoMap} 
                    alt="Imagem ilustrativa de um mapa" 
                />

                <p>
                    Rua dos Bobos, 0 - Bairro das Luzes <br />
                    São Caetano do Sul - SP <br />
                    <a 
                        href="tel:+55114225200"
                        className='contato__telefone'
                    >
                        (11) 4225-2000
                    </a>
                </p>
            </div>
        </section>
    );
};

export default ContactSection;