<template>
  <div> 
       <div class="restaurant-cards" v-for="restaurant in restaurants"
        :key="restaurant.id">
      <div class="card">
      <div class="card-header">
          <h2> {{restaurant.name}} </h2>
      </div>
      <div class = "card-body">
          <p>{{restaurant.address}}</p>
      </div>
    </div>
  </div>
  </div>
</template>

<script>
//import RestaurantCard from './RestaurantCard.vue'
import restaurantService from '../services/RestaurantService'

export default {
    name: "restaurant-list",
    //components: { RestaurantCard },
    props:[ 'restaurant' ],
    data(){
      return{
      restaurants:[
        {
          name : 'test',
          address : 'test',
        },
        {
          name : 'test2',
          address : 'test2',
        },
      ]
    }
    },
    created(){
      restaurantService.getRestaurants().then((response)=>{
        this.restaurants=response.data;
      })
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