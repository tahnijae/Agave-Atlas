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
      <restaurant-list/>
    </div>
  </div>
</template>

<script>
import RestaurantList from '../components/RestaurantList.vue';

export default {
  name: 'Home',
  components: {
    RestaurantList
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