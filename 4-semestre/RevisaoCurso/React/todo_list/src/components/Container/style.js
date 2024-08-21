import styled from "styled-components";

export const ContainerApp = styled.main`
    background-color: #8758FF;
    width: 100vw;
    height: 100vh;
`

export const ContainerHome = styled.section`
    display: flex;
    justify-content: center;
    margin: 0 auto;
    width: 100%;
    height: 100%;
`

export const ToDoListContainer = styled.div`
    display: flex;
    flex-direction: column;
    gap: 10px;
    align-items: flex-end;
    justify-content: center;
    width: 50%;
    height: auto;
`

export const ContainerModal = styled.div`
    background-color: rgba(0, 0, 0, 0.25);
    position: fixed;
    z-index: 10;
    height: 100vh;
    width: 100vw;
    backdrop-filter: blur(5px);
    display: flex;
    align-items: center;
    justify-content: center;
`