<template>
  <div id="app">
    <router-view />
  </div>
</template>
<script>
import { fas } from "@fortawesome/free-solid-svg-icons";
import { library } from "@fortawesome/fontawesome-svg-core";

library.add(fas);

export default {
  name: "App",
};
</script>
<style>

</style>
