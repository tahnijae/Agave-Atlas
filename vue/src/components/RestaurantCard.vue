<template>
  <div class="card container" v-on:click="seeDrinks(restaurant.restaurant_ID)">
    <img width="100%" :src="require(`@/assets/${restaurant.name.replace(/\s+/g, '')}${restaurant.zipCode}.jpg`)">
    <div class="centered">
      <h2>{{ restaurant.name }}</h2>
    
      <p>{{locationData["place name"]}}, {{locationData["state abbreviation"]}}</p>
    </div>
  </div>
</template>

<script>
import zipcodeService from '../services/ZipCodeService.js';
export default {
    name: "restaurant-card",
    props: ["restaurant"],
    data(){
      return{
        locationData: [],
      }

    },
    methods:{
    seeDrinks(id){
      
      this.$router.push(`/restaurant/${id}/drinks`);
    },
  },
  computed:{
  cardClass(){
    const name = this.restaurant.name.toLowerCase().replace(/[^a-z0-9]+/g, `_`);
    return `card-${name}_bg`;
  }
    
  },
  created() {
      zipcodeService.GetCityByZipcode(this.restaurant.zipCode).then((response) => {
        this.locationData = response.data.places[0];
        this.state = response.data.places.state;
        
      });
    }
};
</script>

<style scoped>
.card {
  display: flex;
  flex-direction: column;
  background-color: #fff;
  border: 1px solid #eaeaea;
  border-radius: 10px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  margin-bottom: 20px;
  font-family: Verdana, Geneva, Tahoma, sans-serif;
}

h2 {
  text-align: center;
}

.card-header {
  background-color: #7bc950;
  border-bottom: 1px solid #eaeaea;
  padding: 10px;
}

.card-body {
  padding: 10px;
}
.container {
  position: relative;
  text-align: center;
  color: white;
}
.centered {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background: rgb(0, 0, 0); 
  background: rgba(0, 0, 0, 0.7);
  padding: 20px;
}
</style>