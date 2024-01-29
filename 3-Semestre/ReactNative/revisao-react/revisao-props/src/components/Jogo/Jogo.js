import { View, StyleSheet, Text } from "react-native"

export const Jogo = ({
    titulo, descricao, generos, preco, dataLancamento, desenvoldedora
}) => {

    return (
        <View style={styles.container}>
            <Text style={styles.text}>Titulo: {titulo}</Text>
            <Text>Descrição: {descricao}</Text>
            <Text>Generos: {generos.map(genero => <Text>{genero},</Text>)}</Text>
            <Text>Preço: R${preco}</Text>
            <Text>Data de Lançamento: {dataLancamento}</Text>
            <Text>Desenvolvedora: {desenvoldedora}</Text>
        </View>
    )
}

const styles = StyleSheet.create({
    container: {
        padding: 15,
        backgroundColor: 'lightgreen',
        width: '90%',
        marginLeft: '5%',
        marginRight: '5%',
        marginBottom: 10,
        borderWidth: 1,
        borderColor: 'black',
        borderRadius: 8
    },
    text: {
        fontFamily: 'PoorStory_400Regular',
        fontSize: 20
    }
});
