import styled from "styled-components";

export const HeaderContainer = styled.View`
    background-color: #FECC2B;
    height: 23.8%;
    align-items: center;
    justify-content: center;
    border-radius: 0 0 15px 15px;
    box-shadow: 0 -10px 15px rgb(0, 0, 0, 0.15);

    /*Para Android*/
    elevation: 20;
`

export const HeaderContent = styled.SafeAreaView`
    margin-top: 30px;
`

export const TextHeader = styled.Text`
    font-family: 'Roboto_500Medium';
    font-size: 24px;
    color: #333E33;
`