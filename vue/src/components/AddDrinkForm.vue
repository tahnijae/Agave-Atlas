<template>
  <div class = "drinkForm">
      <form v-on:submit="submitForm">
        <h3>Add a Drink!</h3>
        <label for="name">Drink Name:</label>
        <input id="name" type="text" v-model="drink.name"/>

        <label for="description">Description:</label>
        <input id="description" type="text" v-model="drink.description"/>

        <label for='isFrozen'>Frozen:</label>
        <input id="isFrozen" type="checkbox" v-model="drink.isFrozen"/>
        
        <button type='submit'>Submit</button>
        
      </form>
  </div>
</template>

<script> 
import drinkService from '../services/DrinkService.js'

export default {
name: "drink-form",
data(){
  return{
    drink: {
      name:'',
      description:'',
      isFrozen:false,
    }
  }
},
methods:{
  submitForm(){
    const newdrink = {
      restaurantID: Number(this.$route.params.id),
      Name: this.name,
      Description: this.description,
      isFrozen: this.isFrozen
    }

    drinkService.addNewDrink(newdrink).then((response)=>{
      console.log(response);
    });
   // this.resetDrink();

  },
  resetDrink(){
    this.drink = {
      name:'',
      description:'',
      isFrozen:false,
    }
  }

}
}


 </script>

<style>
.drinkForm{
  margin-top:30px;
}
</style>