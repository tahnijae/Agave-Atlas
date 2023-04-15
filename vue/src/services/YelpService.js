import axios from 'axios';

const apiKey = process.env.local.YELP_API_KEY;

const http = axios.create({
    baseURL: "https://api.yelp.com/v3/businesses/search"
});


export default {
    GetBusinessByNameAndZip(name, zipcode) {
        let options = {
            method: 'GET',
            url: http,
            params: { location: zipcode, term: name, sort_by: 'best_match', limit: '20' },
            headers: {
                accept: 'application/json',
                Authorization: `BEARER ${apiKey}`
            }
        };
        return http.request(options)
            // fetch(`?location=${zipcode}&term=${name}&sort_by=best_match&limit=20`, options)
            //     .then(response => response.json())
            //     .then(response => console.log(response))
            //     .catch(err => console.error(err));

        //return http.get(`?location=${zipcode}&term=${name}&sort_by=best_match&limit=5`)


    }
}