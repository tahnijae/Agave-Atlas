<template>
  <div id="review-div">
      <div class="not-input-review" v-show="!reviewForm">
        <div id="no-reviews" v-if="reviews.length === 0">
          <h3>Nobody has reviewed {{restaurant.name}} yet!</h3>
          <h4> Click here to be the first!</h4>
        </div>
      <input class="button" type="button" v-on:click="reviewForm = true;" value="Click Me!"/>
      <div id="review-container">
            <review-card class="review-card" 
            v-for="review in reviews" 
            v-bind:key="review.id"
            v-bind:review="review"
            />
      </div>
    </div>    
    <div class="input-review" v-show="reviewForm">
        <form class="was-validated">
            <div class="form-group">
                <label for="ratingselect">Rating</label>
                <select class="custom-select mr-sm-2" id="ratingselect" name="ratingSelect" v-model="Rating" required>
                    <option value="" selected>Choose...</option>
                    <option value='1'> 1</option>
                    <option value='2'> 2 </option>
                    <option value='3'> 3 </option>
                    <option value='4'> 4 </option>
                    <option value='5'> 5 </option>
                </select>
                <label for="reviewText">Your Review</label>
                <textarea class="form-control is-invalid" id="reviewText" placeholder="Write your thoughts here!" v-model="newReview.ReviewText" required></textarea>
                <button type="button" class="btn btn-success" v-bind:disabled="checkComplete" v-on:click="submitReview()">Submit</button>
            </div>
        </form>
    </div>
  </div>
</template>

<script>
import RestaurantService from '../services/RestaurantService.js'
import ReviewCard from './ReviewCard.vue'

export default {
    name: "review-list",
    props: ["restaurant"],
components: {
    ReviewCard
},
data(){
    return{
        reviews:[],
        reviewForm: false,
        Rating: 0,
        newReview: {
            Review_ID: 0,
            Reviewable_ID: parseInt(this.$route.params.id),
            Rating: parseInt(this.Rating),
            ReviewerUsername: this.$store.state.user.username,
            Reviewer_ID: 0,
            ReviewText: ''
        }
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
},
methods:{
    submitReview(){
        RestaurantService.addReviewToRestaurant(this.$route.params.id, this.newReview).then( response => {
            if(response.data != null){
                this.created();
            } else {
                alert("Error adding Review!");
            }
        })
        .catch(error => {
            console.log(error.status);
        })
    }
},
computed: {
    checkComplete() {
        if(this.newReview.Rating != 0 && this.newReview.ReviewText.length != 0){
            return false;
        } else {
            return true;
        }
    }
}
}
</script>

<style>

</style>