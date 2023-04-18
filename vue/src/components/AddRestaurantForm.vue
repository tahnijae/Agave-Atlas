<template>
  <div class="addRestaurantForm">
    <button
      class="addRestaurant"
      v-if="!showAddRestaurantForm && isAuthenticated"
      v-on:click="showAddRestaurantForm = !showAddRestaurantForm"
    >
      Add Restaurant
    </button>
      <form v-on:submit.prevent="submitForm" v-if="showAddRestaurantForm">
          <label for="name">Name:</label>
          <input id="name" type="text" class="input" v-model="restaurant.name" />
          <label for="city">City:</label>
          <input id="city" type="text" class="input" v-model="restaurant.city" />
          <label for="state">State:</label>
          <input id="state" type="text" class="input" v-model="restaurant.state"/>
          <label for="state">Zipcode:</label>
          <input id="state" type="text" class="input" v-model="restaurant.zipCode"/>
          <button @click.prevent="submitForm">Submit</button>

          <button  v-on:click="showAddRestaurantForm = !showAddRestaurantForm">Cancel</button>
      </form>
  </div>
</template>
<script>
import RestaurantService from '../services/RestaurantService';



export default {
  name: "add-new-restaurant",
  props: {
    isAuthenticated: {
      type: Boolean,
      required: true,
    },
  },
  data() {
    return {
      restaurant: {Name: '',
      City: '',
      State: '',
      Zipcode: '',
      RestaurantID: Number(this.$route.params.id)
      },
showAddRestaurantForm: false,
    isLoggedIn : false,
    };
  },
  created() {
    this.isLoggedIn = this.$store.state.token !== "";
},
methods: {
  submitForm() {
    RestaurantService.addRestaurant(this.restaurant).then((response) => {
      if (response.status === 200) {
        this.$emit("restaurantAdded");
        this.showAddRestaurantForm = false;
        this.restaurant = {
          Name: "",
          City: "",
          State: "",
          Zipcode: "",
          RestaurantID: Number(this.$route.params.id),
        };
      }
    });
  }
},
};
</script>
<style>
.addRestaurant {
  margin: 5px 47.5%;
  padding: 5px 15px;
  background-color: #7bc950;
  color: white;
  border: none;
  border-radius: 20px;
  cursor: pointer;
}
</style>