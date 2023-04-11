<template>
  <div>
      <drink-card
      v-for="drink in drinks" 
      v-bind:key="drink.id"
      v-bind:drink="drink"/>
  </div>
</template>

<script>
//import DrinkService from "../services/DrinkService.js";
import DrinkCard from "./DrinkCard.vue";
import RestaurantService from "../services/RestaurantService.js"

export default {
    components: {DrinkCard},
data() {
    return {
        AllDrinks: [],
    }
},
computed: {},
created(){
    RestaurantService.getDrinksByRestaurant(this.$route.params.id)
    .then((response) => {
        this.drinks = response.data;
    })
    .catch((error) => {
        if(error) {
            console.log(error);
        }
    });
}
}
</script>

<style>

</style>