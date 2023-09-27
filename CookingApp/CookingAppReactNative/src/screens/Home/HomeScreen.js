import React, { useLayoutEffect } from "react";
import { useState, useEffect } from "react";
import { FlatList, Text, View, TouchableHighlight, Image, Button, ScrollView } from "react-native";
import { RefreshControl } from 'react-native-web-refresh-control'
import styles from "./styles";
import MenuImage from "../../components/MenuImage/MenuImage";
import AuthService from "../../service/authService";
import { TextInput, TouchableOpacity } from "react-native-gesture-handler";
import * as Animatable from 'react-native-animatable';
import authService from "../../service/authService";
import { useIsFocused } from '@react-navigation/native';
import DropDownPicker from 'react-native-dropdown-picker';


export default function HomeScreen(props) {
    const { navigation } = props;
    const [newestRecipes, setNewestRecipes] = useState([]);
    const [searchedRecipes, setSearchedRecipes] = useState([]);
    const [user, setUser] = React.useState({
        email: '',
        nickname: ''
    });

    const [tags, setTags] = React.useState([])
    const inputRef = React.useRef();
    const [inputValue, setInputValue] = React.useState('');
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
            const resp = await fetch("https://localhost:44314/api/Recipe");
            console.log(resp);
            const data = await resp.json();
            setNewestRecipes(data);
            console.log(data);
        }
        catch (error) {
            console.log(error)
        }
    };


    const fetchDataForSearch = async () => {
        try {
            console.log(tags);
            const resp = await fetch("https://localhost:44314/recipesByIngredients/" + tags);
            const data = await resp.json();
            setSearchedRecipes(data);
            console.log(data);
        }
        catch (error) {
            console.log(error)
        }
    };

    const search = () => {
        fetchDataForSearch();
    };


    const sort = () => {
        if (value == "kcal") {
            const sorted = searchedRecipes.sort((a, b) => { return a.kcal - b.kcal; });
            setSearchedRecipes([]);
            setSearchedRecipes(sorted);
            setFlatListRefresh(true);
        }
        if (value == "time") {
            console.log(parseInt(searchedRecipes[0].preparationTime.split(" ")[0]));
            const sorted = searchedRecipes.sort((a, b) => { return (parseInt(a.preparationTime.split("")[0]) + (parseInt(a.cookingTime.split("")[0]))) - (parseInt(b.preparationTime.split("")[0]) + (parseInt(b.cookingTime.split("")[0]))); });
            setSearchedRecipes([]);
            setSearchedRecipes(sorted);
            setFlatListRefresh(true);
        }
        if (value == "alphabetically") {
            const sorted = searchedRecipes.sort((a, b) => (a.name > b.name) ? 1 : -1);
            setSearchedRecipes([]);
            setSearchedRecipes(sorted);
            setFlatListRefresh(true);
        }
    };


    const isFocused = useIsFocused();
    useEffect(() => {
        setNewestRecipes([]);
        fetchData();
        loggedin();
    }, [isFocused]);

    const loggedin = () => {
        const loggedInUser = AuthService.getCurrentUser();

        if (loggedInUser.exp < Date.now() / 1000) {
            authService.logout();
            navigation.navigate("Bine ai venit");
        }

        if (loggedInUser) {
            setUser({
                ...user,
                email: loggedInUser.email,
                nickname: loggedInUser.sub
            });
        }
    }

    const inputValueChangeHandler = inputChange => {
        setInputValue(inputChange);
        if (inputChange[inputChange.length - 1] === ',') {
            setTags([...tags, inputChange.slice(0, inputChange.length - 1)]);
            setInputValue('');
        }
    }
    const cullTagFromTags = (tag) => {
        setTags([...tags.filter(element => element !== tag)])
    }

    const onPressRecipe = (item) => {
        navigation.navigate("Reteta", { item });
    };


    const wait = (timeout) => {
        return new Promise(resolve => setTimeout(resolve, timeout));
    }

    const onRefresh = React.useCallback(() => {
        setRefreshing(true);
        navigation.navigate("Profil");
        navigation.navigate("Acasa");
        wait(2000).then(() => setRefreshing(false));
    }, []);



    const renderRecipes = ({ item }) => (
        <TouchableHighlight underlayColor="rgba(73,182,77,0.9)" onPress={() => onPressRecipe(item)}>
            <Animatable.View animation={"bounceInLeft"} duration={2000} style={styles.container}>
                <Image style={styles.photo} source={{ uri: item.image }} />
                <Text style={styles.title}>{item.name}</Text>
                <Text style={styles.category}>{item.author.firstName} {item.author.lastName}</Text>
            </Animatable.View>
        </TouchableHighlight>
    );
    const renderRecipesForSearch = ({ item }) => (
        <TouchableHighlight underlayColor="rgba(73,182,77,0.9)" onPress={() => onPressRecipe(item)}>
            <Animatable.View animation={"tada"} style={styles.container}>
                <Image style={styles.photo} source={{ uri: item.image }} />
                <Text style={styles.title}>{item.name}</Text>
            </Animatable.View>
        </TouchableHighlight>
    );



    return (
        <ScrollView
            refreshControl={
                <RefreshControl
                    refreshing={refreshing}
                    onRefresh={onRefresh} />
            }>

            <Animatable.Text animation={"bounceInUp"} duration={2000} style={styles.subtitle}>Bine ai venit, {user.nickname}!</Animatable.Text>


            <Animatable.Text animation={"bounceInLeft"} duration={2000} style={styles.subtitles}>Ce ingrediente vrei sa folosesti azi?</Animatable.Text>

            <Animatable.View animation={"bounceInRight"} duration={2000} style={styles.tagArea}>
                <TextInput style={[styles.text, { fontSize: 13 }]} ref={inputRef} value={inputValue} onChange={event => inputValueChangeHandler(event.target.value)} placeholder='Introdu ingredientele, separate de virgula' className="tagArea__input" />
                <View style={styles.tagArea__displayArea}>
                    {tags.map(tag => <TagComponent text={tag} cullTagFromTags={cullTagFromTags} />)}
                </View>
                <View style={styles.searchButton}  >
                    <Button
                        onPress={search}
                        title="Cauta"
                        color="#3CB371"
                    />
                </View>

                <View style={{ marginLeft: 70, marginRight: 70, marginBottom: 100, flexDirection: 'row' }}>
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

                <View>
                    {searchedRecipes && (
                        <FlatList extraData={flatListRefresh} vertical showsVerticalScrollIndicator={false} numColumns={2} data={searchedRecipes} renderItem={renderRecipesForSearch} keyExtractor={(item) => `${item.recipeId}`} />
                    )}
                </View>

            </Animatable.View>



            <Animatable.Text animation={"bounceInLeft"} duration={2000} style={styles.subtitles}>Cele mai noi retete</Animatable.Text>
            {newestRecipes && (
                <FlatList vertical showsVerticalScrollIndicator={false} numColumns={2} data={newestRecipes.slice(-10)} renderItem={renderRecipes} keyExtractor={(item) => `${item.recipeId}`} />
            )}

        </ScrollView>
    );
}

const TagComponent = props => {
    return (
        <Animatable.View animation={"bounceIn"} style={styles.tagComponent}>
            <View style={styles.tagComponent__text} >{props.text}</View>
            <View style={styles.tagComponent__close} onClick={() => { props.cullTagFromTags(props.text) }}>X</View>
        </Animatable.View>
    )
};
