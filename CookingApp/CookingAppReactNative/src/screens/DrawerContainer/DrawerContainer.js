import React, { useEffect } from "react";
import { View } from "react-native";
import PropTypes from "prop-types";
import styles from "./styles";
import MenuButton from "../../components/MenuButton/MenuButton";
import AuthService from "../../service/authService";

export default function DrawerContainer(props) {
  const { navigation } = props;

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

  useEffect(() => {
    loggedin();
    console.log(user.email);
  }, []);

  return (
    <View style={styles.content}>
      <View style={styles.container}>
        <MenuButton
          title="ACASA"
          source={require("../../../assets/icons/home.png")}
          onPress={() => {
            // window.location.reload(false);
            navigation.navigate("Acasa");
            navigation.closeDrawer();
          }}
        />

        <MenuButton
          title="PROFIL"
          source={require("../../../assets/icons/profile.png")}
          onPress={() => {
            navigation.navigate("Profil");
            navigation.closeDrawer();
          }}
        />

        <MenuButton
          title="FAVORITE"
          source={require("../../../assets/icons/favorites.png")}
          onPress={() => {
            navigation.navigate("Favorite", { user });
            navigation.closeDrawer();
          }}
        />
        <MenuButton
          title="CATEGORII"
          source={require("../../../assets/icons/category.png")}
          onPress={() => {
            navigation.navigate("Categorii");
            navigation.closeDrawer();
          }}
        />
        <MenuButton
          title="AUTORI"
          source={require("../../../assets/icons/authors.png")}
          onPress={() => {
            navigation.navigate("Autori");
            navigation.closeDrawer();
          }}
        />
        <MenuButton
          title="CAUTA"
          source={require("../../../assets/icons/search.png")}
          onPress={() => {
            navigation.navigate("Cauta");
            navigation.closeDrawer();
          }}
        />
        <MenuButton
          title="RETETELE MELE"
          source={require("../../../assets/icons/myRecipes.png")}
          onPress={() => {
            navigation.navigate("Retetele mele", { user });
            navigation.closeDrawer();
          }}
        />
        <MenuButton
          title="RETETELE UTILIZATORILOR"
          source={require("../../../assets/icons/usersRecipes.png")}
          onPress={() => {
            navigation.navigate("Retetele utilizatorilor", { user });
            navigation.closeDrawer();
          }}
        />
        <MenuButton
          title="DELOGARE"
          source={require("../../../assets/icons/logout.png")}
          onPress={() => {
            AuthService.logout();
            navigation.navigate("Bine ai venit");
            navigation.closeDrawer();
          }}
        />
      </View>
    </View>
  );
}

DrawerContainer.propTypes = {
  navigation: PropTypes.shape({
    navigate: PropTypes.func.isRequired,
  }),
};
