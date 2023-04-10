import axios from 'axios';

const http = axios.create({
    baseURL: "http://localhost:44351"
});

export default {
    getRestaurants() {
        return http.get('/');
    },

    getRestaurant(id) {
        return http.get(`/restaurants/${id}`);
    },

    addRestaurant(restaurant) {
        return http.post('/restaurants', restaurant);
    },

    updateRestaurant(id, restaurant) {
        return http.put(`/restaurants/${id}`, restaurant);
    },

    deleteRestaurant(id) {
        return http.delete(`/restaurants/${id}`);
    }
}