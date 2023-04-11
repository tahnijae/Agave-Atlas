<template>
  <div>
      <h1>{{drink.name}}</h1>
      <p>{{drink.description}}</p>
  </div>
</template>

<script>
export default {
props: ["drink"]
}
</script>

<style>

</style>