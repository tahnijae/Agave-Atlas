<template>
  <div class="list">
    <!-- <div id="weather" class ="grid text-center" style="--bs-columns: 3;">
    <weather-output/>
    </div> -->
    <div class="restaurant-cards" >
      <restaurant-card
        v-for="restaurant in restaurants"
        v-bind:key="restaurant.id"
        v-bind:restaurant="restaurant"
        v-bind:class="restaurantCardClass(restaurant.name)"
        
      />
    </div>
  </div>

</template>

<script>
import RestaurantCard from "./RestaurantCard.vue";
import RestaurantService from "../services/RestaurantService.js";
// import WeatherOutput from "./WeatherOutput.vue"

export default {
  methods:{
    restaurantCardClass(name){
      const className = name.toLowerCase().replace(/ /g, '-');
      return `card-${className}`
    }
  },
  name: "restaurant-list",
  components: { RestaurantCard,
   //WeatherOutput 
   },
  data() {
    return {
      restaurants: [],

    };
  },
  
  created() {
    RestaurantService.getRestaurants()
      .then((response) => {
        this.restaurants = response.data;
        console.log('DATA: '+JSON.stringify(response.data))
      })
      .catch((error) => {
        if (error) {
          console.log(error);
        }
      });
  },
};
</script>

<style>
.restaurant-cards{
  display:flex;
  flex-direction: column;
  
  
  
}


/*
.card-barrio{
  background-image: url('../assets/lakewood2.jpg');
}
.card-momocho{
  background-image: url('../assets/momocho2.jpg');
}
.card-taco_tontos{
background-image: url('../assets/tacotontos.png');
}
.card-el_carniceno{
  background-image: url('../assets/elcarnicero.jpg');
}
*/


div.main {
  margin: 1rem 0;
}
div.main div.well-display {
  display: flex;
  justify-content: space-around;
  margin-bottom: 1rem;
}

div.main div.well-display div.well {
  display: inline-block;
  width: 15%;
  border: 1px black solid;
  border-radius: 6px;
  text-align: center;
  margin: 0.25rem;
  padding: 0.25rem;
}

.card-header {
  background-color: #7bc950;
  border-bottom: 1px solid #eaeaea;
  padding: 10px;
}

.card-body {
  padding: 10px;
}
.list{
    font-family: Verdana, Geneva, Tahoma, sans-serif;

}

</style>
