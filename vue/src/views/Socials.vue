<template>
<div>
    <a class="twitter-timeline" data-lang="en" data-theme="dark" href="https://twitter.com/AgaveAtlas?ref_src=twsrc%5Etfw">Tweets by AgaveAtlas</a> <script type="application/javascript" async src="https://platform.twitter.com/widgets.js" charset="utf-8"></script>
  </div>
</template>

<script>
export default {
  name: "SocialsPage",
};
</script>

<style scoped>
.twitter-feed {
  display: flex;
  justify-content: center;
  margin-top: 1rem;
  padding: 1rem;
  max-width: 100%;
  overflow: hidden;
  text-overflow: ellipsis;
  height: fit-content(5em);
}
</style>