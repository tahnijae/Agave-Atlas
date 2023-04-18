import axios from 'axios';

const http = axios.create({
    baseURL: "https://localhost:44315/"
});

export default {
    getRestaurants() {
        return http.get('restaurant');
    },

    getRestaurant(id) {
        return http.get(`restaurants/${id}`);
    },

    addRestaurant(restaurant) {
        return http.post('restaurants', restaurant);
    },

    updateRestaurant(id, restaurant) {
        return http.put(`restaurants/${id}`, restaurant);
    },

    deleteRestaurant(id) {
        return http.delete(`restaurants/${id}`);
    },

    getDrinksByRestaurant(id){
        return http.get(`restaurant/${id}/drinks`);
    },

    getReviewsByRestaurant(id){
        return http.get(`restaurant/${id}/reviews`)
    },

    addReviewToRestaurant(id){
        return http.post(`restaurant/${id}/reviews`)
    }
}