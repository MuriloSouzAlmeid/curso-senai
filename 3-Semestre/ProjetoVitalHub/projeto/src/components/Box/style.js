import styled, { css } from "styled-components";

export const BoxInput = styled.View`
    width: 100%;
    gap: 15px;
    align-items: flex-start;
    margin: 20px 0 30px;
`

export const BoxInputRow = styled(BoxInput)`
    flex-direction: row;
    justify-content: space-between;
    margin: 0;
`

export const BoxButton = styled(BoxInput)`
`

export const BoxButtonRow = styled(BoxInputRow)`
    margin-bottom: 0px;
`

export const ContentAccount = styled.View`
    flex-direction: row;
`

export const UserContentBox = styled.View`
    gap: 10px;
    margin: 20px 0 -45px;
    align-items: center;
    justify-content: center;

    ${props => !props.editavel && css`  
            justify-content: center;
            align-items: center;  
            elevation: 10;
            top: 225px;
            left: 10%;
            position: absolute;
            z-index: 100;
            height: 100px;
            width: 80%;
            border-radius: 5px;
            background-color: white;
            margin: 0;
        `
    }


`

export const InputContentBox = styled.View`
    width: ${props => `${props.fieldWidth}%`};
    gap: 10px;
    /* padding-left: 5%; */
`