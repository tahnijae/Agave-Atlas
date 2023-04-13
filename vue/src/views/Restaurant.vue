<template>
  <div>
    <navigation-bar/>
    <drink-list/>
  </div>
</template>

<script>
import DrinkList from '../components/DrinkList.vue'
import NavigationBar from '../components/NavigationBar.vue'
export default {
  components: { DrinkList, 
                NavigationBar},

}
</script>

<style>

</style>