<template>
  <footer class="footer">
    <ul>
      <li class="twitter-icon">
        <a href="https://twitter.com/AgaveAtlas">
          <font-awesome-icon :icon="['fab', 'twitter']" />
          Twitter
        </a>
      </li>
      <li>
        <a href="https://github.com/bmullaly14">
          <font-awesome-icon class="fa-lg" :icon="['fab', 'github-alt']" style="color: purple" />
          Ben Mullaly
        </a>
      </li>
      <li>
        <a href="https://github.com/jfrancioso">
          <font-awesome-icon class="fa-lg" :icon="['fab', 'github-alt']" style="color: green" />
          Joseph Francioso
        </a>
      </li>
      <li>
        <a href="https://github.com/tahnijae">
          <font-awesome-icon class="fa-lg" :icon="['fab', 'github-alt']" style="color: black" />
          Tahni Hresko
        </a>
      </li>
      <li>
        <a href="https://github.com/user4">
          <font-awesome-icon class="fa-lg" :icon="['fab', 'github-alt']" style="color: red" />
          Wilson Warholic
        </a>
      </li>
      <li>
        <a href="https://github.com/DaleJMitchell">
          <font-awesome-icon class="fa-lg" :icon="['fab', 'github-alt']" style="color: blue" />
          Dale Mitchell
        </a>
      </li>
    </ul>
  </footer>
</template>

<script>
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { library } from "@fortawesome/fontawesome-svg-core";
import { fab } from "@fortawesome/free-brands-svg-icons";

library.add(fab);

export default {
  name: "FooterBar",
  components: {
    FontAwesomeIcon,
  },
};
</script>

<style scoped>
.footer {
  position: absolute;
  bottom: 0;
  left: 0;
  right: 0;
  background-color: #333;
  color: white;
  padding: 1em;
}

ul {
  list-style: none;
  display: flex;
  justify-content: center;
  align-items: center;
  margin: 0;
  padding: 0;
}

li {
  margin-right: 1em;
}

a {
  text-decoration: none;
  color: white;
}

a:hover {
  text-decoration: underline;
}

.twitter-icon {
  margin-right: 1em;
}
</style>
