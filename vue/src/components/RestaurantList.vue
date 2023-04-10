<template>
  <div> 
       <div class="restaurant-cards" v-for="restaurant in restaurants"
        :key="restaurant.id">
        <restaurant-card/>
    </div>
  </div>
</template>

<script>
import RestaurantCard from './RestaurantCard.vue'

export default {
    name: "restaurant-list",
    components: { RestaurantCard },
    props:[ 'restaurant' ],
    data(){
      return{
      restaurants:[
        {
          name : 'test',
          address : 'test',
        },
        {
          name : 'test',
          address : 'test',
        },
      ]
    }
    }
}
</script>

<style>
  /* Style for restaurant list */
</style>