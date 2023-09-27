import React, { useLayoutEffect, useState, useEffect } from "react";
import { ScrollView, Text, View, Image, Dimensions, FlatList, TouchableOpacity } from "react-native";
import styles from "./styles";
import BackButton from "../../components/BackButton/BackButton";
import Feather from 'react-native-vector-icons/Feather';
import AuthService from "../../service/authService";
import * as Animatable from 'react-native-animatable';


export default function RecipeScreen(props) {
    const { navigation, route } = props;
    const item = route.params?.item;
    const [ingredients, setIngredients] = useState([]);
    const [user, setUser] = React.useState({
        email: '',
        nickname: ''
    });
    const [response, setResponse] = useState('');

    const loggedin = () => {
        const loggedInUser = AuthService.getCurrentUser();
        console.log(loggedInUser);
        if (loggedInUser) {
            setUser({
                ...user,
                email: loggedInUser.email,
                nickname: loggedInUser.sub
            });
        }
        console.log(item);
    }



    const getIngredients = () => {
        if (item.ingredients != null) {
            setIngredients(item.ingredients.split(","));
        }
    }

    useEffect(() => {
        getIngredients();
        loggedin();
    }, []);


    useLayoutEffect(() => {
        navigation.setOptions({
            headerTransparent: "true",
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

    const deleteRecipe = () => {
        fetch('https://localhost:44314/api/RecipeByUser/Delete/' + item.recipeByUserId, { method: 'DELETE' })
            .then(() => setResponse('Sters cu succes!'));
    }
    const updateRecipe = () => {
        navigation.navigate("Actualizeaza reteta", { item })
    }


    const renderIngredients = ({ item }) => (
        <View style={styles.container}>
            <Text style={styles.category}>{item}</Text>
        </View>

    );
    return (

        <ScrollView>
            <Animatable.View animation={"fadeInDownBig"} style={styles.infoRecipeContainer}>
                <View style={styles.imageContainer}>
                    <Image style={styles.image} source={{ uri: item.image }} />
                </View>
                <Text style={styles.infoRecipeName}>{item.name}</Text>

                <Text style={styles.infoRecipeProperties}>Timp de preparare: {item.preparationTime}</Text>
                <Text style={styles.infoRecipeProperties}>Timp de gatire: {item.cookingTime}</Text>
                <Text style={styles.infoRecipeProperties}>Kcal: {item.kcal}</Text>
                <View >
                    {ingredients && (
                        <FlatList vertical showsVerticalScrollIndicator={false} data={ingredients} renderItem={renderIngredients} keyExtractor={(item) => `${item.ingredientId}`} />
                    )}
                </View>

                <Text style={styles.subtitle}>Descriere:</Text>

                <View>
                    <Text style={styles.infoDescriptionRecipe}>{item.description}</Text>
                    <Text style={styles.subtitle} >Autor:</Text>
                    <Text style={[styles.subtitle, { fontSize: 20, marginTop: 5 }]}>{item.user.userName}</Text>
                    <Text style={[styles.subtitle, { fontSize: 18, marginTop: 5 }]}>{item.user.email}</Text>
                </View>
                <View>
                    {user.email == item.user.email && (
                        <View>
                            <TouchableOpacity style={[styles.sort, { width: 150, backgroundColor: 'red', marginTop: 25 }]} onPress={deleteRecipe}>
                                <Text style={{ color: 'white' }}>Sterge reteta</Text>
                            </TouchableOpacity>
                            {response.length > 0 &&
                                <Text>{response}</Text>
                            }
                        </View>
                    )}
                    {user.email == item.user.email && (
                        <TouchableOpacity style={[styles.sort, { marginTop: 15, width: 150, backgroundColor: 'blue' }]} onPress={updateRecipe}>
                            <Text style={{ color: 'white' }}>Actualizeaza reteta</Text>
                        </TouchableOpacity>
                    )}
                </View>
            </Animatable.View>
        </ScrollView>
    );
}
