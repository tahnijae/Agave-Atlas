<template>
  <div class = "drinkForm">
    <button class= "addDrink" v-if="!showAddDrinkForm && isLoggedIn" v-on:click="showAddDrinkForm = !showAddDrinkForm">Add Drink</button>
      <form class="form" v-on:submit.prevent="submitForm" v-if="showAddDrinkForm">
        <h3>Add a Drink!</h3>
        
        <label for="name">Drink Name:</label>
        <input class="text-box" id="name" type="text" v-model="drink.Name"/>

        <label for="description">Description:</label>
        <input class="text-box" id="description" type="text" v-model="drink.Description"/>

        <div>
        <label for='isFrozen'>Frozen:</label>
        <input id="isFrozen" type="checkbox" v-model="drink.IsFrozen"/>
        </div>

        <div>
        <button class="bton" type='submit'>Submit</button>
        
        <button  class="bton" v-on:click="showAddDrinkForm = showAddDrinkForm">Cancel</button>
        </div>
    
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

<style scoped>
input{
  margin-left:10px;
}
label{
  margin-left:10px;
}
button{
  margin-left:10px;
}

.bton{
  width:150px;
  background-color: #7bc950;
  color: white;
  border: none;
  border-radius: 20px;
  cursor: pointer;
  margin-right:10px;
}
.text-box{
  width:250px;
}
.form{
  border-style:solid;
  border-color:#7bc950;
  height: 100%;
  display:flex;
  flex-direction: column;
  justify-content: space-evenly;
  height:250px;
}
h3{
  text-align:center;
}

.drinkForm{
  margin-top:100px;
  font-family:sans-serif;

}

.addDrink {
  margin: 5px 46.5%;
  padding: 5px 15px;
  background-color: #7bc950;
  color: white;
  border: none;
  border-radius: 20px;
  cursor: pointer;
}
</style>