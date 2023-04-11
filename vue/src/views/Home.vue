<template>
  <div>
    <nav>
      <router-link to="/">Home</router-link>
      <span v-if="!isAuthenticated">
        <router-link to="/login" @click="login">Login</router-link>
      </span>
      <span v-else>
        <router-link to="/logout" @click="logout">Logout</router-link>
      </span>
    </nav>
    <div class="restaurant-list">
    <h1>Marg Spots</h1>
      <restaurant-list/>
    </div>
  </div>
</template>
<script>
import RestaurantList from '../components/RestaurantList.vue';
import authService from '../services/AuthService.js'
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
  },
  methods: {
    logout() {
      authService.logout();
      this.$store.commit("LOGOUT");
      this.isAuthenticated = false;
    }
  }
};
</script>
<style scoped>
.restaurant-list{
  text-align: center;
  margin:auto;
  width:50%;
}
</style>