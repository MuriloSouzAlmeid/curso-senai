import { Linking } from "react-native"
import { LinkMediumLogin, LinkMediumSingup, LinkSemiBold, LinkSemiBoldCancel } from "./style"

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
    <LinkSemiBold
        onPress={() => {
            abrirUrl(url)
        }}
    >
        {children}
    </LinkSemiBold>

export const LinkCancel = ({url, children}) => 
    <LinkSemiBoldCancel
        onPress={() => abrirUrl(url)}
    >
        {children}
    </LinkSemiBoldCancel>