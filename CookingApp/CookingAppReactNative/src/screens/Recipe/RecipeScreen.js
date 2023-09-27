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
  const [data, setData] = useState([]);
  const [author, setAuthor] = useState([]);
  const [ingredients, setIngredients] = useState([]);
  const [favorite, setFavorite] = useState(false);
  const [user, setUser] = React.useState({
    email: '',
    nickname: ''
  });

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
  }

  const checkIfRecipeIsFavorite = async () => {
    try {
      const resp = await fetch("https://localhost:44314/api/UserRecipe/CheckIfRecipeExists/" + item.recipeId);
      const data = await resp.text();
      if (data == "True") {
        setFavorite(true);
      }
      else {
        setFavorite(false);
      }
    }
    catch (error) {
      console.log(error)
    }
  }

  const fetchData = async () => {
    try {
      const resp = await fetch("https://localhost:44314/api/Recipe/" + item.recipeId.toString());
      const data = await resp.json();
      setData(data);
      setAuthor(data.author);

      const resp1 = await fetch("https://localhost:44314/ingredientsByRecipes/" + item.recipeId.toString());
      const data1 = await resp1.json();

      console.log(data1);
      console.log(data);
      setIngredients(data1);
      loggedin();

    }
    catch (error) {
      console.log(error)
    }
  };
  useEffect(() => {
    fetchData();
    checkIfRecipeIsFavorite();
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

  const addRecipeToFavorite = async () => {
    try {
      const resp = await fetch("https://localhost:44314/api/UserRecipe/" + "CreateUserRecipe/" + user.email + "/" + item.recipeId,
        {
          method: 'post'
        });
      console.log(resp);
      const data = await resp.text();
      console.log(data);
      if (data == "Succes!") {
        setFavorite(true);
      }

      return data;
    }
    catch (error) {
      console.log(error);
    }
  }

  const deleteRecipeFromFavorite = async () => {
    try {
      const resp = await fetch("https://localhost:44314/api/UserRecipe/" + "DeleteUserRecipe/" + user.email + "/" + item.recipeId,
        {
          method: 'delete'
        });
      console.log(resp);
      const data = await resp.text();
      console.log(data);
      if (data == "Succes!") {
        setFavorite(false);
      }

      return data;
    }
    catch (error) {
      console.log(error);
    }
  }


  const renderIngredients = ({ item }) => (
    <View style={styles.container}>
      <Text style={styles.category}>{item.ingredients.name}  {item.ingredients.amount * item.quantity} {item.ingredients.unit}</Text>
    </View>

  );
  return (

    <ScrollView>
      <Animatable.View animation={"fadeInDownBig"} style={styles.infoRecipeContainer}>
        <View style={styles.imageContainer}>
          <Image style={styles.image} source={{ uri: data.image }} />
        </View>
        <Text style={styles.infoRecipeName}>{data.name}</Text>

        {favorite ?
          <View style={{ flexDirection: "row" }}>
            <Text style={[styles.subtitle, { flex: 1, marginTop: 0, fontSize: 16 }]}>Sterge de la favorite</Text>
            <TouchableOpacity style={{ flex: 2, textAlign: "right" }} onPress={deleteRecipeFromFavorite}>
              <Feather name="minus" color="red" size={40}></Feather>
            </TouchableOpacity>
          </View>
          :
          <View style={{ flexDirection: "row" }}>
            <Text style={[styles.subtitle, { flex: 1, marginTop: 0, fontSize: 16 }]}>Adauga la favorite</Text>
            <TouchableOpacity style={{ flex: 2, textAlign: "right" }} onPress={addRecipeToFavorite}>
              <Feather name="plus" color="green" size={40}></Feather>
            </TouchableOpacity>
          </View>}


        <Text style={styles.infoRecipeProperties}>Timp de preparare: {data.preparationTime}</Text>
        <Text style={styles.infoRecipeProperties}>Timp de gatire: {data.cookingTime}</Text>
        <Text style={styles.infoRecipeProperties}>Kcal: {data.kcal}</Text>
        <View >
          {ingredients && (
            <FlatList vertical showsVerticalScrollIndicator={false} data={ingredients} renderItem={renderIngredients} keyExtractor={(item) => `${item.ingredientId}`} />
          )}
        </View>

        <Text style={styles.subtitle}>Descriere:</Text>

        <View>
          <Text style={styles.infoDescriptionRecipe}>{data.description}</Text>
          <Text style={styles.subtitle} >Autor:</Text>
          <Text style={[styles.subtitle, { fontSize: 20, marginTop: 5 }]}>{author.firstName} {author.lastName}</Text>
          <Text style={[styles.subtitle, { fontSize: 18, marginTop: 5 }]}>{author.email}</Text>
        </View>
        <View style={styles.infoRecipeContainer}>
        </View>
      </Animatable.View>
    </ScrollView>
  );
}
