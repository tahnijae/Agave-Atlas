<template>
  <footer>
    <div class="container">
      <div class="row">
        <div class="col-md-4">
          <h4>Contact Us</h4>
          <p>Email: example@example.com</p>
          <p>Phone: 555-555-5555</p>
          <p>Address: 123 Main Street, Anytown USA</p>
        </div>
        <div class="col-md-4">
          <h4>Follow Us</h4>
          <ul class="social-icons">
            <li>
              <a href="https://twitter.com/AgaveAtlas">
                <font-awesome-icon :icon="['fab', 'twitter']" />
              </a>
            </li>
                    <li>
                        <a href="https://github.com/user1">
                            <font-awesome-icon class="fa-lg" :icon="['fab', 'github-alt']" style="color: purple" />
                        </a>
                    </li>
                    <li>
                        <a href="https://github.com/user2">
                            <font-awesome-icon class="fa-lg" :icon="['fab', 'github-alt']" style="color: green" />
                        </a>
                    </li>
                    <li>
                        <a href="https://github.com/user3">
                            <font-awesome-icon class="fa-lg" :icon="['fab', 'github-alt']" style="color: black" />
                        </a>
                    </li>
                    <li>
                        <a href="https://github.com/user4">
                            <font-awesome-icon class="fa-lg" :icon="['fab', 'github-alt']" style="color: red" />
                        </a>
                    </li>
                    <li>
                        <a href="https://github.com/user5">
                            <font-awesome-icon class="fa-lg" :icon="['fab', 'github-alt']" style="color: blue" />
                        </a>
                    </li>
                </ul>
        </div>
        <div class="col-md-4">
          <h4>Navigation</h4>
          <ul class="navigation">
            <li><a href="#">Home</a></li>
            <li><a href="#">About Us</a></li>
            <li><a href="#">Services</a></li>
            <li><a href="#">Contact Us</a></li>
          </ul>
        </div>
      </div>
      <div class="row">
        <div class="col-md-12">
          <hr>
          <p class="text-center">&copy; 2023 AgaveAtlas. All rights reserved.</p>
        </div>
      </div>
    </div>
  </footer>
</template>

<script>
import { FontAwesomeIcon } from "@fortawesome/vue-fontawesome";
import { library } from "@fortawesome/fontawesome-svg-core";
import { fab } from "@fortawesome/free-brands-svg-icons";

library.add(fab);

export default {
    components: {
        FontAwesomeIcon
    },
    methods: {
        scrollToTop() {
            window.scrollTo({ top: 0, behavior: "smooth" });
        }
    }
};
</script>

<style>
footer {
  background-color: #333;
  color: white;
  padding: 1em;
  position: fixed;
  bottom: 0;
  left: 0;
  right: 0;
}

.twitter-button {
  font-size: 2.5rem;
}

#footer {
  display: flex;
  flex-direction: column;
  align-items: center;
}

#footer_name img {
  max-height: 3em;
}

#footer_buttons {
  display: flex;
  justify-content: center;
  margin-top: 1em;
}

#footer_buttons button {
  background-color: transparent;
  border: none;
  color: white;
  cursor: pointer;
  font-size: 1rem;
  margin-left: 1em;
}

#footer_buttons button:hover {
  color: #ccc;
}
</style>
