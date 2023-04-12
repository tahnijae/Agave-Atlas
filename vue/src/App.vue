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
  position: fixed;
  top: 0;
  left: 0;
  right: 0;
  background-color: #fff;
  box-shadow: 0px 1px 5px rgba(0, 0, 0, 0.1);
  z-index: 9999;
  display: flex;
  justify-content: center;
  align-items: center;
  height: 50px;
  transition: all 0.3s ease-in-out; /* add transition for smooth effect */
}
#app{
  font-family:sans-serif;
}
</style>
