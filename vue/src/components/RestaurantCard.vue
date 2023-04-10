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
    name: "RestaurantCard",
    props: {
        name: String,
        address: String
    
    },
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