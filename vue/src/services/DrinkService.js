import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315/"
});

export default {
    getAllDrinks(){
        return http.get('drink');
    },

    getDrinkById(id){
        return http.get(`drink/${id}`);
    },
    AddDrink(drink){
        return http.post(`drink`,drink);
    },
    UpdateDrink(id,drink){
        return http.put(`drink/${id}`,drink);
    },
    DeleteDrink(id){
        return http.delete(`drink/${id}`);
    }
}