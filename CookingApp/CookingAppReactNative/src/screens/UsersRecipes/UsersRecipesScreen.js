import React, { useLayoutEffect, useState, useEffect } from "react";
import { FlatList, Text, View, TouchableHighlight, Image, ScrollView } from "react-native";
import styles from "./styles";
import MenuImage from "../../components/MenuImage/MenuImage";
import * as Animatable from 'react-native-animatable';
import { RefreshControl } from 'react-native-web-refresh-control'
import DropDownPicker from 'react-native-dropdown-picker';
import { TouchableOpacity } from "react-native-gesture-handler";

export default function UsersRecipesScreen(props) {
    const { navigation, route } = props;
    const user = route.params?.user;
    const [recipesArray, setRecipesArray] = useState([]);
    const [refreshing, setRefreshing] = React.useState(false);
    const [open, setOpen] = useState(false);
    const [value, setValue] = useState(null);
    const [items, setItems] = useState([
        { label: 'A-Z', value: 'alphabetically' },
        { label: 'Kcal', value: 'kcal' },
        { label: 'Timp', value: 'time' },
    ]);
    const [flatListRefresh, setFlatListRefresh] = useState(false);

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


    const fetchData = async () => {

        try {

            console.log(user);
            const resp = await fetch("https://localhost:44314/api/RecipeByUser/GetRecipes");
            const data = await resp.json();
            console.log(data);

            setRecipesArray(data);

        }
        catch (error) {
            console.log(error)
        }
    };

    useEffect(() => {

        fetchData();
    }, []);



    const onPressRecipe = (item) => {
        navigation.navigate("Reteta utilizatorului", { item });
    };

    const wait = (timeout) => {
        return new Promise(resolve => setTimeout(resolve, timeout));
    }

    const onRefresh = React.useCallback(() => {
        setRefreshing(true);
        navigation.navigate("Acasa");
        navigation.navigate("Retetele utilizatorilor", { user });
        wait(2000).then(() => setRefreshing(false));
    }, []);

    const sort = () => {
        if (value == "kcal") {
            const sorted = recipesArray.sort((a, b) => { return a.kcal - b.kcal; });
            setRecipesArray([]);
            setRecipesArray(sorted);
            setFlatListRefresh(true);
        }
        if (value == "time") {
            const sorted = recipesArray.sort((a, b) => { return (parseInt(a.preparationTime.split(" ")[0]) + (parseInt(a.cookingTime.split(" ")[0]))) - (parseInt(b.preparationTime.split(" ")[0]) + (parseInt(b.cookingTime.split(" ")[0]))); });
            setRecipesArray([]);
            setRecipesArray(sorted);
            setFlatListRefresh(true);
        }
        if (value == "alphabetically") {
            const sorted = recipesArray.sort((a, b) => (a.name > b.name) ? 1 : -1);
            setRecipesArray([]);
            setRecipesArray(sorted);
            setFlatListRefresh(true);
        }
    };

    const renderRecipes = ({ item }) => (
        <TouchableHighlight underlayColor="rgba(73,182,77,0.9)" onPress={() => onPressRecipe(item)}>
            <View style={styles.container}>
                <Image style={styles.photo} source={{ uri: item.image }} />
                <Text style={styles.title}>{item.name}</Text>
            </View>
        </TouchableHighlight>
    );

    return (
        <ScrollView
            refreshControl={
                <RefreshControl
                    refreshing={refreshing}
                    onRefresh={onRefresh} />
            }>
            <Text style={styles.subtitle}>Sorteaza retetele:</Text>
            <View style={{ marginTop: 10, marginLeft: 70, marginRight: 70, marginBottom: 80, flexDirection: 'row' }}>
                <View style={{ flex: 1 }}>
                    <DropDownPicker
                        open={open}
                        value={value}
                        items={items}
                        setOpen={setOpen}
                        setValue={setValue}
                        setItems={setItems}
                        placeholder="Filtre"
                        containerStyle={{ width: 150, height: 10 }}
                        textStyle={{ fontSize: 15, color: '#05375a' }}
                        labelStyle={{ fontWeight: 'bold', fontSize: 15, color: '#3CB371' }}
                        placeholderStyle={{ fontWeight: 'bold' }}
                    />
                </View>
                <TouchableOpacity style={styles.sort} onPress={sort}>
                    <Text style={{ color: 'white' }}>Aplica</Text>
                </TouchableOpacity>
            </View>
            <Animatable.View animation={"bounceInLeft"} duration={2000}>
                {recipesArray && (
                    <FlatList extraData={flatListRefresh} vertical showsVerticalScrollIndicator={false} numColumns={2} data={recipesArray} renderItem={renderRecipes} keyExtractor={(item) => `${item.recipeId}`} />
                )}</Animatable.View>
        </ScrollView>
    );
}
