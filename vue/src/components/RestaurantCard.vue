<template>
  <div class="card">
      <div class="card-header">
          <h2> {{ restaurant.name}} </h2>
      </div>
      <div class = "card-body">
          <p>{{restaurant.address}}</p>
      </div>
  </div>
</template>

<script>
export default {
    name: "restaurant-card",
    props: {
        name: String,
        address: String
    
    },
    data(){
      return{
        restaurant:{
          name : 'test',
          address : 'test',
        },
        
      }

    },
    created(){
      
    }
};
</script>

<style scoped>
.card {
  background-color: #fff;
  border: 1px solid #eaeaea;
  border-radius: 5px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  margin-bottom: 20px;
}

.card-header {
  background-color: #f7f7f7;
  border-bottom: 1px solid #eaeaea;
  padding: 10px;
}

.card-body {
  padding: 10px;
}
</style>