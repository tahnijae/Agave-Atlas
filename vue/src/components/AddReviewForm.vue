<template>
  <div class="input-review" >
        <form class="was-validated">
            <div class="form-group">
                <label for="ratingselect">Rating</label>
                <select class="custom-select mr-sm-2" id="ratingselect" name="ratingSelect" v-model="newReview.Rating" required>
                    <option value="" selected>Choose...</option>
                    <option value='1'> 1</option>
                    <option value='2'> 2 </option>
                    <option value='3'> 3 </option>
                    <option value='4'> 4 </option>
                    <option value='5'> 5 </option>
                </select>
                <label for="reviewText">Your Review</label>
                <textarea class="form-control is-invalid" id="reviewText" placeholder="Write your thoughts here!" v-model="newReview.ReviewText" required></textarea>
                <button type="button" class="btn btn-success" v-bind:disabled="checkComplete" v-on:click="submitReview(); onClick()">Submit</button>
                <button type="button" class="btn btn-danger" v-on:click="onClick()">Cancel</button>
            </div>
        </form>
    </div>
</template>

<script>
import RestaurantService from '../services/RestaurantService.js'
export default {
    data(){
        return{
            newReview: {
            Review_ID: 0,
            Reviewable_ID: this.$route.params.id,
            Rating: 0,
            ReviewerUsername: this.$store.state.user.username,
            Reviewer_ID: 0,
            ReviewText: ''
        }
        }
    },
    methods: {
        onClick(){
            this.$emit('clicked')
        },
        submitReview(){
        RestaurantService.addReviewToRestaurant(this.$route.params.id, this.newReview).then( response => {
            if(response.data != null){
                this.onClick();
            } else {
                alert("Error adding Review!");
            }
        })
        .catch(error => {
            console.log(error);
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