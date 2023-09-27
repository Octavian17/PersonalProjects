import React, { useLayoutEffect } from "react";
import AuthService from "../../service/authService";
import { View, Text, TextInput, ScrollView, Button, TouchableOpacity } from "react-native";
import styles from "./styles";
import FontAwesome from 'react-native-vector-icons/FontAwesome'
import Feather from 'react-native-vector-icons/Feather'
import { useEffect } from "react";
import MenuImage from "../../components/MenuImage/MenuImage";
import * as Animatable from 'react-native-animatable';
import { RefreshControl } from 'react-native-web-refresh-control'

export default function ProfileScreen(props) {
    const { navigation } = props;
    const [user, setUser] = React.useState({
        email: '',
        nickname: ''
    });
    const [data, setData] = React.useState({
        email: '',
        password: '',
        newPassword: '',
        nickname: '',
        secureTextEntryForCurrentPassword: true,
        secureTextEntryForNewPassword: true,
        error: ''
    });
    const [response, setResponse] = React.useState("");
    const [passwordError, setPasswordError] = React.useState("");
    const [newPasswordError, setNewPasswordError] = React.useState("");
    const [nicknameError, setNicknameError] = React.useState("");
    const [refreshing, setRefreshing] = React.useState(false);

    useLayoutEffect(() => {
        navigation.setOptions({
            headerLeft: () => (
                <MenuImage
                    onPress={() => {
                        navigation.openDrawer();
                    }}
                />
            ),
            headerRight: () => <View />,
        });
    }, []);

    const textInputChange = (val) => {
        if (val.length != 0) {
            setData({
                ...data,
                nickname: val,
                check_textInputChange: true
            });
        } else {
            setData({
                ...data,
                nickname: val,
                check_textInputChange: false
            });
        }
        setNicknameError("");
    }

    const handlePasswordChange = (val) => {
        setData({
            ...data,
            password: val
        });
        setPasswordError("");
    }

    const handleNewPasswordChange = (val) => {
        setData({
            ...data,
            newPassword: val
        });
        setNewPasswordError("");
    }

    const updateSecureTextEntryForCurrentPassword = () => {
        setData({
            ...data,
            secureTextEntryForCurrentPassword: !data.secureTextEntryForCurrentPassword
        });

    }

    const updateSecureTextEntryForNewPassword = () => {
        setData({
            ...data,
            secureTextEntryForNewPassword: !data.secureTextEntryForNewPassword
        });

    }
    function checkPassword(str) {
        var re = new RegExp("^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[.!@#\$%\^&\*])(?=.{6,})");
        return re.test(str);
    }

    const onPressUpdate = () => {
        var validFields = true;
        if (data.newPassword == "" && data.nickname == "" && data.password == "") {
            setResponse("Ambele campuri nu pot fi goale!");
            validFields = false;
        }
        if (data.nickname != "" && data.password == "") {
            setResponse("Trebuie sa introduci parola ta curenta!");
            validFields = false;
        }
        if (data.newPassword == "" && data.nickname == "" && data.password != "") {
            setResponse("Trebuie sa introduci un nume de utilizator!");
            validFields = false;
        }

        var validPassword = true;
        var validNewPassword = true;
        if (data.password != "" && checkPassword(data.password) != true) {
            validPassword = false;
            setPasswordError("Parola trebuie sa fie de minim 5 caractere si trebuie sa contina minim o litera mare, o cifra si un caracter special!");
        }

        if (data.newPassword != "" && checkPassword(data.newPassword) != true) {
            validNewPassword = false;
            setNewPasswordError("Parola trebuie sa fie de minim 5 caractere si trebuie sa contina minim o litera mare, o cifra si un caracter special!");
        }
        var validNickname = true;
        if (data.nickname.indexOf(' ') >= 0) {
            validNickname = false;
            setNicknameError("Numele de utilizator nu poate contine spatii!");
        }


        if (validFields == true && validPassword == true && validNewPassword == true && validNickname == true) {
            try {
                AuthService.update(user.email, data.password, data.newPassword, data.nickname).then(
                    (resp) => {
                        console.log(resp);
                        setResponse(resp);
                        if (resp == "Nume utilizator actualizat!") {
                            AuthService.logout();
                            AuthService.login(user.email, data.password);
                        }
                        if (resp == "Parola a fost schimbata!\nNume utilizator actualizat!") {
                            AuthService.logout();
                            AuthService.login(user.email, data.newPassword);
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
        console.log(loggedInUser);
        if (loggedInUser) {
            setUser({
                ...user,
                email: loggedInUser.email,
                nickname: loggedInUser.sub
            });
            console.log(loggedInUser.email);
        }
    }, []);

    const wait = (timeout) => {
        return new Promise(resolve => setTimeout(resolve, timeout));
    }

    const onRefresh = React.useCallback(() => {
        setRefreshing(true);
        navigation.navigate("Acasa");
        navigation.navigate("Profil");
        wait(2000).then(() => setRefreshing(false));
    }, []);


    return (
        <View style={styles.container}>
            <Animatable.View animation="bounceIn" style={styles.header}>
                <Text style={styles.text_header}>Profilul tau, {user.nickname}!</Text>
            </Animatable.View>

            <Animatable.View animation="fadeInUpBig" style={styles.footer}>
                <ScrollView
                    refreshControl={
                        <RefreshControl
                            refreshing={refreshing}
                            onRefresh={onRefresh} />
                    }>
                    <Text style={styles.text_footer}>Email</Text>
                    <View style={styles.action}>
                        <FontAwesome name="user-o" color="#05375a" size={20}></FontAwesome>
                        <Text style={styles.text_footer}> {user.email}</Text>
                    </View>

                    <Text style={[styles.text_footer, { marginTop: 35 }]}>Schimba parola</Text>
                    <View style={styles.action}>
                        <FontAwesome name="lock" color="#05375a" size={20}></FontAwesome>
                        <TextInput placeholder="Parola ta curenta" secureTextEntry={data.secureTextEntryForCurrentPassword ? true : false} style={styles.textInput} autoCapitalize="none"
                            onChangeText={(val) => handlePasswordChange(val)}></TextInput>
                        <TouchableOpacity onPress={updateSecureTextEntryForCurrentPassword}>
                            <Feather name="eye-off" color="grey" size={20}></Feather>
                        </TouchableOpacity>
                    </View>
                    {passwordError.length > 0 &&
                        <Text>{passwordError}</Text>
                    }
                    <View style={styles.action}>
                        <FontAwesome name="lock" color="#05375a" size={20}></FontAwesome>
                        <TextInput placeholder="Parola ta noua" secureTextEntry={data.secureTextEntryForNewPassword ? true : false} style={styles.textInput} autoCapitalize="none"
                            onChangeText={(val) => handleNewPasswordChange(val)}></TextInput>
                        <TouchableOpacity onPress={updateSecureTextEntryForNewPassword}>
                            <Feather name="eye-off" color="grey" size={20}></Feather>
                        </TouchableOpacity>
                    </View>
                    {newPasswordError.length > 0 &&
                        <Text>{newPasswordError}</Text>
                    }

                    <Text style={[styles.text_footer, { marginTop: 35 }]}>Schimba numele de utilizator</Text>
                    <View style={styles.action}>
                        <FontAwesome name="user-secret" color="#05375a" size={25}></FontAwesome>
                        <TextInput placeholder={user.nickname} style={styles.textInput} autoCapitalize="none" onChangeText={(val) => textInputChange(val)}></TextInput>
                        {data.check_textInputChange ?
                            <Feather name="check-circle" color="green" size={20}></Feather>
                            : null}
                    </View>
                    {nicknameError.length > 0 &&
                        <Text>{nicknameError}</Text>
                    }
                    <View style={styles.signIn}>
                        <Button color="#3CB371" title="Actualizeaza" onPress={() => onPressUpdate()} />
                    </View>
                    {response.length > 0 &&
                        <Text>{response}</Text>
                    }
                </ScrollView>
            </Animatable.View>

        </View>

    );

}
