import axios from "axios";
const API_URL = "https://localhost:44314/api/User/";

class AuthService {

    async login(email1, password1) {
        try {
            const resp = await fetch(API_URL + "GenerateToken",
                {
                    method: 'post',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ email: email1, password: password1 })
                });
            console.log(resp.status);
            const data = await resp.text();
            console.log(data);
            if (data && resp.status != 404) {
                localStorage.setItem("user", JSON.stringify(data));
            }
            if (resp.status != 404) {
                return "loggedIn";
            }
            return data;
        }
        catch (error) {
            console.log(error);
        }
    }

    async update(email1, password1, password2, nickname1) {
        try {
            const resp = await fetch(API_URL + "UpdateUser",
                {
                    method: 'put',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ email: email1, nickname: nickname1, currentPassword: password1, newPassword: password2 })
                });
            console.log(resp);
            const data = await resp.text();
            console.log(data);

            return data;
        }
        catch (error) {
            console.log(error);
        }
    }

    async updateRecipe(id1, name1, description1, image1, kcal1, preparationTime1, cookingTime1, ingredients1, email1) {
        try {
            const resp = await fetch("https://localhost:44314/api/RecipeByUser/Update",
                {
                    method: 'put',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ id: id1, name: name1, description: description1, image: image1, kcal: kcal1, preparationTime: preparationTime1, cookingTime: cookingTime1, ingredients: ingredients1, email: email1 })
                });
            const data = await resp.text();
            console.log(data);
            //console.log(await resp.text());
            //setResponse("Actualizata cu succes!");

        }
        catch (error) {
            console.log(error);
        }
    }


    logout() {
        localStorage.removeItem("user");
    }
    async register(username1, email1, password1) {
        try {
            const resp = await fetch(API_URL + "CreateUser",
                {
                    method: 'post',
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify({ nickname: username1, email: email1, password: password1 })
                });
            console.log(resp.status);
            const data = await resp.text();
            console.log(data);

            return data;
        }
        catch (error) {
            console.log(error);
        }
    }
    getCurrentUser() {
        const token = JSON.parse(localStorage.getItem('user'));
        if (token) {
            const base64Url = token.split('.')[1];
            const base64 = base64Url.replace('-', '+').replace('_', '/');
            return JSON.parse(window.atob(base64));
        }
        else {
            return null;
        }

    }
}
export default new AuthService();