<template>
  <div id="mainW">
      <h2>Forecast for Cuyahoga County, OH</h2>
      <div id = "allWeather">
      <div id="currentWeather" >
          <p id="name" >{{today.name}}</p>
          <p id="details">{{today.detailedForecast}}</p>
      </div>
      <div id="forecastWeather">
        <weather-widget 
        v-for="period in periods"
        v-bind:key="period.id"
        v-bind:period="period" 
        v-on:mouseover="onMouse"
        v-on:mouseleave="offMouse"
        />
      </div>
      </div>
  </div>
</template>


<script>
import Weather from '../services/WeatherService.js'
import WeatherWidget from './WeatherWidget.vue'

export default {
    components: {WeatherWidget},
data(){
    return {
        today: {},
        periods: [],
        tempToday: {}
    }
},
methods: {
    onMouse(){

        this.tempToday = this.today;
        this.today = this.period;
    },
    offMouse(){
        this.today = this.tempToday;
    }
},
created() {
    Weather.GetWeatherCuyahoga().then(response =>
        {
            response.data.properties.periods.filter(per => {
                if(per.number === 1){
                    this.today = JSON.parse(JSON.stringify(per));
                    //console.log(this.today);
                } else if (!per.name.includes('Night')) {
                    let chunk = {
                        number: JSON.parse(JSON.stringify(per.number)),
                        name: JSON.parse(JSON.stringify(per.name)),
                        detailedForecast: JSON.parse(JSON.stringify(per.detailedForecast))
                    }
                    //console.log(chunk.number);
                    this.periods.push(chunk);
                    console.log(this.periods[0].name);
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

<style>
#allWeather{
    display: flex;
    flex-direction: row;
    height: 50%;
}
#forecastWeather{
    display: flex;
    flex-direction: row;
    flex-wrap: wrap;
    grid-area: next;
    width: 80%;
    justify-content: space-between;
};
#currentWeather{
    display: flex;
    flex-direction: column;
    width: 20%;
    grid-area: today;
}
#main{
    display: grid;
  align-items: center;
  justify-content: center;
  grid-template-areas: 
  "today next next next next next next"
  "today next next next next next next";
  height: 100px;
  background-color: #dcf1d0;
  border-style:solid;
  border-color:black;
  border-radius: 15px;
}
</style>