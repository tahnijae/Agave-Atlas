<template>
  <div class = "card">
      <div class = "card-header">
      <h2>{{decodeHtml(drink.name.split(' ').map(word => word.charAt(0).toUpperCase() + word.slice(1)).join(' '))}}</h2>
      <button class="cardBtn" v-on:click="deleteDrink" v-if='this.$store.state.token !== ""' >Delete</button>
      <button class="cardBtn" v-on:click="pushToForm" v-if='this.$store.state.token !== ""' >Update</button>
      </div>
      <div class = "card-body">
      <p>{{decodeHtml(drink.description)}}</p>
      </div>
      <div class="frozen" v-if="drink.isFrozen">
          <p class="frozen-text">It's Frozen!</p>
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
  position: relative;
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
    font-family: Verdana, Geneva, Tahoma, sans-serif;
    height: 80px;
    display: flex;
    justify-content: center;
    align-items: center;

}

.card-body {
  padding: 10px;
}
.cardBtn{
  margin: 5px;
  padding: 5px 15px;
  background-color: white;
  color: black;
  border: none;
  border-radius: 20px;
  cursor: pointer;
}
.frozen{
  position: absolute;
  bottom: 0;
  
  left: 800px;
  transform: translateX(-50%);
  width: 50%;
  text-align: right;
  
  /* border: 1px solid #eaeaea; */
  /* border-radius: 10px; */
  /* box-shadow: 0 2px 4px rgba(0,0,0,0.1); */
  /* padding: 10px; */
  
}
.frozen-text{
  text-align: center;
  font-weight: bold;

}
</style>