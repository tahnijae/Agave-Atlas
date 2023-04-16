<template>
  <div>
    <navigation-bar />
    <div v-if="isLoading" class="loading">
       <div class="loading-text">Getting ready to join the fiesta... 🍹🎉</div>
      <img src="../assets/MargaritaLoader.gif"/>
    </div>
    <div class="twitter-div" v-else>
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
      isLoading:true
    }
  },
  mounted(){
    setTimeout(() => {
      this.isLoading = false
    }, 3000)
  }
};
</script>

<style scoped>
.loading {
  margin-top: 5rem;
  max-width: 800px;
  margin: 0 auto;
  text-align: center;
}
.loading-text {
  margin: 15rem;
  font-size: 1.5rem;
  margin-bottom: 1rem;
}

.loading img {
  width: 200px;
  height: 200px;
  object-fit: cover;
}

.twitter-div {
  position: relative;
  top: 80px; /* adjust this value based on the height of your navigation-bar */
  margin: 0 auto;
  max-width: 800px;
  background-color: #f2f2f2;
  border-radius: 8px;
  box-shadow: 0 0 8px rgba(0, 0, 0, 0.2);
  padding: 1rem;
}

.twitter-timeline {
  display: flex;
  justify-content: center;
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
.twitter-timeline {
  height: 400px;
  max-width: 500px;
}

.timeline-TweetList {
  font-size: 14px;
  line-height: 1.4em;
}

.timeline-Tweet-text {
  margin: 0;
}

</style>
