import styled from "styled-components";

export const ContentIcon = styled.View.attrs({
    focus: true
})
`
    flex-direction: row;
    align-items: center;
    justify-content: center;
    gap: 5px;
    border-radius: 19px;
    padding: 9px 12px;
    background-color: ${props => `${props.tabBarActiveBackgroundColor}`};
`

export const TextIcon = styled.Text`
    font-size: 14px;
    font-family: "Quicksand_500Medium";
    color: #607EC5;
`