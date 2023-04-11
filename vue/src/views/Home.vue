<template>
  <div>
    <nav>
  <router-link to="/"></router-link>
  <span v-if="isAuthenticated">
    <router-link to="/logout"></router-link>
  </span>
  <span v-else-if="$route.name != 'login'">
    <router-link to="/login"></router-link>
  </span>
</nav>
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
  name: 'Home',
  components: {
    RestaurantCard
  },
  data() {
    return {
      isAuthenticated: false, // Set to false by default
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
  created() {
    this.isAuthenticated = this.$store.state.token !== '';
  }
};
</script>