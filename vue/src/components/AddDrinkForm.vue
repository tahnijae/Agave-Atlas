<template>
  <div class = "drinkForm">
      <form v-on:submit.prevent="submitForm">
        <h3>Add a Drink!</h3>
        <label for="name">Drink Name:</label>
        <input id="name" type="text" v-model="drink.Name"/>

        <label for="description">Description:</label>
        <input id="description" type="text" v-model="drink.Description"/>

        <label for='isFrozen'>Frozen:</label>
        <input id="isFrozen" type="checkbox" v-model="drink.IsFrozen"/>
        
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
      Name:'',
      Description:'',
      IsFrozen:false,
      RestaurantID: Number(this.$route.params.id)
    }
  }
},
methods:{
  submitForm(){
    // let newDrink = {
    //   restaurantID: Number(this.$route.params.id),
    //   Name: this.name,
    //   Description: this.description,
    //   isFrozen: this.isFrozen
    // }
    //newDrink = JSON.stringify(newDrink);
    drinkService.addNewDrink(this.drink).then((response)=>{
      if(response.status === 200){
        location.reload();
      }
    }); 
  
    //location.reload() 
    //this.resetDrink();

  },
  resetDrink(){
    this.drink = {
      name:'',
      description:'',
      isFrozen:false,
      RestaurantID: this.$route.params.id,
    }
  }

}
}

 </script>

<style>
.drinkForm{
  margin-top:100px;
}
</style>