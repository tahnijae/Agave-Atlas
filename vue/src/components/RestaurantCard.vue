<template>
  <div class="card container" v-on:click="seeDrinks(restaurant.id)">
    <img width="100%" :src=restaurant.imageUrl>
    <!-- <img width="100%" :src="require(`@/assets/${restaurant.name.replace(/\s+/g, '')}${restaurant.zipCode}.jpg`)"> -->
    <div class="centered">
      <h2>{{ restaurant.name }}</h2>
    
      <p>{{restaurant.address}},</p>
      <p>{{restaurant.city}}, {{restaurant.state}} {{restaurant.zipCode}}</p>
    </div>
  </div>
</template>

<script>
import zipcodeService from '../services/ZipCodeService.js';
//import yelpService from "../services/YelpService.js";

export default {
    name: "restaurant-card",
    props: ["restaurant"],
    data(){
      return{
        locationData: [],
        // yelpInput:{
        //   name: this.restaurant.name,
        //   zipcode: this.restaurant.zipCode
        // },
        // yelpInfo:{
        //   id: ""
        // }
      }
    },
    methods:{
    seeDrinks(id){
      
      this.$router.push(`/restaurant/${id}/drinks`);
    },
  },
  computed:{
    cardClass(){
      const name = this.restaurant.name.toLowerCase().replace(/[^a-z0-9]+/g, `_`);
      return `card-${name}_bg`;
    },
    imageUrl() {
      return `../assets/${this.restaurant.imageFilePath}`;
    },
  },
  created() {
      zipcodeService.GetCityByZipcode(this.restaurant.zipCode).then((response) => {
        this.locationData = response.data.places[0];
        this.state = response.data.places.state;
        
      });
      // yelpService.GetBusinessByNameAndZip(this.yelpInput).then((response) => {
      // this.yelpInfo.id = response.data.id;
      // console.log(this.yelpInfo)
      // })
      // .catch(error => {
      //   console.log(error)})
      }
    
};
</script>

<style scoped>
.card {
  display: flex;
  flex-direction: column;
  background-color: #fff;
  border: 1px solid #eaeaea;
  border-radius: 10px;
  box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
  margin-bottom: 20px;
  font-family: Verdana, Geneva, Tahoma, sans-serif;
  width: 30%;
  height: 300px;
  background-size: cover;
  background-position: top;
}

h2 {
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
.container {
  position: relative;
  text-align: center;
  color: white;
}
.centered {
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  background: rgb(0, 0, 0); 
  background: rgba(0, 0, 0, 0.7);
  padding: 20px;
}
img{
  height: fit-content;
}
.card img{
  height: 100%;
  width:100%;
  object-fit: cover;
}
</style>