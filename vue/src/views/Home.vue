<template>
  <div class="home">
    <h1>Home</h1>
    <p>You must be authenticated to see this</p>
     <div class="restaurant-cards">
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
  name: "Home",
  components: {
    RestaurantCard,
  },
};
</script>
