<template>
  <div>
     
       <div class="restaurant-cards">
      <restaurant-card
        v-for="restaurant in restaurants"
        v-bind:key="restaurant.id"
        v-bind:restaurant = restaurant
      />
    </div>
  </div>

</template>

<script>
import RestaurantCard from '../components/RestaurantCard.vue'
import RestaurantService from '../services/RestaurantService.js'

export default {
    name: "restaurant-list",
    components: { RestaurantCard },
    data () {
      return {
        restaurants: [],
      }
    },
    computed: {
      
    },
    created(){
      RestaurantService.getRestaurants().then((response) =>
      {this.restaurants = response.data})
      .catch(error =>
      {if(error){ console.log(error);}})
    }
}
</script>

<style>
  .card {
  background-color: #fff;
  border: 1px solid #eaeaea;
  border-radius: 10px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  margin-bottom: 20px;
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