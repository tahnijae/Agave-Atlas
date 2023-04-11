<template>
  <div id="app">
    <div id="nav">
      <!-- <router-link v-if="!isAuthenticated" v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp; -->
      <router-link  v-bind:to="{ name: 'home' }">Home</router-link>&nbsp;|&nbsp;
      <router-link v-bind:to="{ name: 'login' }" v-show="!isAuthenticated">Login</router-link>&nbsp;|&nbsp;
      <router-link v-on:click="logout" v-bind:to="{ name: 'logout' }" v-show="isAuthenticated">Logout</router-link>&nbsp;   
    </div>
    <router-view />
  </div>
</template>

<script>
//import { computed } from 'vue';
export default {
  name: "App",
  data() {
    return {
       // Set to false by default
    };
  },
  created() {
    this.isAuthenticated = this.$store.state.token !== "";
  },
  methods: {
    logout() {
      this.$store.state.commit("LOGOUT");
      this.isAuthenticated = false;
    },
  computed: {
    isAuthenticated() {
      return !this.$store.state.token === '';
    }
  }
    }

  
};
</script>
