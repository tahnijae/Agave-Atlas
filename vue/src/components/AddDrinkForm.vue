<template>
  <div>
      <form v-on:submit.prevent="submitForm">
        <h3>Add a Drink!</h3>
        <label for="name">Drink Name:</label>
        <input id="name" type="text" v-model="drink.name"/>

        <label for="description">Description:</label>
        <input id="description" type="text" v-model="drink.description"/>

        <input type="checkbox">
        
      </form>
  </div>
</template>

<script>
import drinkService from '../services/DrinkService.vue'

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
    const newDrink = {
      name : this.name,
      description: this.description,
      isFrozen: this.isFrozen
    }
    drinkService.addDrink(newDrink).then((response)=>{
      if(response.status === 200){
      this.$router.push('/');
      }
    })
  }
}
}
</script>

<style>

</style>