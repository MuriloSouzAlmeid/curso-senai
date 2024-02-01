import { BoxInput } from "../../components/BoxInput"
import { ContainerForm, ScrollForm } from "./style"

export const Home = () => {
    return (
        <ScrollForm>
            <ContainerForm>
                <BoxInput 
                    placeholder={'CEP...'} 
                    textLabel={'Informar CEP'} 
                    keyType={'numeric'}
                    maxLenght={9}
                    editable
                />
                <BoxInput 
                    placeholder={'Logradouro...'} 
                    textLabel={'Logradouro'}
                />
            </ContainerForm>
        </ScrollForm>
    )
}