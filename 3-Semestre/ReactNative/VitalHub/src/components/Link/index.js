import { Linking } from "react-native"
import { LinkMediumLogin, LinkMediumSingup } from "./style"

const abrirUrl = async (url) => {
    try {
        const valido = Linking.canOpenURL(url)

        if (valido) {
            await Linking.openURL(url)
        } else {
            alert("Não foi possível abrir este link")
        }
    } catch (erro) {
        console.warn(erro)
    }
}

export const LinkRedefinirSenha = ({ url, children }) => {
    return (
        <LinkMediumLogin
            onPress={() => {
                abrirUrl(url)
            }}

        >
            {children}
        </LinkMediumLogin>
    )
}

export const LinkAccount = ({ url, children }) =>
    <LinkMediumSingup
        onPress={() => {
            abrirUrl(url)
        }}
    >
        {children}
    </LinkMediumSingup>