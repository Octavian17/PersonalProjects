import React, { useLayoutEffect, useState, useEffect } from "react";
import { FlatList, Text, View, TouchableHighlight } from "react-native";
import styles from "./styles";
import MenuImage from "../../components/MenuImage/MenuImage";
import * as Animatable from 'react-native-animatable';

export default function AuthorsScreen(props) {
    const { navigation } = props;
    const [authors, setAuthors] = useState([]);

    const fetchData = async () => {
        try {
            const resp = await fetch("https://localhost:44314/api/Author/GetAuthors");
            const data = await resp.json();
            console.log(data);
            setAuthors(data);
        }
        catch (error) {
            console.log(error)
        }
    };

    useEffect(() => {
        fetchData();
    }, []);

    useLayoutEffect(() => {
        navigation.setOptions({
            headerTitleStyle: {
                fontWeight: "bold",
                textAlign: "center",
                alignSelf: "center",
                flex: 1,
            },
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

    const onPressAuthor = (item) => {
        const author = item;
        navigation.navigate("Retetele autorilor", { author });
    };

    const renderAuthor = ({ item }) => (
        <TouchableHighlight underlayColor="rgba(73,182,77,0.9)" onPress={() => onPressAuthor(item)}>
            <View style={styles.categoriesItemContainer}>
                <Text style={styles.categoriesName}>{item.firstName} {item.lastName}</Text>
            </View>
        </TouchableHighlight>
    );

    return (
        <Animatable.View animation={"lightSpeedIn"}>
            <FlatList data={authors} renderItem={renderAuthor} keyExtractor={(item) => `${item.id}`} />
        </Animatable.View>
    );
}
