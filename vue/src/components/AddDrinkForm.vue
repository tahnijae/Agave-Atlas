<template>
  <div class = "drinkForm">
    <button class= "addDrink" v-if="!showAddDrinkForm && isLoggedIn" v-on:click="showAddDrinkForm = !showAddDrinkForm">Add Drink</button>
      <form v-on:submit.prevent="submitForm" v-if="showAddDrinkForm">
        <h3>Add a Drink!</h3>
        <label for="name">Drink Name:</label>
        <input id="name" type="text" v-model="drink.Name"/>

        <label for="description">Description:</label>
        <input id="description" type="text" v-model="drink.Description"/>

        <label for='isFrozen'>Frozen:</label>
        <input id="isFrozen" type="checkbox" v-model="drink.IsFrozen"/>
        
        <button type='submit'>Submit</button>
        <button  v-on:click="showAddDrinkForm = showAddDrinkForm">Cancel</button>
        
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
    },
    showAddDrinkForm : false,
    isLoggedIn : false,
  }
},
created() {
    this.isLoggedIn = this.$store.state.token !== "";
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

.addDrink {
  margin: 5px 47.5%;
  padding: 5px 15px;
  background-color: #7bc950;
  color: white;
  border: none;
  border-radius: 20px;
  cursor: pointer;
}
</style>