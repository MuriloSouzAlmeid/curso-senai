import { Button, View } from "react-native";

export const Navegacao = ({navigation}) => 
    <View>
        <Button
            title={"Login"}
            onPress={() => navigation.navigate("Login")}
        />
    </View>;