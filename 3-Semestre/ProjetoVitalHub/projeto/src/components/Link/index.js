import { Linking } from "react-native"
import { LinkMediumLogin, LinkMediumSingup, LinkSemiBold, LinkSemiBoldCancel, LinkSemiBoldReenviarEmail, LinkSemiBoldVerifyEmail } from "./style"

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

export const LinkRedefinirSenha = ({ onPress, children }) => {
    return (
        <LinkMediumLogin
            onPress={onPress}

        >
            {children}
        </LinkMediumLogin>
    )
}

export const LinkAccount = ({ url, children }) =>
    <LinkSemiBold
    >
        {children}
    </LinkSemiBold>

export const LinkCancel = ({ onPress, children }) =>
    <LinkSemiBoldCancel
        onPress={onPress}
    >
        {children}
    </LinkSemiBoldCancel>

export const LinkVerifyEmail = ({ url, children }) =>
    <LinkSemiBoldVerifyEmail
        onPress={() => abrirUrl(url)}
    >
        {children}
    </LinkSemiBoldVerifyEmail>

export const LinkReenviarEmail = ({ onPress, children }) =>
    <LinkSemiBoldReenviarEmail
        onPress={onPress}
    >
        {children}
    </LinkSemiBoldReenviarEmail>