import React from 'react'
import { createStackNavigator } from '@react-navigation/stack'
import { NavigationContainer } from '@react-navigation/native'
import { createDrawerNavigator } from '@react-navigation/drawer'
import LoginScreen from '../screens/Login_SignUp/LoginScreen';
import SignUpScreen from '../screens/Login_SignUp/SignUpScreen';
import ProfileScreen from '../screens/Profile/ProfileScreen';
import SplashScreen from '../screens/Splash/SplashScreen';
import HomeScreen from '../screens/Home/HomeScreen';
import CategoriesScreen from '../screens/Categories/CategoriesScreen';
import AuthorsScreen from '../screens/Authors/AuthorsScreen';
import RecipeScreen from '../screens/Recipe/RecipeScreen';
import RecipeByUserScreen from '../screens/Recipe/RecipeByUserScreen';
import RecipesListScreen from '../screens/RecipesList/RecipesListScreen';
import RecipesByAuthorScreen from '../screens/RecipesList/RecipesByAuthorScreen';
import FavoritesScreen from '../screens/Favorites/FavoritesScreen';
import MyRecipesScreen from '../screens/MyRecipes/MyRecipesScreen';
import AddRecipesScreen from '../screens/AddRecipes/AddRecipesScreen';
import UpdateRecipesScreen from '../screens/AddRecipes/UpdateRecipesScreen';
import UsersRecipesScreen from '../screens/UsersRecipes/UsersRecipesScreen';
import DrawerContainer from '../screens/DrawerContainer/DrawerContainer';

import SearchScreen from '../screens/Search/SearchScreen';


const Stack = createStackNavigator();

function MainNavigator() {
  return (
    <Stack.Navigator
      screenOptions={{
        headerTitleStyle: {
          fontWeight: 'bold',
          textAlign: 'center',
          alignSelf: 'center',
          flex: 1,
        }
      }}
    >
      <Stack.Screen name='Bine ai venit' component={SplashScreen} />
      <Stack.Screen name='Autentificare' component={LoginScreen} />
      <Stack.Screen name='Inregistrare' component={SignUpScreen} />
      <Stack.Screen name='Acasa' component={HomeScreen} />
      <Stack.Screen name='Profil' component={ProfileScreen} />
      <Stack.Screen name='Categorii' component={CategoriesScreen} />
      <Stack.Screen name='Autori' component={AuthorsScreen} />
      <Stack.Screen name='Favorite' component={FavoritesScreen} />
      <Stack.Screen name='Reteta' component={RecipeScreen} />
      <Stack.Screen name='Reteta utilizatorului' component={RecipeByUserScreen} />
      <Stack.Screen name='Categorie' component={RecipesListScreen} />
      <Stack.Screen name='Retetele autorilor' component={RecipesByAuthorScreen} />
      <Stack.Screen name='Retetele mele' component={MyRecipesScreen} />
      <Stack.Screen name='Adauga reteta' component={AddRecipesScreen} />
      <Stack.Screen name='Actualizeaza reteta' component={UpdateRecipesScreen} />
      <Stack.Screen name='Retetele utilizatorilor' component={UsersRecipesScreen} />
      <Stack.Screen name='Cauta' component={SearchScreen} />

    </Stack.Navigator>
  )
}



const Drawer = createDrawerNavigator();

function DrawerStack() {
  return (
    <Drawer.Navigator
      drawerPosition='left'
      initialRouteName='Main'
      drawerStyle={{
        width: 250
      }}
      screenOptions={{ headerShown: false }}
      drawerContent={({ navigation }) => <DrawerContainer navigation={navigation} />}
    >
      <Drawer.Screen name='Main' component={MainNavigator} />
    </Drawer.Navigator>
  )
}


export default function AppContainer() {
  return (
    <NavigationContainer>
      <DrawerStack />
    </NavigationContainer>
  )
}


console.disableYellowBox = true;