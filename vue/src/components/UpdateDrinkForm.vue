<template>
  <div>
      <form v-on:submit.prevent="submitForm">
        <h3>Update this Drink!</h3>
        <label for="name">Drink Name:</label>
        <input id="name" type="text" v-model="newDrink.name" value= :drink.name>

        <label for="description">Description:</label>
        <input id="description" type="text" v-model="newDrink.description"/>

        <label for='isFrozen'>Frozen:</label>
        <input id="isFrozen" type="checkbox" v-model="newDrink.isFrozen"/>
        
        <button type='submit'>Submit</button>
        
      </form>
  </div>
</template>

<script>
import drinkService from '../services/DrinkService.js'
 
export default {
name: "update-drink-form",
props:["drink"],
data(){
    return{
        newDrink : {
            name:'',
            description:'',
            isFrozen:'',
            restaurantID: Number(this.$route.params.id)  
        },
    drinkId : Number(this.$route.params.drinkId),
}
},
methods:{
    submitForm(){
    drinkService.updateDrink(this.drinkId, this.newDrink).then((response)=>{
      if(response.status === 200){
        this.$router.push(`/restaurant/${this.$route.params.id}/drinks`)
      }
    });
    }
    }

}

</script>

<style>

</style>