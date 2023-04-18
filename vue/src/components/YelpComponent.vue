<template>
  <div id="yelp_card">
    <h2>{{ restaurant.name }}</h2>
    <div id="address">
      <h4>Address:</h4>
      <p>{{ restaurant.address }},</p>
      <p>
        {{ restaurant.city }}, {{ restaurant.state }} {{ restaurant.zipCode }}
      </p>
    </div>
    <div id="phone">
      <h4>Phone:</h4>
      <p>{{ restaurant.displayPhone }}</p>
    </div>
    <div id="info">
      <h4>Info:</h4>
      <p>This restaurant has {{ restaurant.rating}} stars based on {{restaurant.reviewCount}} reviews on Yelp!</p>
      <p><a :href="restaurant.yelpUrl">See more on Yelp. </a> </p>
    </div>
  </div>
</template>

<script>
import RestaurantService from "../services/RestaurantService.js";

export default {
  name: "yelp-component",
  components: {},
  data() {
    return {
      restaurant: {},
    };
  },
  created() {
    RestaurantService.getRestaurant(this.$route.params.id)
      .then((response) => {
        this.restaurant = response.data;
      })
      .catch((error) => {
        if (error) {
          console.log(error);
        }
      });
  },
};
</script>

<style scoped>
#yelp_card {
  border: 5px;
  border-color: #7bc950;
  background: #f3faef;
}
</style>