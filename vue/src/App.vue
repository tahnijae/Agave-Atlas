<template>
  <div id="app">
    <div id="nav">
      <!-- added click functionality that scrolls to top of page, but it doesn't work please fix, there is also a method at the bottom "scrollToTop"-->
      <div id="nav_name">
        <h1>Agave Atlas</h1>
      </div>
      <div id="nav_buttons">
        <button v-bind:to="{ name: 'home' }" @click.prevent="scrollToTop">
          <font-awesome-icon :icon="['fas', 'martini-glass-citrus']" />
          Home
        </button>

        <!-- <router-link v-if="isAuthenticated" v-bind:to="{ name: 'home' }"
        > Home </router-link> -->
        &nbsp;|&nbsp;
        <button
          v-if="this.$store.state.token == ''"
          @click="$router.push('/login')"
        >
          Login
        </button>
        &nbsp;|&nbsp;
        <button
          v-if="this.$store.state.token !== ''"
          @click="$router.push('/logout')"
        >
          Logout
        </button>

        <!-- <router-link v-if="this.$store.state.token == ''" v-bind:to="{ name: 'register' }"
        > Register </router-link> -->
        <button
          v-if="this.$store.state.token == ''"
          @click="$router.push('/register')"
        >
          Register
        </button>
      </div>
    </div>
    <router-view />
  </div>
</template>
<script>
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { fas } from "@fortawesome/free-solid-svg-icons";
import { library } from "@fortawesome/fontawesome-svg-core";

library.add(fas);

export default {
  name: "App",
  components: {
    FontAwesomeIcon,
  },
  computed() {
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
  methods: {
    //this method is part of the scrollToTopfunctaionality at the top nav bar in template, it does not work, but maybe with some cool js and template powers, you can make it work
    scrollToTop() {
      if (this.$route.path === "/") {
        window.scrollTo({
          top: 0,
          behavior: "smooth",
        });
      } else {
        this.$router.push({ name: "home" });
      }
    },
  },
};
</script>
<style scoped>
#nav div{
  display: flex;
  padding: 0%;
}
#nav {
  display: flex;
  justify-content: space-between;
  position: fixed;
  align-items: center;
  top: 0;
  left: 0;
  right: 0;
  background-color: #F3FAEF;
  box-shadow: 0px 1px 5px rgba(0, 0, 0, 0.1);
  z-index: 9999;
  height: 50px;
  transition: all 0.3s ease-in-out;
}

#nav_name {
  flex-grow: 1;
  margin-left: 10px;
}
#nav_buttons {
  margin-right: 10px;
}
#nav_title h1{
  margin: 10px;
  color: #0C0C0C;
}
#nav div button {
  margin: 5px;
  padding: 5px 15px;
  background-color: #7bc950;
  color: white;
  border: none;
  border-radius: 20px;
  cursor: pointer;
}

#nav button:hover {
  background-color: #6db743;
}
</style>
