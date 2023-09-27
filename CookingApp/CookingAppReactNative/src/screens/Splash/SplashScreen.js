import React from "react";
import { View, Text, Button } from "react-native";
import styles from "./styles";
import { useEffect } from "react";
import AuthService from "../../service/authService";
import * as Animatable from 'react-native-animatable';

export default function SplashScreen(props) {
  const { navigation } = props;
  const [user, setUser] = React.useState({
    email: '',
    nickname: ''
  });

  useEffect(() => {
    const loggedInUser = AuthService.getCurrentUser();

    if (loggedInUser) {
      console.log(loggedInUser);
      setUser({
        ...user,
        email: loggedInUser.email,
        nickname: loggedInUser.sub
      });
      console.log(loggedInUser.email);
    }
  }, []);

  if (user.email) {
    console.log(user.email);
    navigation.navigate("Acasa");
  }

  return (
    <View style={styles.container}>
      <View style={styles.header}>
        <Animatable.Image animation="bounceIn" style={styles.logo} source={require("../../../assets/icons/cookie100.png")} resizeMode="stretch" />
      </View>
      <Animatable.View animation="fadeInUpBig" style={styles.footer}>
        <Text style={styles.title}>Aplicatia ta zilnica de gatit!</Text>
        <Text style={styles.text}>Autentifica-te</Text>

        <View style={styles.button}>
          <Button color="#3CB371"
            title="Incepe"
            onPress={() => navigation.navigate("Autentificare")}
          />
        </View>
      </Animatable.View>
    </View>
  );
}
