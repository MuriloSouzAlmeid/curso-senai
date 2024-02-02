import { BoxInput } from "../../components/BoxInput"
import { ContainerForm, ScrollForm, ViewInpuRow } from "./style"
import { api } from "../../services/Service"
import { useEffect, useState } from "react"
import { mascarar, desmascarar } from "../../utils/StringMak"

export const Home = () => {
    const [cep, setCep] = useState('');
    const [endereco, setEndereco] = useState({});

    const pegarEndereco = async () => {
        if(cep.length < 9){
            setEndereco({})
            return
        }

        try {
            const retono = await api.get(`${desmascarar(cep)}`);

            setEndereco(retono.data.result)

            // if(endereco.complement !== ''){
            //     setEndereco({
            //         ...endereco,
            //         street: `${endereco.street}, ${endereco.complement}`
            //     })
            // }
        } catch (erro) {
            console.warn(erro)
        }
    }

    useEffect(() => {
        pegarEndereco();
    }, [cep])

    return (
        <ScrollForm>
            <ContainerForm>
                <BoxInput
                    placeholder={'CEP...'}
                    textLabel={'Informar CEP'}
                    keyType={'numeric'}
                    maxLenght={9}
                    editable
                    onChangeText={setCep}
                    fieldValue={mascarar(cep)}
                />
                <BoxInput
                    placeholder={'Logradouro...'}
                    textLabel={'Logradouro'}
                    fieldValue={endereco.street}
                />
                <BoxInput
                    placeholder={'Bairro...'}
                    textLabel={'Bairro'}
                    fieldValue={endereco.district}
                />
                <BoxInput
                    placeholder={'Cidade...'}
                    textLabel={'Cidade'}
                    fieldValue={endereco.city}
                />
                <ViewInpuRow>
                    <BoxInput
                        textLabel={'Estado'}
                        placeholder={'Estado...'}
                        fieldWidth={67.8}
                        fieldValue={endereco.state}
                    />
                    <BoxInput
                        textLabel={'UF'}
                        placeholder={'UF'}
                        fieldWidth={23}
                        maxLenght={2}
                        fieldValue={endereco.stateShortname}
                    />
                </ViewInpuRow>
            </ContainerForm>
        </ScrollForm>
    )
}