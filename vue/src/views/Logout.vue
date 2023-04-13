<template>
  <div id= "logout">
    <navigation-bar />
    <h1>Logout</h1>
    <div v-if="isAuthenticated">
      <p>You have successfully logged out.</p>
      <router-link to="/login">Click here to log back in.</router-link>
    </div>
    <div v-else>
      <p>You are not currently logged in.</p>
      <router-link to="/login">Click here to log in.</router-link>
    </div>
  </div>
</template>

<script>
import NavigationBar from '../components/NavigationBar.vue';
export default {
  components: { NavigationBar },
  name: "Logout",
  data() {
    return {
      isAuthenticated: false,
    };
  },
  created() {
    this.isAuthenticated = this.$store.state.token !== "";
    this.$store.commit("LOGOUT");
  },
};
</script>
<style>
#logout {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: 100vh;
}
</style>
