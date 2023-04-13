<template>
  <div>
      <form class="new-restuarant-form">
          <label for="name">Name:</label>
          <input id="name" type="text" class="input" v-model="restaurant.name" />
          <label for="city">City:</label>
          <input id="city" type="text" class="input" v-model="restaurant.city" />
          <label for="state">State:</label>
          <input id="state" type="text" class="input" v-model="restaurant.state"/>
          <label for="state">Zipcode:</label>
          <input id="state" type="text" class="input" v-model="restaurant.zipCode"/>
          <button v-on:click.prevent="submitForm()">Submit</button>
      </form>
  </div>
</template>

<script>
export default {
    name: "add-new-restaurant",
    data(){
        return{
            restaurant: []
        }
    }

}
</script>

<style>

</style>