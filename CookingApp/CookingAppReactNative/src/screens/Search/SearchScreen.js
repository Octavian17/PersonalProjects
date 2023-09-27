import React, { useEffect, useLayoutEffect, useState } from "react";
import { FlatList, Text, View, Image, TouchableHighlight, Pressable, Button } from "react-native";
import styles from "./styles";
import MenuImage from "../../components/MenuImage/MenuImage";
import * as Animatable from 'react-native-animatable';
import { TextInput } from "react-native-gesture-handler";
import DropDownPicker from 'react-native-dropdown-picker';
import { TouchableOpacity } from "react-native-gesture-handler";

export default function SearchScreen(props) {
  const { navigation } = props;
  const [recipe, setRecipe] = useState([]);
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

  const inputRef = React.useRef();
  const [inputValue, setInputValue] = React.useState('')

  const textInputChange = (val) => {
    if (val.length != 0) {
      setInputValue(val);
    } else {
      setInputValue('');
    }
  }


  const fetchData = async () => {
    try {
      const resp = await fetch("https://localhost:44314/api/Recipe/Search/" + inputValue);
      const data = await resp.json();
      setRecipe(data);
      console.log(data);
    }
    catch (error) {
      console.log(error)
    }
  };

  const search = () => {
    fetchData();
  };

  const onPressRecipe = (item) => {
    navigation.navigate("Reteta", { item });
  };

  const sort = () => {
    if (value == "kcal") {
      const sorted = recipe.sort((a, b) => { return a.kcal - b.kcal; });
      setRecipe([]);
      setRecipe(sorted);
      setFlatListRefresh(true);
    }
    if (value == "time") {
      const sorted = recipe.sort((a, b) => { return (parseInt(a.preparationTime.split(" ")[0]) + (parseInt(a.cookingTime.split(" ")[0]))) - (parseInt(b.preparationTime.split(" ")[0]) + (parseInt(b.cookingTime.split(" ")[0]))); });
      setRecipe([]);
      setRecipe(sorted);
      setFlatListRefresh(true);
    }
    if (value == "alphabetically") {
      const sorted = recipe.sort((a, b) => (a.name > b.name) ? 1 : -1);
      setRecipe([]);
      setRecipe(sorted);
      setFlatListRefresh(true);
    }
  };

  const renderRecipes = ({ item }) => (
    <TouchableHighlight underlayColor="rgba(73,182,77,0.9)" onPress={() => onPressRecipe(item)}>
      <Animatable.View animation={"tada"} style={styles.container}>
        <Image style={styles.photo} source={{ uri: item.image }} />
        <Text style={styles.title}>{item.name}</Text>
      </Animatable.View>
    </TouchableHighlight>
  );

  return (
    <View style={styles.tagArea}>
      <Animatable.Text animation={"bounceInLeft"} duration={2000} style={styles.subtitle}>Cauta retetele dupa nume</Animatable.Text>
      <Animatable.View animation={"bounceInRight"} duration={2000}>
        <TextInput placeholder="Introdu numele retetei" style={styles.text} className="tagArea__input" autoCapitalize="none" onChangeText={(val) => textInputChange(val)}></TextInput>
      </Animatable.View>
      <Animatable.View animation={"bounceInRight"} duration={2000} style={styles.searchButton}  >
        <Button
          onPress={search}
          title="Cauta"
          color="#3CB371"
          accessibilityLabel="Cauta" />
      </Animatable.View>

      <View>
        <Text style={styles.subtitle}>Sorteaza retetele cautate:</Text>
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
        {recipe && (
          <FlatList vertical showsVerticalScrollIndicator={false} numColumns={2} data={recipe} renderItem={renderRecipes} keyExtractor={(item) => `${item.recipeId}`} />
        )}
      </View>

    </View>
  );
}


