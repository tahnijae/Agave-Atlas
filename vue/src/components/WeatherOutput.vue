<template>
  <div>
      <h2>Forecast for today in Cuyahoga County, OH</h2>
      <h4>{{forecast}}</h4>
  </div>
</template>


<script>
import Weather from '../services/WeatherService.js'
export default {
data(){
    return {
        forecast: ''
    }
},
created() {
    Weather.GetWeatherCuyahoga().then(response =>
        {
            response.data.properties.periods.filter(per =>
                {if(per.number === 1) {
                    console.log(per);
                    this.forecast = per.detailedForecast;
                }})
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

</style>