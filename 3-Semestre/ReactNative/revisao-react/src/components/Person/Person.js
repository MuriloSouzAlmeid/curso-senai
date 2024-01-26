import { View, Text, StyleSheet } from "react-native";

const Person = ({name, age}) => {
    return(
        <View style={styles.container}>
            <Text style={styles.txtName}>Hello my name is {name}</Text>
            <Text style={styles.txtAge}>And I'm {age} years old</Text>
        </View>
    );
}

const styles = StyleSheet.create({
    container: {
        backgroundColor: 'lightgrey',
        borderRadius: 8,
        margin: 10,
        padding: 10
    },
    txtName: {
        color: 'darkred',
        fontSize: 18
    },
    txtAge: {
        color: 'blueviolet',
        fontSize: 15
    }
})

export default Person;