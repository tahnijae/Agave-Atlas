<template>
  <div id="mainW">
      <h2>Forecast for Cuyahoga County, OH</h2>
      <div id = "allWeather">
            <span id="highlightedWeather">
                <div id="currentWeather" >
                    <weather-widget v-bind:period="filter"/>
                </div>
            </span>
      <div id="forecastWeather">
        <span class = "dayNames" v-for="period in periods" v-bind:key="period.id"
        v-on:mouseover="filterCurrent(period.number)">{{period.name}}</span>
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
        filter: 0,
        foundPer: {}
    }
},
methods: {
    onMouse(){

        this.tempToday = this.today;
        this.today = this.period;
    },
    offMouse(){
        this.today = this.tempToday;
    },
    filterCurrent(num) {
        this.foundPer = {};
        this.periods.filter(per => {
            if(per.number === num) {
                console.log(per);
                this.foundPer = {
                    number: JSON.parse(JSON.stringify(per.number)),
                        name: JSON.parse(JSON.stringify(per.name)),
                        detailedForecast: JSON.parse(JSON.stringify(per.detailedForecast))
                };
            }
        })
        this.filter = this.periods.indexOf(this.foundPer);
        
    }
},
created() {
    Weather.GetWeatherCuyahoga().then(response =>
        {
            response.data.properties.periods.filter(per => {
                // if(per.number === 1){
                //     this.today = JSON.parse(JSON.stringify(per));
                //     //console.log(this.today);
                //} else 
                if (!per.name.includes('Night')) {
                    let chunk = {
                        number: JSON.parse(JSON.stringify(per.number)),
                        name: JSON.parse(JSON.stringify(per.name)),
                        detailedForecast: JSON.parse(JSON.stringify(per.detailedForecast))
                    }
                    console.log(chunk);
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

<style scoped>
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
    justify-content: space-around;
};
#currentWeather{
    display: flex;
    flex-direction: column;
    width: 20%;
    max-height: 100%;
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
  text-overflow: ellipsis;
  background-color: #dcf1d0;
  border-style:solid;
  border-color:black;
  border-radius: 15px;
}
#highlightedWeather{
    padding: 20px;
    margin: 10px;
    border:2px solid black;
    max-width: 100%;
    inline-size: 20%;
}
#name{
    margin: 0;
}
.widgets{
    width:fit-content;
}
</style>