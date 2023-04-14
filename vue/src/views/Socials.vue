<template>
<div>
  <navigation-bar />
  <div v-if="loading" class="loading">
      <font-awesome-icon :icon="['fas', 'cocktail']" spin />
    </div>
  <div class="twitter-div">
    <a class="twitter-timeline" data-lang="en" data-theme="dark" href="https://twitter.com/AgaveAtlas?ref_src=twsrc%5Etfw">Tweets by AgaveAtlas</a> <script type="application/javascript" async src="https://platform.twitter.com/widgets.js" charset="utf-8"></script>
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
</style>
