<template>
  <div>
      <div id="fullDay">
          <span id="info">
          <p id="name">{{period.name}}</p>
          <p id="details">{{period.detailedForecast}}</p>
          </span>
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

<style scoped>
#fullDay{
    display: flex;
    flex-direction: column;
    
}
#info{
    height: 15vh;
    width: 14%;
}
p{
    display:inline-block;
}

</style>