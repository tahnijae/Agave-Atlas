<template>
  <div class="card" v-on:click="seeDrinks(restaurant.restaurant_ID)">
      <div class="card-header">
          <h2> {{restaurant.name}} </h2>
      </div>
      <div class = "card-body">
          <p>{{restaurant.zipCode}}</p>
      </div>
  </div>
</template>

<script>

export default {
    name: "restaurant-card",
    props: ["restaurant"],
    data(){
      return{

      }

    },methods:{
    seeDrinks(id){
      
      this.$router.push(`/restaurant/${id}/drinks`);
    }
  },
    created(){
      
    }
};
</script>

<style scoped>
.card {
  display: flex;
  flex-direction: column;
  background-color: #fff;
  border: 1px solid #eaeaea;
  border-radius: 10px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  margin-bottom: 20px;
  border-radius: 15px;
}

h2{
  text-align: center;
}

.card-header {
  background-color: #7bc950;
  border-bottom: 1px solid #eaeaea;
  padding: 10px;
  border-radius: 15px;
}

.card-body {
  padding: 10px;
}
</style>