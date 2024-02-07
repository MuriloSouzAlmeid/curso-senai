import { Button, View } from "react-native";

export const Navegacao = ({navigation}) => 
    <View>
        <Button
            title={"Login"}
            onPress={() => navigation.navigate("Login")}
        />
        <Button
            title={"Cadastro"}
            onPress={() => navigation.navigate("Cadastro")}
        />
    </View>;