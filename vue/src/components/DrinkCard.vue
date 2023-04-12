<template>
  <div class = "card">
      <div class = "card-header">
      <h2>{{decodeHtml(drink.name)}}</h2>
      </div>
      <div class = "card-body">
      <p>{{decodeHtml(drink.description)}}</p>
      </div>
      <div v-if="drink.isFrozen">
          <p>It's Frozen!</p>
      </div>
  </div>
</template>

<script>
export default {
props: ["drink"]
, methods: {
  decodeHtml(html) {
      var txt = document.createElement("textarea");
      txt.innerHTML = html;
      return txt.value;
    },
}

}
</script>

<style>
.card {
  display: flex;
  flex-direction: column;
  background-color: #fff;
  border: 1px solid #eaeaea;
  border-radius: 10px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  margin-bottom: 20px;
}

h2{
  text-align: center;
}

.card-header {
  background-color: #7bc950;
  border-bottom: 1px solid #eaeaea;
  padding: 10px;
}

.card-body {
  padding: 10px;
}
</style>