<template>
  <div class="card">
      <div class="card-header">
          <h2> {{name}} </h2>
      </div>
      <div class = "card-body">
          <p>{{address}}</p>
      </div>
  </div>
</template>

<script>

export default {
    name: "restaurant-card",
<<<<<<< HEAD
    props: ['restaurants','name','address'],
    data(){
      return{
        restaurant:
          {
          name : 'test',
          address : 'test',
        },
        
        
=======
    props: ["restaurant"],
    data(){
      return{
>>>>>>> b81d695749e427b31e22252e07cd965808adce24
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
  border-radius: 10px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  margin-bottom: 20px;
}

.card-header {
  background-color: #7bc950;
  border-bottom: 1px solid #eaeaea;
  padding: 10px;
}

.card-body {
  padding: 10px;
}
</style>