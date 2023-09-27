import { StyleSheet, Dimensions } from 'react-native';

const { width: viewportWidth } = Dimensions.get('window');

const styles = StyleSheet.create({
  container: {
    backgroundColor: '#f0fff0',
    flex: 1,
    borderColor: '#3CB371',
    borderWidth: 4,
    borderRadius: 50
  },
  carouselContainer: {
    minHeight: 250
  },
  carousel: {},

  image: {
    ...StyleSheet.absoluteFillObject,
    width: '100%',
    height: 400,


  },
  imageContainer: {
    flex: 1,
    justifyContent: 'center',
    width: viewportWidth,
    height: 400
  },
  paginationContainer: {
    flex: 1,
    position: 'absolute',
    alignSelf: 'center',
    paddingVertical: 8,
    marginTop: 200
  },
  paginationDot: {
    width: 8,
    height: 8,
    borderRadius: 4,
    marginHorizontal: 0
  },
  infoRecipeContainer: {
    flex: 1,
    margin: 25,
    marginTop: 0,
    justifyContent: 'center',
    alignItems: 'center'
  },
  infoContainer: {
    flex: 1,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'flex-start',
  },
  buttonContainer: {
    flex: 1,
    flexDirection: 'row',
    alignItems: 'center',
    justifyContent: 'flex-start',
  },
  infoPhoto: {
    height: 20,
    width: 20,
    marginRight: 0
  },
  infoRecipe: {
    fontSize: 14,
    fontWeight: 'bold',
    marginLeft: 5,
    marginTop: 100
  },
  category: {
    fontSize: 13,
    fontWeight: 'bold',
    margin: 10,
    color: '#05375a'
  },
  subtitle: {
    color: '#05375a',
    fontSize: 22,
    fontWeight: 'bold',
    marginTop: 20,
    textAlign: "center"
  },
  infoDescriptionRecipe: {
    textAlign: 'left',
    fontSize: 16,
    marginTop: 30,
    margin: 15
  },
  infoRecipeName: {
    fontSize: 28,
    margin: 10,
    marginTop: 450,
    fontWeight: 'bold',
    color: '#05375a',
    textAlign: 'center'
  },
  infoRecipeProperties: {
    fontSize: 15,
    margin: 10,
    fontWeight: 'bold',
    color: '#3CB371',
    textAlign: 'center'
  },
  infoAuthor: {
    fontSize: 20,
    fontWeight: 'bold',


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
