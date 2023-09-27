import React from "react";
import AuthService from "../../service/authService";
import { View, Text, TextInput, Button, TouchableOpacity } from "react-native";
import styles from "./styles";
import FontAwesome from 'react-native-vector-icons/FontAwesome'
import Feather from 'react-native-vector-icons/Feather'
import { useEffect } from "react";
import * as Animatable from 'react-native-animatable';

export default function LoginScreen(props) {
    const { navigation } = props;
    const [user, setUser] = React.useState({
        email: '',
        nickname: ''
    });
    const [data, setData] = React.useState({
        email: '',
        password: '',
        check_textInputChange: false,
        secureTextEntry: true,
        error: ''
    });
    const [emailError, setEmailError] = React.useState("");
    const [passwordError, setPasswordError] = React.useState("");
    const [response, setResponse] = React.useState("");

    const textInputChange = (val) => {
        if (val.length != 0) {
            setData({
                ...data,
                email: val,
                check_textInputChange: true
            });
        } else {
            setData({
                ...data,
                email: val,
                check_textInputChange: false
            });
        }
        setEmailError("");
    }

    const handlePasswordChange = (val) => {
        setData({
            ...data,
            password: val
        });
        setPasswordError("");
    }

    const updateSecureTextEntry = () => {
        setData({
            ...data,
            secureTextEntry: !data.secureTextEntry
        });
    }

    function checkEmail(str) {
        const expression = /(?!.*\.{2})^([a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+(\.[a-z\d!#$%&'*+\-\/=?^_`{|}~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]+)*|"((([\t]*\r\n)?[\t]+)?([\x01-\x08\x0b\x0c\x0e-\x1f\x7f\x21\x23-\x5b\x5d-\x7e\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|\\[\x01-\x09\x0b\x0c\x0d-\x7f\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))*(([\t]*\r\n)?[\t]+)?")@(([a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\d\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.)+([a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]|[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF][a-z\d\-._~\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]*[a-z\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])\.?$/i;

        return expression.test(String(str).toLowerCase())
    }
    function checkPassword(str) {
        var re = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[.!@#\$%\^&\*])(?=.{6,})");
        return re.test(str);
    }

    const onPressLogin = () => {
        var validEmail = true;
        if (checkEmail(data.email) == false) {
            validEmail = false;
            setEmailError("Email-ul trebuie sa fie valid!");
        }
        var validPassword = true;
        if (checkPassword(data.password) == false) {
            validPassword = false;
            setPasswordError("Parola trebuie sa fie de minim 5 caractere si trebuie sa contina minim o litera mare, o cifra si un caracter special!");
        }

        if (validPassword == true && validEmail == true) {
            try {
                AuthService.login(data.email, data.password).then(
                    (resp) => {
                        if (resp == "loggedIn") {
                            const loggedInUser = AuthService.getCurrentUser();
                            if (loggedInUser) {
                                navigation.navigate("Acasa");
                                window.location.reload(false);
                            }
                        }
                        else {
                            setResponse(resp);
                        }

                    },
                    data.error = 'no',
                    console.log(data.error))
            }
            catch (error) {
                console.log(error);
            }
        }
    };

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
            <Animatable.View animation="bounceIn" style={styles.header}>
                <Text style={styles.text_header}>Bine ai venit!</Text>
            </Animatable.View>
            <Animatable.View animation="fadeInUpBig" style={styles.footer}>
                <Text style={styles.text_footer}>Email</Text>
                <View style={styles.action}>
                    <FontAwesome name="user-o" color="#05375a" size={20}></FontAwesome>
                    <TextInput placeholder="Email-ul tau" style={styles.textInput} autoCapitalize="none" onChangeText={(val) => textInputChange(val)}></TextInput>
                    {checkEmail(data.email) ?
                        <Animatable.View animation="bounceIn">
                            <Feather name="check-circle" color="green" size={20}></Feather></Animatable.View>
                        : null}
                </View>
                {emailError.length > 0 &&
                    <Text>{emailError}</Text>
                }

                <Text style={[styles.text_footer, { marginTop: 35 }]}>Parola</Text>
                <View style={styles.action}>
                    <FontAwesome name="lock" color="#05375a" size={20}></FontAwesome>
                    <TextInput placeholder="Parola ta" secureTextEntry={data.secureTextEntry ? true : false} style={styles.textInput} autoCapitalize="none"
                        onChangeText={(val) => handlePasswordChange(val)}></TextInput>
                    <TouchableOpacity onPress={updateSecureTextEntry}>
                        <Feather name="eye-off" color="grey" size={20}></Feather>
                    </TouchableOpacity>
                </View>
                {passwordError.length > 0 &&
                    <Text>{passwordError}</Text>
                }

                <View style={styles.signIn}>
                    <Button color="#3CB371" title="Autentificare" onPress={() => onPressLogin()} />
                </View>
                {response.length > 0 &&
                    <Text>{response}</Text>
                }
                <Text style={[styles.text_footer, { marginTop: 35, fontSize: 20 }]}>Nu ai cont? Inregistreaza-te! </Text>
                <TouchableOpacity onPress={() => navigation.navigate("Inregistrare")}>
                    <View>
                        <Text style={styles.signUp}>Inregistrare</Text>
                    </View>
                </TouchableOpacity>
            </Animatable.View>
        </View>
    );
}
