import { View } from "react-native"
import { FlatListStyle } from "./style"
import { CardClinica, CardConsulta, CardMedico } from "../Card"

export const ListaConsultas = ({navigation, perfilUsuario, dados, statusConsulta, onPressCancel, onPressApointment, loadInfoConsulta, onPressConsulta }) => {
    return (
        <FlatListStyle
            data={dados}
            keyExtractor={item => item.id}
            renderItem={({ item }) =>
                statusConsulta === item.situacao.situacao ? (
                    <CardConsulta
                        idUsuario={perfilUsuario === "Paciente" ? item.medicoClinica.medico.idNavigation.id : item.paciente.idNavigation.id}
                        consulta={item}
                        imageSource={perfilUsuario === "Paciente" ? item.medicoClinica.medico.idNavigation.foto :  item.paciente.idNavigation.foto}
                        statusConsulta={statusConsulta}
                        onPressCancel={onPressCancel}
                        onPressApointment={onPressApointment}
                        onPressConsulta={onPressConsulta}
                        loadInfoConsulta={loadInfoConsulta}
                        navigation={navigation}
                        perfil={perfilUsuario}
                    />)
                    : null

            }
            showsVerticalScrollIndicator={false}
        />
    )
}

export const ListaClinicas = ({ dados, selecionarClinica, clinicaSelecionada }) =>
    <FlatListStyle
        data={dados}
        keyExtractor={item => item.id}
        renderItem={({ item }) => 
            <CardClinica 
                selecionarClinica={selecionarClinica} 
                selecionada={item.id === clinicaSelecionada.clinicaId ? true : false} 
                dados={item} 
            />
        }
    />

export const ListaMedicos = ({ dados, selecionarMedico, medicoSelecionado }) =>
    <FlatListStyle
        data={dados}
        keyExtractor={item => item.id}
        renderItem={({ item }) => 
            <CardMedico 
                selecionarMedico={selecionarMedico} 
                selecionado={item.idNavigation.id === medicoSelecionado.medicoId ? true : false}
                dados={item} 
            />
        }
    />