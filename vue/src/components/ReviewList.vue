<template>
  <div id="review-div">
      <div id="review-container">
            <review-card class="review-card" 
            v-for="review in reviews" 
            v-bind:key="review.id"
            v-bind:review="review"
            />
      </div>    
  </div>
</template>

<script>
import RestaurantService from '../services/RestaurantService.js'
import ReviewCard from './ReviewCard.vue'

export default {
components: {
    ReviewCard
},
data(){
    return{
        reviews:[]
    }
}
,
created(){
    RestaurantService.getReviewsByRestaurant(this.$route.params.id).then(response => {
        if(response.data != null){
            this.reviews = response.data
            
        }
        console.log(this.reviews);
    }).catch(error =>
    {
        if(error){
            console.log(error.status);
        }
    })
}
}
</script>

<style>

</style>