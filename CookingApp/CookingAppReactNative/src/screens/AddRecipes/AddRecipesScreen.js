import React, { useLayoutEffect } from "react";
import AuthService from "../../service/authService";
import { View, Text, TextInput, Button } from "react-native";
import styles from "./styles";
import { useState, useEffect } from "react";
import * as Animatable from 'react-native-animatable';
import BackButton from "../../components/BackButton/BackButton";

export default function AddRecipesScreen(props) {
    const { navigation } = props;
    const [user, setUser] = React.useState({
        email: '',
        nickname: ''
    });
    const [data, setData] = React.useState({
        name: '',
        description: '',
        image: '',
        kcal: '',
        preparationTime: '',
        cookingTime: '',
        ingredients: '',
        email: ''
    });
    const [response, setResponse] = React.useState("");

    useLayoutEffect(() => {
        navigation.setOptions({
            headerLeft: () => (
                <BackButton
                    onPress={() => {
                        navigation.goBack();
                    }}
                />
            ),
            headerRight: () => <View />,
        });
    }, []);

    const nameChange = (val) => {
        setData({
            ...data,
            name: val
        });
    }

    const descriptionChange = (val) => {
        setData({
            ...data,
            description: val
        });
    }

    const ingredientsChange = (val) => {
        setData({
            ...data,
            ingredients: val
        });
    }

    const imageChange = (val) => {
        setData({
            ...data,
            image: val
        });
    }
    const kcalChange = (val) => {
        setData({
            ...data,
            kcal: val
        });
    }
    const preparationTimeChange = (val) => {
        setData({
            ...data,
            preparationTime: val
        });
    }
    const cookingTimeChange = (val) => {
        setData({
            ...data,
            cookingTime: val
        });
    }

    const onPressAdd = () => {
        console.log(data.email);
        try {
            const resp = fetch("https://localhost:44314/api/RecipeByUser/AddRecipe",
                {
                    method: 'post',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ name: data.name, description: data.description, image: data.image, kcal: data.kcal, preparationTime: data.preparationTime, cookingTime: data.cookingTime, ingredients: data.ingredients, email: data.email })
                });
            console.log(resp.status);
            setResponse("Adaugata cu succes!");

        }
        catch (error) {
            console.log(error);
        }


    };

    useEffect(() => {
        const loggedInUser = AuthService.getCurrentUser();
        console.log(loggedInUser);
        if (loggedInUser) {
            setData({
                ...data,
                email: loggedInUser.email
            });
            setUser({
                ...user,
                email: loggedInUser.email,
                nickname: loggedInUser.sub
            });
            console.log(data.email);
        }
    }, []);



    return (
        <View style={styles.container}>

            <Animatable.View animation="fadeInUpBig" style={styles.footer}>

                <Text style={styles.text_footer}>Nume</Text>
                <View style={styles.action}>
                    <TextInput placeholder="Numele retetei" style={styles.textInput} autoCapitalize="none"
                        onChangeText={(val) => nameChange(val)}></TextInput>
                </View>

                <Text style={[styles.text_footer, { marginTop: 35 }]}>Descriere</Text>
                <View style={styles.action}>
                    <TextInput placeholder="Descrierea retetei" multiline={true} style={[styles.textInput, { height: 200 }]} autoCapitalize="none"
                        onChangeText={(val) => descriptionChange(val)}></TextInput>
                </View>
                <Text style={[styles.text_footer, { marginTop: 35 }]}>Imagine</Text>
                <View style={styles.action}>
                    <TextInput placeholder="Link-ul imaginii retetei" style={styles.textInput} autoCapitalize="none"
                        onChangeText={(val) => imageChange(val)}></TextInput>
                </View>

                <Text style={[styles.text_footer, { marginTop: 35 }]}>Ingrediente</Text>
                <View style={styles.action}>
                    <TextInput placeholder="Introdu ingredientele, separate de virgula" multiline={true} style={[styles.textInput, { height: 100 }]} autoCapitalize="none"
                        onChangeText={(val) => ingredientsChange(val)}></TextInput>
                </View>

                <Text style={[styles.text_footer, { marginTop: 35 }]}>Kcal</Text>
                <View style={styles.action}>
                    <TextInput placeholder="Kcal retetei" style={styles.textInput} autoCapitalize="none"
                        onChangeText={(val) => kcalChange(val)}></TextInput>
                </View>

                <Text style={[styles.text_footer, { marginTop: 35 }]}>Timp de preparare</Text>
                <View style={styles.action}>
                    <TextInput placeholder="Timpul de preparare al retetei" style={styles.textInput} autoCapitalize="none"
                        onChangeText={(val) => preparationTimeChange(val)}></TextInput>
                </View>

                <Text style={[styles.text_footer, { marginTop: 35 }]}>Timp de gatire</Text>
                <View style={styles.action}>
                    <TextInput placeholder="Timpul de gatire al retetei" style={styles.textInput} autoCapitalize="none"
                        onChangeText={(val) => cookingTimeChange(val)}></TextInput>
                </View>

                <View style={styles.signIn}>
                    <Button color="#3CB371" title="Adauga" onPress={() => onPressAdd()} />
                </View>
                {response.length > 0 &&
                    <Text>{response}</Text>
                }

            </Animatable.View>

        </View>

    );

}
