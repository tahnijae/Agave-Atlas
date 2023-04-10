<template>
  <div>
     <h1>Marg Spots</h1> 
       <div class="restaurant-cards">
      <restaurant-card
        v-for="restaurant in restaurants"
        :key="restaurant.id"
        :name="restaurant.name"
        :address="restaurant.address"
      />
    </div>
  
  </div>
</template>

<script>
import RestaurantCard from './RestaurantCard.vue'

export default {
    name: "restaurant-list",
    components: { RestaurantCard }
}
</script>

<style>
  /* Style for restaurant list */
</style>


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

div.main div.well-display div.well span.amount {
  color: darkslategray;
  display: block;
  font-size: 2.5rem;
}

div.main div.well-display div.well {
  cursor: pointer;
}
</style>