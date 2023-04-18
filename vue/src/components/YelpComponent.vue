<template>
  <div>
      <p>{{Restaurant}}</p>
  </div>
</template>

<script>
import yelpService from "../services/YelpService.js";

export default {
  name: "yelp-component",
  components: {},
  data(){
    return{
      Restaurant: {}
    }
  },
  created() {
    yelpService.GetBusinessByNameAndZip("barrio", "44113").then(response => {
      this.Restaurant = response.data;})
  },
  
}
</script>

<style>

</style>