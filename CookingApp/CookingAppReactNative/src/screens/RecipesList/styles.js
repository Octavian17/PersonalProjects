// import { StyleSheet } from 'react-native';
// import { RecipeCard } from '../../AppStyles';

// const styles = StyleSheet.create({
//   container: RecipeCard.container,
//   photo: RecipeCard.photo,
//   title: RecipeCard.title,
//   category: RecipeCard.category
// });

// export default styles;
import { StyleSheet } from 'react-native';
import { Dimensions } from 'react-native';

const { width, height } = Dimensions.get('window');
const SCREEN_WIDTH = width < height ? width : height;
const recipeNumColums = 2;
const RECIPE_ITEM_HEIGHT = 150;
const RECIPE_ITEM_MARGIN = 20;

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
  subtitles: {
    color: '#05375a',
    fontSize: 20,
    fontWeight: 'bold',
    marginTop: 15,
    marginLeft: 8,
    textAlign: 'center'
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
  },
  subtitle: {
    color: '#05375a',
    fontSize: 20,
    fontWeight: 'bold',
    marginTop: 20,
    textAlign: "center"
  },
  border: {
    borderColor: '#3CB371',
    borderWidth: 3,
    backgroundColor: "white"
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
  },
});

export default styles;
