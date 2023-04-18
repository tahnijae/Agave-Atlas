import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315/"
});

export default {
    getRestaurants() {
        return http.get('restaurant');
    },

    getRestaurant(id) {
        return http.get(`restaurant/${id}`);
    },

    addRestaurant(restaurant) {
        return http.post('restaurant', restaurant);
    },

    updateRestaurant(id, restaurant) {
        return http.put(`restaurant/${id}`, restaurant);
    },

    deleteRestaurant(id) {
        return http.delete(`restaurant/${id}`);
    },

    getDrinksByRestaurant(id){
        return http.get(`restaurant/${id}/drinks`);
    }
}