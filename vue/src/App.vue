<template>
  <div id="app">
    <div id="nav">
      <router-link v-bind:to="{ name: 'home' }"
        >Home</router-link
      >
      <!-- <router-link v-if="isAuthenticated" v-bind:to="{ name: 'home' }"
        > Home </router-link> -->
        &nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'login' }" v-if="this.$store.state.token == ''"
        >Login</router-link
      >&nbsp;|&nbsp;
      <router-link v-if="this.$store.state.token !== ''" v-bind:to="{ name: 'logout' }"
        >Logout</router-link
      >
      <router-link v-if="this.$store.state.token == ''" v-bind:to="{ name: 'register' }"
        > Register </router-link>
    </div>
    <router-view />
  </div>
</template>
<script>
export default {
  name: "App",
  computed(){
    this.isAuthenticated = this.$store.state.token !== "";
  },
  data() {
    return {
      isAuthenticated: false, // Set to false by default
    };
  },
  created() {
    this.isAuthenticated = this.$store.state.token !== "";
  },
};
</script>
<style scoped>
#nav {
  display:flex;
  flex-direction: row;
  justify-content: center;
}
</style>
