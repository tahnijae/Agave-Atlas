<template>
  <div id="main">
    <div class="navDiv">
      <navigation-bar class="nav"/>
    </div>
    <div id="body">
      <div id="hero-background" class="hero">
        <h1 id="hero-text" class="hero">{{restaurant.name}}</h1>
      </div>
    <img :src="restaurant.imageUrl" id="hero-image"/>
    <drink-form/>
      <div id="drink-list">
        <h1>Drinks</h1>
        <hr style="width:70%; border-color: black 2px; border-style: solid; margin: 5px auto;"/>
        <drink-list/>
      </div>
      <div id="reviews">
        <h1>Reviews</h1>
        <hr style="width:70%; border-color: black 2px; border-style: solid; margin: 5px auto;"/>
        <review-list v-bind:restaurant="restaurant"/>
      </div>
    </div>
  </div>
</template>

<script>
import DrinkList from '../components/DrinkList.vue'
import NavigationBar from '../components/NavigationBar.vue'
import drinkForm from '../components/AddDrinkForm.vue'
import RestaurantService from '../services/RestaurantService.js'
import ReviewList from '../components/ReviewList.vue'

export default {
  components: { 
    DrinkList, 
    NavigationBar,
    drinkForm,
    ReviewList
  },
  data(){
    return {
      restaurant: {},
      
    }
  },
  created(){
      {RestaurantService.getRestaurant(this.$route.params.id).then(response =>{
        
        this.restaurant = response.data;
      })
      .catch(error => {
        console.log(error.status);
      })
    }
  }

}
</script>

<style scoped>
#hero-image{
  width: 100%;
  height: 100%;
  position: sticky;
  display: block;
  grid-area: hero;
  margin: auto;
}
h1{
  text-align: center;
  margin: 5px 0 0 0;
}
#drink-list{
  grid-area: list;
}
#reviews{
  grid-area: review;
}
#hero-background{
  z-index: 100;
  margin: auto;
  position:sticky;
  width: 100%;
  background-color: rgb(128, 126, 126, .7);
  color: white;
  font-family: Arial, Helvetica, sans-serif;
  font-kerning: auto;
}
.hero{
  grid-area: hero;
  text-align: center;
}
#body{
  display: grid;
  grid-template-areas: 
  "hero hero"
  "list review";
  margin: 70px 0 0 0;
  gap: 8px;
}


</style>