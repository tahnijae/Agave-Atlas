<template>
  <div id="app">
    <div id="nav">
      <router-link v-if="!isAuthenticated" v-bind:to="{ name: 'home' }"
        >Home</router-link
      >
      <router-link v-if="isAuthenticated" v-bind:to="{ name: 'home' }"
        >Home</router-link
      >&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'login' }" v-if="!isAuthenticated"
        >Login</router-link
      >&nbsp;|&nbsp;
      <router-link v-if="!isAuthenticated" v-bind:to="{ name: 'register' }"
        >Register</router-link
      >
    </div>
    <router-view />
  </div>
</template>
<script>
export default {
  name: "App",
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

</style>
