import axios from 'axios';

const http = axios.create({
    baseURL: "https://api.weather.gov"
});

export default {
GetWeatherCuyahoga(){
    return http.get('/zones/county/OHZ011/forecast')
}
}