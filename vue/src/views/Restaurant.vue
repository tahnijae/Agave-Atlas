<template>
  <div>
    <navigation-bar/>
    <drink-form/>
    <drink-list/>
  </div>
</template>

<script>
import DrinkList from '../components/DrinkList.vue'
import NavigationBar from '../components/NavigationBar.vue'
import drinkForm from '../components/AddDrinkForm.vue'
export default {
  components: { 
    DrinkList, 
    NavigationBar,
    drinkForm
  },

}
</script>

<style>

</style>