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
  created() {
    yelpService.GetBusinessByNameAndZip().then(response => {console.log (response.data)})
  }

}
</script>

<style>

</style>