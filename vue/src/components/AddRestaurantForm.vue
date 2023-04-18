<template>
  <div class="addRestaurantForm">
    <button
      class="addRestaurant"
      v-if="!showAddRestaurantForm && isAuthenticated && !hideButton"
      v-on:click="showAddRestaurantForm = !showAddRestaurantForm"
    >
      Looking For Somewhere Else?
    </button>
    <form v-on:submit.prevent="submitForm" v-if="showAddRestaurantForm">
      <label for="name">Name:</label>
      <input id="name" type="text" class="input" v-model="restaurantInput.name" />
      <label for="city">City:</label>
      <input id="city" type="text" class="input" v-model="restaurantInput.city" />
      <label for="state">State:</label>
      <input id="state" type="text" class="input" v-model="restaurantInput.state" />
      <label for="zipCode">Zipcode:</label>
      <input id="zipCode" type="text" class="input" v-model="restaurantInput.zipCode"/>
      <button @click.prevent="GenerateYelpInfo">Search</button>

      <button v-on:click="showAddRestaurantForm = !showAddRestaurantForm">
        Cancel
      </button>
    </form>
    <div v-if="haveYelpData">
      <button>Looks Good!</button>
      <button v-on:click="showAddRestaurantForm = !showAddRestaurantForm">Try Again</button>
      <button>Cancel</button>
      <yelp-component v-bind:restaurant="yelpReturn" />
    </div>
  </div>
</template>
<script>
import RestaurantService from "../services/RestaurantService";
import YelpComponent from "./YelpComponent.vue";
import yelpService from "../services/YelpService.js";

//FIX BUTTONS (MAKE METHODS TO SET BOOLS), MAKE ADD METHOD

export default {
  name: "add-new-restaurant",
  props: {
    isAuthenticated: {
      type: Boolean,
      required: true,
    },
  },
  components: { YelpComponent },
  data() {
    return {
      restaurantInput: {
        name: "",
        city: "",
        state: "",
        zipCode: "",
       // RestaurantID: Number(this.$route.params.id),
      },
      showAddRestaurantForm: false,
      hideButton: false,
      isLoggedIn: false,
      haveYelpData: false,
      yelpReturn: {},
    };
  },
  created() {
    this.isLoggedIn = this.$store.state.token !== "";
  },
  methods: {
    submitForm() {
      RestaurantService.addRestaurant(this.restaurantInput).then((response) => {
        if (response.status === 200) {
          this.$emit("restaurantAdded");
          this.showAddRestaurantForm = false;
          this.restaurantInput = {
            name: "",
            city: "",
            state: "",
            zipCode: "",
          };
        }
      });
    },
    GenerateYelpInfo() {
      let yelpSearch = {
        name: this.restaurantInput.name,
        zipcode: this.restaurantInput.city + " " + this.restaurantInput.state + " " + this.restaurantInput.zipCode,
      };
      yelpService
        .GetBusinessByNameAndZip(yelpSearch)
        .then((response) => {
          this.yelpReturn = response.data;
          this.haveYelpData = true;
          this.showAddRestaurantForm = false;
          this.hideButton = true;
          console.log(this.yelpReturn);
        })
        .catch((error) => {
          console.log(error);
        });
    },
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