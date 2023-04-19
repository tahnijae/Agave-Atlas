<template>
  <div>
    <div>
      <label for="drink-search">Search All Drinks</label>
      <input id="drink-search" name="drink-search" type="text" placeholder="Guava" v-model="filterValue">
      <input type="button" class="btn success" value="Search" v-on:click="setFilter()"/>
    </div>
    <div class="drink-card-grid">
      
      <searched-drink-card class="list-group-item" v-for="drink in filterDrinks" v-bind:drink="drink" v-bind:key="drink.id" v-on:click="routeToPage($event)"/>
     
    </div>
  </div>
</template>

<script>
import DrinkService from '../services/DrinkService.js'
import SearchedDrinkCard from '../components/SearchedDrinkCard.vue'
export default {
  components: {SearchedDrinkCard},
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
    this.applyFilter();
    this.componentKey+=1;
  },
  
  applyFilter(){
    if(this.filterValue == null){
      
      this.filterDrinks = this.drinks;
    }
    this.filterDrinks = this.drinks.filter(drink =>
    {
      if(drink.description.includes(this.filterValue) || drink.name.includes(this.filterValue)){
          return this.makeDrink(drink);
    }})
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