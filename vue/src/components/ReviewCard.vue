<template>
  <div class="review-card">
    <div id="review-heading">
      <h1 class="head" id="username">{{setUsername()}}</h1>
      <div id="lime-stars" >
      <img id="lime" src="../assets/lime-slice2.png" v-for="num in revNumber" v-bind:key="num.key"/>
      </div>
      
    </div>
      <p id="review-text">{{review.reviewText}}</p>  
  </div>
</template>

<script>
export default {
  name: "review-card",
    props: ["review"],
    data(){
      return {
        revNumber: 0,
      }
    },
    methods: {
      setUsername(){
        if(this.review.reviewerUsername === ''){
          return "Anonymous"
        } else {
          return this.review.reviewerUsername;
        }
      }
    },
    created() {
      
      this.revNumber = parseInt(JSON.parse(this.review.rating));  
         
    }
}
</script>

<style scoped>
.review-card{
  width: 100%;
  height: fit-content;
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  align-content: center;
  justify-content: center;
  margin:10px auto;
  border: #7bc950 2px;
  border-style: solid;
  border-radius: 15px;
  background-color: #F3FAEF;
  font-family: Arial, Helvetica, sans-serif;
}
#review-heading{
  display: flex;
  flex-direction: column;
  flex-wrap: wrap;
  align-content: center;
  justify-content: center;
  text-align: center;
} 
.head{
  margin: 5px 10px;
}
#review-text{
  text-align: center;
  display: flex;
  flex-wrap: wrap;
  justify-content: center;
  align-content: center;
  margin: auto;
  padding: 10px;
}
#lime-stars{
  height: 3rem;
  display: flex;
  flex-direction: row;
  flex-wrap: wrap;
  align-content: center;
  justify-content: space-evenly;
}
#lime{
  height: 100%;
  margin: 0px 5px;
}
</style>