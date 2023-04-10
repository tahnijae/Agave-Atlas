<template>
  <div class="home">
    <h1>Home</h1>
     <restraunt-list/>
     <restaurant-card/>
  </div>
</template>

<script>
import RestaurantCard from '../components/RestaurantCard.vue';
import RestrauntList from '../components/RestaurantList.vue';


export default {
  name: "Home",
  components: {
    RestrauntList,
    RestaurantCard
    
  },
};
</script>


<style>
html{
  background-color: #dcf1d0;
}
body{
  background: white;
}
</style>