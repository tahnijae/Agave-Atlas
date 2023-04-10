<template>
  <div>
    <h1>Marg Spots</h1>
    <div class="restaurant-list">
      <RestaurantCard
        v-for="restaurant in restaurants"
        :key="restaurant.id"
        :name="restaurant.name"
        :address="restaurant.address"
      />
    </div>
  </div>
</template>

<script>
import RestaurantCard from '../components/RestaurantCard.vue';



export default {
  name: 'RestaurantList',
  components: {
    RestaurantCard
    
  },
  data() {
    return {
      restaurants: [
        {
          id: 1,
          name: "Example Restaurant 1",
          address: "123 Main St",
        },
        {
          id: 2,
          name: "Example Restaurant 2",
          address: "456 Elm St",
        },
      ],
    };
  },
};
</script>

<style>

html{
  background-color: #dcf1d0;
}
body{
  background: white;
}
.restaurant-list div{
  border-radius: 15px;
}
</style>