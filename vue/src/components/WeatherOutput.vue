<template>
  <div id="mainW">
      <h2>Forecast for {{cityName}}, {{stateAbb}}</h2>
      <label for="zipCode">Input Zip Code </label>
      <input type="text" pattern="[0-9]*" id="zipCode" name="zipCode" placeholder="44118" v-model="zipCode"/>
      <input type="button" v-on:click="updateWeather(zipCode)" value="GO"/>
      <div id = "allWeather">
            <div id="forecastWeather">
                <span class = "dayNames" v-for="period in periods" v-bind:key="period.id"
                v-on:mouseover="filterCurrent(period)">{{period.name}}
                </span>
            </div>
            <span id="highlightedWeather">
                <div id="currentWeather" >
                    <weather-widget v-bind:period="periods[filter]"/>
                </div>
            </span>
      
      </div>
  </div>
</template>


<script>
import Weather from '../services/WeatherService.js'
import WeatherWidget from './WeatherWidget.vue'
import ZipCodeService from '../services/ZipCodeService'

export default {
    components: {WeatherWidget},
data(){
    return {
        periods: [],
        filter: 0,
        zipCode: '',
        newLat: '',
        newLong: '',
        cityName: 'Cleveland',
        stateAbb: 'OH'
    }
},
methods: {
    filterCurrent(num) {
        this.filter = this.periods.indexOf(num);
    },
    setWeatherPeriods(resp){
        this.periods = [];
        resp.data.properties.periods.filter(per => {
                if (!per.name.includes('Night')) {
                    let chunk = {
                        number: JSON.parse(JSON.stringify(per.number)),
                        name: JSON.parse(JSON.stringify(per.name)),
                        detailedForecast: JSON.parse(JSON.stringify(per.detailedForecast))
                    }
                    this.periods.push(chunk);
    }})},
    updateWeather(zip){
        
        ZipCodeService.GetCityByZipcode(zip).then(response =>
        {
            console.log(response.data)
            this.newLat = response.data.places[0].latitude;
            this.newLong = response.data.places[0].longitude;
            this.cityName = response.data.places[0]["place name"];
            this.stateAbb = response.data.places[0]["state abbreviation"];
            //console.log(this.newLat + ', ' + this.newLong);
            Weather.GetWeatherByCoordinate(this.newLat, this.newLong).then(response => {
                console.log(response);
            this.setWeatherPeriods(response);
        }

        ).catch(error => {
            
               alert(`${error.response.status}: Error retrieving weather data for ${this.cityName}`);
            
        })
        }).catch(error => {
        alert(`${error.response.status}: Error finding City with zip code "${this.zipCode}"`);
           
        })
    }
},
created() {
    Weather.GetWeatherCuyahoga().then(response =>
        {
            response.data.properties.periods.filter(per => {
                if (!per.name.includes('Night')) {
                    let chunk = {
                        number: JSON.parse(JSON.stringify(per.number)),
                        name: JSON.parse(JSON.stringify(per.name)),
                        detailedForecast: JSON.parse(JSON.stringify(per.detailedForecast))
                    }
                    //console.log(chunk);
                    this.periods.push(chunk);
                    //console.log(this.periods[0].name);
                }
                
            });     
        }).catch(error =>
    {
        if(error){
            console.log(error);
        }
    })
}
}
</script>

<style scoped>
#allWeather{
    display: flex;
    flex-direction: column;
    height: 70%;
    align-items: center;
    justify-content: space-between;
}
#forecastWeather{
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    grid-area: next;
    width: 80%;
    justify-content: space-around;
};
#currentWeather{
    display: flex;
    flex-direction: column;
    width: 100%;
    max-height: 100%;
    grid-area: today;
}
#mainW{
display: grid;
  align-items: center;
  justify-content: center;
  grid-template-areas: 
  "today next next next next next next"
  "today next next next next next next";
  height: 100px;
  text-overflow: ellipsis;
  background-color: #dcf1d0;
  border-style:solid;
  border-color:black;
  border-radius: 15px;
}
#highlightedWeather{
    /* padding: 20px; */
    margin: 10px;
    border:2px solid black;
    border-style: solid hidden none hidden;
    max-width: 100%;
    height: 100%;
    inline-size: 80%;
    position: inherit;
}
#name{
    margin: 0;
}
.widgets{
    width:fit-content;
}
h2{
    margin: 0 0 20px 0;
}
</style>