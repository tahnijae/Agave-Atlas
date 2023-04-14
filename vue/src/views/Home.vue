<template>
  <div class = 'main'>
    <navigation-bar />
      <weather-output id="weather"/>
    <div class="restaurant-list">
      <h2>Locations:</h2>
      <restaurant-list />
    </div>
  </div>
</template>
<script>
import RestaurantList from "../components/RestaurantList.vue";
import WeatherOutput from '../components/WeatherOutput.vue';
import NavigationBar from '../components/NavigationBar.vue'
import authService from "../services/AuthService.js";

export default {
  name: "Home",
  components: {
    RestaurantList,
    WeatherOutput,
    NavigationBar
  },
  data() {
    return {
      isAuthenticated: false, // Set to false by default
      restaurants: [],
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
    }
  },
  computed: {}
};
</script>
<style scoped>
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
  margin: 5rem 0 1rem 0;
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
