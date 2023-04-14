<template>
  <div>
    <navigation-bar />
    <div v-if="loading" class="loading">
      <font-awesome-icon :icon="['fas', 'cocktail']" spin />
    </div>
    <div class="twitter-div">
      <a class="twitter-timeline" data-lang="en" data-theme="dark" href="https://twitter.com/AgaveAtlas?ref_src=twsrc%5Etfw">Tweets by AgaveAtlas</a> <script type="application/javascript" async src="https://platform.twitter.com/widgets.js" charset="utf-8"></script>
      <div class="share-container">
        <div class="share-text">
          <h2>Tell us what you think!</h2>
          <p>Share your thoughts on our website with us:</p>
        </div>
        <a href="https://twitter.com/share?ref_src=twsrc%5Etfw" class="twitter-share-button" data-size="large" data-text="Hey @AgaveAtlas, just visited your site and loved the [insert feature]. Thanks for making my margarita experience even better! 🍹 #MargaritaLove" data-hashtags="MargaritaDayIsEveryday" data-show-count="false">Tweet to @AgaveAtlas</a>
      </div>
    </div>
  </div>
</template>

<script>
import NavigationBar from '../components/NavigationBar.vue';
export default {
  components: { NavigationBar },
  name: "SocialsPage",
  data(){
    return{
      loading:true
    }
  },
  mounted(){
    
  }
};
</script>

<style scoped>
.twitter-div {
  margin-top: 5rem;
}
.twitter-timeline {
  display: flex;
  justify-content: center;
  overflow: hidden;
  text-overflow: ellipsis;
}
.share-container {
  display: flex;
  flex-direction: column;
  align-items: center;
  background-color: #f2f2f2;
  padding: 1rem;
  border-radius: 8px;
  box-shadow: 0 0 8px rgba(0, 0, 0, 0.2);
}
.share-text {
  text-align: center;
  margin-bottom: 1rem;
}
.twitter-share-button {
  font-size: 1rem;
  padding: 0.5rem 1rem;
  border: none;
  border-radius: 4px;
  background-color: #1da1f2;
  color: white;
  transition: background-color 0.2s ease-in-out;
  text-decoration: none;
  text-align: center;
  margin-bottom: 1rem;
}
.twitter-share-button:hover {
  background-color: #0c8de4;
}
</style>
