<template>
  <div>
      <form>

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