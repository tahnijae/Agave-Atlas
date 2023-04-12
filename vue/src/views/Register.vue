<template>
  <div id="register">
  <div class="corner top-left"><img src="../assets/lime-slice2.png" alt=""></div>
  <div class="corner top-right"><img src="../assets/lime-slice2.png" alt=""></div>
    <div class="corner bottom-right"><img src="../assets/lime-slice2.png" alt=""></div>
      <div class="corner bottom-left"><img src="../assets/lime-slice2.png" alt=""></div>


  <div class="text-center">
      <h1 class="title">Welcome New User!</h1>
  </div>
    <form @submit.prevent="register">
      <h1>Please Create A New Account</h1>
      <div role="alert" v-if="registrationErrors">
        {{ registrationErrorMsg }}
      </div>
      <div class="form-input-group">
        <label for="username">Username</label>
        <input
          type="text"
          id="username"
          v-model="user.username"
          required
          autofocus
        />
      </div>
      <div class="form-input-group">
        <label for="password">Password</label>
        <input type="password" id="password" v-model="user.password" required />
      </div>
      <div class="form-input-group">
        <label for="confirmPassword">Confirm Password</label>
        <input
          type="password"
          id="confirmPassword"
          v-model="user.confirmPassword"
          required
        />
      </div>
      <button type="submit">Create Account</button>
      <p>
        <router-link :to="{ name: 'login' }"
          >Already have an account? Log in.</router-link
        >
      </p>
    </form>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "register",
  data() {
    return {
      user: {
        username: "",
        password: "",
        confirmPassword: "",
        role: "user",
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: "/login",
                query: { registration: "success" },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
    },
  },
};
</script>

<style scoped>
.form-input-group {
  margin-bottom: 1rem;
}
label {
  margin-right: 0.5rem;
}
#register {
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  height: 100vh;
  
  background:repeating-radial-gradient(circle at center, transparent, transparent 50%, #7bc950 50%, #7bc950 70%, transparent 70%);
}
.title{
  font-size: 2rem;
  font-weight: bold;
  font-family: 'Helvetica Neue', sans-serif;
  text-transform: uppercase;
  letter-spacing: 0.1rem;
  
}
.corner {
  position: absolute;
}
.top-left {
  top: 0;
  left: 0;
}
.top-right {
  top: 0;
  right: 0;
  
}
.bottom-left {
  bottom: 0;
  left: 0;
}
.bottom-right {
  bottom: 0;
  right: 0;
  
}
</style>
