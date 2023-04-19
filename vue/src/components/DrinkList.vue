<template>
  <div class="drink-list-container">
    <yelp-component class="yelp" v-bind:restaurant="restaurant" />
    <div class="drink-card-grid">
      <!-- <h1>{{restaurant.name}}</h1> -->
      <!-- <button v-on:click=GenerateYelpInfo>Get Info</button>
      <div v-if="haveYelpData">
          <p> Yelp ID : {{yelpReturn.yelpId}}</p>
          <p> Address : {{yelpReturn.address}}, {{yelpReturn.city}}, {{yelpReturn.state}}</p>
        </div>
      </div> -->
    
      <drink-card
      class = "list-group-item"
      v-for="drink in drinks" 
      v-bind:key="drink.id"
      v-bind:drink="drink"/>
    </div>
  </div>
</template>

<script>

import DrinkCard from "./DrinkCard.vue";
import RestaurantService from "../services/RestaurantService.js"
import YelpComponent from './YelpComponent.vue';
//import yelpService from "../services/YelpService.js";

export default {
    components: {DrinkCard, YelpComponent
    
    },
data() {
    return {
        drinks: [],
        restaurant: {},
        yelpReturn: {},
        haveYelpData: false
    }
},
computed: {},
created(){
    RestaurantService.getDrinksByRestaurant(this.$route.params.id)
    .then((response) => {
        this.drinks = response.data;
    })
    .catch((error) => {
        if(error) {
            console.log(error);
        }
    });
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
  methods: {
    // GenerateYelpInfo(){
    //   let yelpSearch = {
    //       name: this.restaurant.name,
    //       zipcode: this.restaurant.zipCode};
    //   yelpService.GetBusinessByNameAndZip(yelpSearch).then((response) => {
    //   this.yelpReturn = response.data;
    //   this.haveYelpData = true;
    //   console.log(this.yelpReturn)
    //   })
    //   .catch(error => {
    //     console.log(error)});
    //}
  }
}
</script>

<style>
/* .drink-list-container{
  margin-top: 100px;
  font-family: Verdana, Geneva, Tahoma, sans-serif;
}

.drink-card-grid{
  display: grid;
  grid-template-columns: repeat(4,minmax(200px, 1fr));
  grid-gap: 1rem;
  background-color: #def7d0;
}

.drink-card{
  border: 1px black solid;
    font-family: Verdana, Geneva, Tahoma, sans-serif;

}

h1{
  text-align: center;
    font-family: Verdana, Geneva, Tahoma, sans-serif;

}


/* div.main {
  margin: 1rem 0;
}
div.main div.well-display {
  display: flex;
  justify-content: space-around;
  margin-bottom: 1rem;
}

div.main div.well-display div.well {
  display: inline-block;
  width: 15%;
  border: 1px black solid;
  border-radius: 6px;
  text-align: center;
  margin: 0.25rem;
  padding: 0.25rem;
  
}

.card-header {
  background-color: #7bc950;
  border-bottom: 1px solid #eaeaea;
  padding: 10px;
}

.card-body {
  padding: 10px;
} */


</style>