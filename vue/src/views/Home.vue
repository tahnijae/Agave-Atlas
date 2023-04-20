<template>
  <div class="main" ref="main">
    <navigation-bar />
          <weather-output class="weather"/>
      <!-- <yelp-component /> -->
    <div class="restaurant-list">
      <br>
      <h2>Locations</h2>
      <br>
      <restaurant-list />
      <!-- <add-restaurant-form :is-authenticated="isAuthenticated" /> -->
    </div>
     <twitter-feed />
     <footer-bar id="footer" />
  </div>
</template>
<script>
import RestaurantList from "../components/RestaurantList.vue";
import WeatherOutput from '../components/WeatherOutput.vue';
import NavigationBar from '../components/NavigationBar.vue'
import authService from "../services/AuthService.js";
import TwitterFeed from "../components/TwitterFeed.vue";
import FooterBar from '../components/FooterBar.vue';
//import AddRestaurantForm from '../components/AddRestaurantForm.vue';
//import YelpComponent from '../components/YelpComponent.vue';


export default {
  name: "Home",
  components: {
    RestaurantList,
    WeatherOutput,
    NavigationBar,
    TwitterFeed,
    FooterBar,
//    AddRestaurantForm,
    //YelpComponent,
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
 mounted() {
    window.addEventListener("scroll", () => {
    const main = this.$refs.main;
    const footer = document.querySelector("footer");
    if (main && main.offsetHeight + main.offsetTop < window.innerHeight + window.pageYOffset) {
      footer.style.opacity = 1;
    } else {
      footer.style.opacity = 0;
    }
    });
  },
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
.weather{
  grid-area: weather;
  padding: 20px;
  margin: 5rem 0 0rem 0;
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
  ". rest rest rest ."
  ". footer footer footer ."; /* Add footer to grid */
  grid-template-columns: .5fr 1fr 4fr 1fr .5fr;
  background-color: #def7d0;
  /* background-image: url('/src/assets/cheers.jpg'); */
  background-size: cover;
  background-position:center;
  background-repeat:no-repeat;
  background-attachment: fixed;
  font-family: Verdana, Geneva, Tahoma, sans-serif;
  padding-bottom: 25em; /* add padding to bottom */

}
footer {
  background-color: #F3FAEF;
  color: rgb(24, 23, 23);
  padding: 1em;
  transition: opacity 0.5s ease-out;
  opacity: 0;
  /* transition-delay: 0.5s; */
  position: fixed;
}

footer.show {
  opacity: 1;
}
footer.hide {
  transition-delay: 0s;
  transition-duration: .2s;
}
h2{
  color: Black;
}

</style>
