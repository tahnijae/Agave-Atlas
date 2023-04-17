<template>
  <div>
      <p></p>
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
    yelpService.GetBusinessByNameAndZip().then(response => {
      this.Restaurant = response.data;})
  },
  
}
</script>

<style>

</style>