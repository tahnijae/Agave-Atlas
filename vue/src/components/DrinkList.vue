<template>
  <div>
    <div>
        <h1></h1>
    </div>
    
      <drink-card
      class = "list-group-item"
      v-for="drink in drinks" 
      v-bind:key="drink.id"
      v-bind:drink="drink"/>
  </div>
</template>

<script>

import DrinkCard from "./DrinkCard.vue";
import RestaurantService from "../services/RestaurantService.js"

export default {
    components: {DrinkCard},
data() {
    return {
        drinks: [],
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

</style>