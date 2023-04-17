using Azure;
using Capstone.DAO.Interfaces;
using Capstone.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class YelpApiController : ControllerBase
    {
        private readonly IRestaurantSqlDao restaurantDao;
        private readonly YelpFusionApiService yelp;

        //private readonly IUserDao userDao;
        //private readonly IDrinkDao drinkDao;

        public YelpApiController(IRestaurantSqlDao restaurantDao, YelpFusionApiService yelp)
        {
            this.restaurantDao = restaurantDao;
            this.yelp = yelp;
            //this.userDao = userDao;
            //this.drinkDao = drinkDao;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public string Get()
        {
            //dynamic data = JsonConvert.DeserializeObject(yelp.GetRestaurantInfo().Content);
            //return data.ToString();

            string data = yelp.GetRestaurantInfo().Content;
            return data;
        }

    }
}
