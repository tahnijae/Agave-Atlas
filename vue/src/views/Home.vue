<template>
  <div class = 'main'>
    <nav>
      <!-- <router-link to="/">Home</router-link> -->
      <span v-if="!isAuthenticated">
        <!-- <router-link to="/login" @click="login">Login</router-link> -->
      </span>
      <span v-else>
        <!-- <router-link to="/logout" @click="logout">Logout</router-link> -->
      </span>
    </nav>
      <weather-output id="weather"/>
    <div class="restaurant-list">
      <h1>Marg Spots</h1>
      <restaurant-list />
    </div>
  </div>
</template>
<script>
import RestaurantList from "../components/RestaurantList.vue";
import WeatherOutput from '../components/WeatherOutput.vue';
import authService from "../services/AuthService.js";

export default {
  name: "Home",
  components: {
    RestaurantList,
    WeatherOutput
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
    this.isAuthenticated = this.$store.state.token !== "";
  },
  methods: {
    logout() {
      authService.logout();
      this.$store.commit("LOGOUT");
      this.isAuthenticated = false;
    },
  },
};
</script>
<style>
.restaurant-list {
  text-align: center;
  margin: auto;
  width: 100%;
  grid-area: rest;
}
#banner{
  grid-area: banner;
}
#weather{
  grid-area: weather;
  padding: 20px;
  margin: 10rem 0 15rem 0;
  border: black 2px;
  border-style: solid;
  width: 100%;
  max-width: 100%;
  overflow: hidden;
  text-overflow: ellipsis;
  height: fit-content(5em);
  
}

.main{
  display: grid;
  grid-template-areas: 
  "banner banner banner banner banner"
  ". weather weather weather ."
  ". . rest . .";
  grid-template-columns: .5fr 1fr 4fr 1fr .5fr;
}



</style>
