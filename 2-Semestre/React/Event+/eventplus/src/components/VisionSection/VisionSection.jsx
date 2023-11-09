import React from 'react';
import './VisionSection.css';

import Titulo from '../Titulo/Titulo';

const VisionSection = () => {
    return (
        <section className='vision'>
            <div className="vision__box">
                <Titulo 
                    titleText={'Visão'} 
                    color={'white'} 
                    additionalClass={'vision__title'}
                />
                
                <p className='vision__text'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Ut quam cumque recusandae? Sapiente, tenetur, quae voluptatem optio amet est recusandae aut adipisci, officiis alias perferendis porro maiores. Eaque, odio officiis. Lorem ipsum dolor sit amet consectetur adipisicing elit. Amet libero accusamus earum, voluptate cumque excepturi atque repudiandae adipisci quod id perspiciatis voluptatem. Earum ipsa vero ducimus similique temporibus vel? Repellendus? Lorem ipsum dolor sit amet consectetur adipisicing elit. Maiores deserunt temporibus error harum quisquam, nemo beatae, odio, reiciendis dolorem officia natus itaque animi. Magnam laborum molestiae aut iusto quibusdam animi! Lorem, ipsum dolor sit amet consectetur adipisicing elit. Ipsum ab, recusandae ratione accusantium in amet molestiae quasi doloremque cupiditate odit nihil, impedit non, ea at culpa consequatur tempore veniam quo! Lorem ipsum dolor sit amet consectetur adipisicing elit. Facere animi quia consequuntur soluta distinctio dolor laudantium temporibus impedit nisi. Sed, animi adipisci. Dolores eligendi consectetur, reprehenderit mollitia amet repudiandae ratione?</p>
            </div>
        </section>
    );
};

export default VisionSection;