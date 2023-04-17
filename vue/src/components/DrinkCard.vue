<template>
  <div class = "card">
      <div class = "card-header">
      <h2>{{decodeHtml(drink.name)}}</h2>
      <button class="deleteBtn" v-on:click="deleteDrink">Delete</button>
      <button class="deleteBtn" v-on:click="pushToForm" >Update</button>
      </div>
      <div class = "card-body">
      <p>{{decodeHtml(drink.description)}}</p>
      </div>
      <div v-if="drink.isFrozen">
          <p>It's Frozen!</p>
      </div>
  </div>
</template>

<script>
import drinkService from '../services/DrinkService.js'

export default {
data(){
  return{
    drinkId : this.drink.drinkID,
    

  }
},
props: ["drink","drink.drinkID"],
 methods: {
  decodeHtml(html) {
      var txt = document.createElement("textarea");
      txt.innerHTML = html;
      return txt.value;
    },
    deleteDrink(){
      drinkService.deleteDrink(this.drinkId).then((response)=>{
        if(response.status === 204){
          location.reload();
        }
      });
    },
    pushToForm(){
      this.$router.push({ name: "update-drink", params: { id: this.$route.params.id, drinkId: this.drinkId } });
    }
    
    

}

}
</script>

<style>
.card {
  display: flex;
  flex-direction: column;
  background-color: #fff;
  border: 1px solid #eaeaea;
  border-radius: 10px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  margin-bottom: 20px;
}

h2{
  text-align: center;
}

.card-header {
  background-color: #7bc950;
  border-bottom: 1px solid #eaeaea;
  padding: 10px;
}

.card-body {
  padding: 10px;
}
.deleteBtn{
  margin: 5px;
  padding: 5px 15px;
  background-color: white;
  color: black;
  border: none;
  border-radius: 20px;
  cursor: pointer;
}
</style>