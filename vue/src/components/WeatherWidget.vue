<template>
  <div>
      <div id="fullDay" v-on:mouseover="hover = true" v-on:mouseleave="hover = false">
          <div id="info">
          <p id="name" v-show="!hover">{{period.name}}</p>
          <p id="details" v-show="hover">{{period.detailedForecast}}</p>
          </div>
      </div>
  </div>
</template>

<script>
export default {
    name: "weather-widget",
    data(){
        return{
            hover: false
        }
    },
props: ["period"]
}
</script>

<style>
#fullDay{
    display: flex;
    flex-direction: column;
    
}
#info{
    height: 15vh;
    width: 5vw;
}
p{
    display:inline-block;
}

</style>