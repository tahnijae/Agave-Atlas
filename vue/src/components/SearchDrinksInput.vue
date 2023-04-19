<template>
  <div>
    <div>
      <label for="drink-search">Search All Drinks</label>
      <input id="drink-search" name="drink-search" type="text" placeholder="Guava" v-model="filterValue">
      <input type="button" class="btn success" value="Search" v-on:click="setFilter()"/>
    </div>
    <div class="drink-card-grid">
      <drink-card class="list-group-item" v-for="drink in filterDrinks" v-bind:drink="drink" v-bind:key="drink.id" v-on:click="routeToPage($event)"/>
    </div>
  </div>
</template>

<script>
import DrinkService from '../services/DrinkService.js'
import DrinkCard from '../components/DrinkCard.vue'
export default {
  components: {DrinkCard},
  name: "search-drinks-input",
data(){
    return{
        filterValue: '',
        drinks: [],
        filterDrinks: [],
        componentKey: 0
    }
},
methods: {
  setFilter(){
    this.filterDrinks = this.applyFilter();
    this.componentKey+=1;
  },
  routeToPage(event){
    this.$router.push(`/restaurant/${event.data.drink.restaurant_id}`);
  },
  applyFilter(){
    if(this.filterValue == null){
      console.log(this.drinks);
      this.filterDrinks = this.drinks;
    }
    this.filterDrinks.push(this.drinks.filter(drink =>
    {
      if(drink.description.includes(this.filterValue) || drink.name.includes(this.filterValue)){
          return this.makeDrink(drink);
    }}))
  },
  makeDrink(drink){
    let newDrink = {
      drinkID: JSON.stringify(drink.drinkID),
      drinkName: JSON.stringify(drink.name),
      description: JSON.stringify(drink.description),
      isFrozen: JSON.stringify(drink.isFrozen),
      restaurantID: JSON.stringify(drink.restaurantID),
      restaurantName: JSON.stringify(drink.restaurantName)
    };
    console.log(newDrink);
    return newDrink;
  }
},
created(){
  console.log(DrinkService.getAllDrinks());
  DrinkService.getAllDrinks().then(response =>
  {
    this.drinks = response.data;
  }).catch(error => {
    console.log(error.message);
  })
}
}
</script>

<style>
#cards-div{
  height: 100%;
  width: 100%;

}
</style>