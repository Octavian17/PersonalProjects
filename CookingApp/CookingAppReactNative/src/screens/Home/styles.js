import { StyleSheet } from "react-native";
import { RecipeCard } from "../../AppStyles";
import { Dimensions } from 'react-native';
const { width, height } = Dimensions.get('window');
const SCREEN_WIDTH = width < height ? width : height;
const recipeNumColums = 2;
const RECIPE_ITEM_HEIGHT = 150;
const RECIPE_ITEM_MARGIN = 20;
const ratio = SCREEN_WIDTH / 541;

const styles = StyleSheet.create({
    container: {
        flex: 1,
        margin: 10,
        justifyContent: 'center',
        alignItems: 'center',
        height: 200,
        borderColor: '#3CB371',
        borderWidth: 3,
        borderRadius: 20,
        width: (SCREEN_WIDTH - (recipeNumColums + 1) * RECIPE_ITEM_MARGIN) / recipeNumColums,
        height: RECIPE_ITEM_HEIGHT + 75,
        backgroundColor: '#3CB371'
    },
    photo: {
        width: '100%',
        height: 150,
        borderRadius: 20,
        borderBottomLeftRadius: 0,
        borderBottomRightRadius: 0,
        shadowColor: 'blue',
        shadowOffset: {
            width: 0,
            height: 3
        },
        shadowRadius: 5,
        shadowOpacity: 1.0,
        elevation: 3,
        backgroundColor: 'white'
    },
    title: {
        flex: 1,
        fontSize: 16,
        fontWeight: 'bold',
        textAlign: 'center',
        color: '#333333',
        marginTop: 8,

    },
    category: {
        marginTop: 5,
        marginBottom: 5
    },
    subtitle: {
        color: '#05375a',
        fontSize: 24,
        fontWeight: 'bold',
        marginTop: 15,
        textAlign: "center"
    },
    subtitles: {
        color: '#05375a',
        fontSize: 20,
        fontWeight: 'bold',
        marginTop: 35,
        marginLeft: 8
    },

    container1: RecipeCard.container,
    photo1: RecipeCard.photo,
    title1: RecipeCard.title,
    category1: RecipeCard.category,
    btnIcon: {
        height: 14,
        width: 14,
    },
    searchContainer: {
        flexDirection: "row",
        alignItems: "center",
        backgroundColor: "#EDEDED",
        borderRadius: 10,
        width: 250,
        justifyContent: "space-around"
    },
    searchIcon: {
        width: 20,
        height: 20,
        tintColor: 'grey'
    },
    searchInput: {
        backgroundColor: "#EDEDED",
        color: "black",
        width: 180,
        height: 50,
    },
    tagArea: {
        display: "flex"
    },
    tagArea__displayArea: {
        display: "flex",
        justifyContent: 'center',
        alignItems: "center",
    },
    text: {
        marginLeft: 50,
        marginRight: 50,
        padding: 15,
        fontWeight: 'bold',

    },
    tagComponent: {
        alignItems: "center",
        marginTop: 10,
        width: 200,
        height: 45,
        justifyContent: 'center',
        padding: 10,
        borderRadius: 100,
        backgroundColor: '#3CB371',
    },
    tagComponent__text: {
        color: "white",
        fontFamily: "sans-serif",
        fontSize: 13

    },
    tagComponent__close: {
        marginLeft: 0.5,
        fontSize: 8,
        fontFamily: "sans-serif",
        color: "white",

    },
    searchButton: {
        marginTop: 13,
        marginLeft: 50,
        marginRight: 50,
        padding: 16
    },
    indicator: {
        flex: 1,
        alignItems: 'center',
        justifyContent: 'center',
        height: 80
    },
    scrollView: {
        flex: 1,
        backgroundColor: 'pink',
        alignItems: 'center',
        justifyContent: 'center',
    },
    dropdown: {
        paddingVertical: 50
    },
    sort: {
        backgroundColor: '#3CB371',
        flex: 2,
        width: 100,
        height: 100,
        justifyContent: 'center',
        alignItems: 'center',
        padding: 10,
        borderRadius: 100
    }

});

export default styles;
