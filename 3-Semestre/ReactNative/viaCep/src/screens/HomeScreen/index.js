import { BoxInput } from "../../components/BoxInput"
import { ContainerForm, ScrollForm, ViewInpuRow } from "./style"
import { api } from "../../services/Service"
import { useEffect, useState } from "react"
import { mascarar, desmascarar } from "../../utils/StringMak"

export const Home = () => {
    //States e Variáveis
    const [cep, setCep] = useState('');
    const [endereco, setEndereco] = useState({});

    //UseEffects e Funções
    const pegarEndereco = async () => {
        if (cep.length < 9) {
            setEndereco({})
            return
        }

        try {
            const retono = await api.get(`${desmascarar(cep)}`);

            if(retono.error){
                return;
            }

            const cepApi = retono.data.result;

            setEndereco({
                logradouro: cepApi.street + `${(cepApi.complement == '') ? '' : `, ${cepApi.complement}`}`,
                complemento: cepApi.complement,
                bairro: cepApi.district,
                cidade: cepApi.city,
                estado: cepApi.state,
                uf: cepApi.stateShortname,
            })


        } catch (erro) {
            console.warn(erro)
        }
    }

    useEffect(() => {
        pegarEndereco();
    }, [cep])

    //Componente

    return (
        <ScrollForm>
            <ContainerForm>
                <BoxInput
                    placeholder={'CEP...'}
                    textLabel={'Informar CEP'}
                    keyType={'numeric'}
                    maxLenght={9}
                    editable
                    onChangeText={(tx) => setCep(tx)}
                    fieldValue={mascarar(cep)}
                />
                <BoxInput
                    placeholder={'Logradouro...'}
                    textLabel={'Logradouro'}
                    fieldValue={endereco.logradouro}
                />
                <BoxInput
                    placeholder={'Bairro...'}
                    textLabel={'Bairro'}
                    fieldValue={endereco.bairro}
                />
                <BoxInput
                    placeholder={'Cidade...'}
                    textLabel={'Cidade'}
                    fieldValue={endereco.cidade}
                />
                <ViewInpuRow>
                    <BoxInput
                        textLabel={'Estado'}
                        placeholder={'Estado...'}
                        fieldWidth={67.8}
                        fieldValue={endereco.estado}
                    />
                    <BoxInput
                        textLabel={'UF'}
                        placeholder={'UF'}
                        fieldWidth={23}
                        maxLenght={2}
                        fieldValue={endereco.uf}
                    />
                </ViewInpuRow>
            </ContainerForm>
        </ScrollForm>
    )
}