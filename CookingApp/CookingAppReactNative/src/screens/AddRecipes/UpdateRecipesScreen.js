import React, { useLayoutEffect } from "react";
import AuthService from "../../service/authService";
import { View, Text, TextInput, Button } from "react-native";
import styles from "./styles";
import { useState, useEffect } from "react";
import * as Animatable from 'react-native-animatable';
import BackButton from "../../components/BackButton/BackButton";

export default function UpdateRecipesScreen(props) {
    const { navigation, route } = props;
    const recipe = route.params?.item;
    const [user, setUser] = React.useState({
        email: '',
        nickname: ''
    });
    const [data, setData] = React.useState({
        name: recipe.name,
        description: recipe.description,
        image: recipe.image,
        kcal: recipe.kcal,
        preparationTime: recipe.preparationTime,
        cookingTime: recipe.cookingTime,
        ingredients: recipe.ingredients,
        email: recipe.user.email
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

    const onPressUpdate = () => {
        console.log(data.email);
        // try {
        //     console.log(data.name);
        //     const resp = await fetch("https://localhost:44314/api/RecipeByUser/Update",
        //         {
        //             method: 'put',
        //             headers: { 'Content-Type': 'application/json' },
        //             body: JSON.stringify({ id: recipe.recipeByUserId, name: data.name, description: data.description, image: data.image, kcal: data.kcal.toString(), preparationTime: data.preparationTime, cookingTime: data.cookingTime, ingredients: data.ingredients, email: data.email })
        //         });
        //     const data = await resp.text();
        //     console.log(data);
        //     //console.log(await resp.text());
        //     setRespondse("Actualizata cu succes!");

        // }
        // catch (error) {
        //     console.log(error);
        // }

        try {
            AuthService.updateRecipe(recipe.recipeByUserId, data.name, data.description, data.image, data.kcal.toString(), data.preparationTime, data.cookingTime, data.ingredients, data.email).then(
                (resp) => {
                    console.log(resp);
                    setResponse("Actualizata cu succes!");
                },
                data.error = 'no',
                console.log(data.error))
        }
        catch (error) {
            console.log(error);
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
            console.log(data.email);
        }
    }, []);



    return (
        <View style={styles.container}>

            <Animatable.View animation="fadeInUpBig" style={styles.footer}>

                <Text style={styles.text_footer}>Name</Text>
                <View style={styles.action}>
                    <TextInput value={data.name} style={styles.textInput} autoCapitalize="none"
                        onChangeText={(val) => nameChange(val)}></TextInput>
                </View>

                <Text style={[styles.text_footer, { marginTop: 35 }]}>Description</Text>
                <View style={styles.action}>
                    <TextInput value={data.description} multiline={true} style={[styles.textInput, { height: 200 }]} autoCapitalize="none"
                        onChangeText={(val) => descriptionChange(val)}></TextInput>
                </View>
                <Text style={[styles.text_footer, { marginTop: 35 }]}>Image</Text>
                <View style={styles.action}>
                    <TextInput value={data.image} style={styles.textInput} autoCapitalize="none"
                        onChangeText={(val) => imageChange(val)}></TextInput>
                </View>

                <Text style={[styles.text_footer, { marginTop: 35 }]}>Ingredients</Text>
                <View style={styles.action}>
                    <TextInput value={data.ingredients} multiline={true} style={[styles.textInput, { height: 100 }]} autoCapitalize="none"
                        onChangeText={(val) => ingredientsChange(val)}></TextInput>
                </View>

                <Text style={[styles.text_footer, { marginTop: 35 }]}>Kcal</Text>
                <View style={styles.action}>
                    <TextInput value={data.kcal} style={styles.textInput} autoCapitalize="none"
                        onChangeText={(val) => kcalChange(val)}></TextInput>
                </View>

                <Text style={[styles.text_footer, { marginTop: 35 }]}>Preparation time</Text>
                <View style={styles.action}>
                    <TextInput value={data.preparationTime} style={styles.textInput} autoCapitalize="none"
                        onChangeText={(val) => preparationTimeChange(val)}></TextInput>
                </View>

                <Text style={[styles.text_footer, { marginTop: 35 }]}>Cooking time</Text>
                <View style={styles.action}>
                    <TextInput value={data.cookingTime} style={styles.textInput} autoCapitalize="none"
                        onChangeText={(val) => cookingTimeChange(val)}></TextInput>
                </View>

                <View style={[styles.signIn, { backgroundColor: "blue" }]}>
                    <Button color="blue" title="Actualizeaza" onPress={() => onPressUpdate()} />
                </View>
                {response.length > 0 &&
                    <Text>{response}</Text>
                }

            </Animatable.View>

        </View>

    );

}
