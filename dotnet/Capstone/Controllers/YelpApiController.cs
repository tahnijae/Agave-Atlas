using Capstone.DAO.Interfaces;
using Capstone.Services;
using Microsoft.AspNetCore.Mvc;
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

        public YelpApiController(IRestaurantSqlDao restaurantDao)
        {
            this.restaurantDao = restaurantDao;
            //this.userDao = userDao;
            //this.drinkDao = drinkDao;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public string Get()
        {
            string data = yelp.GetRestaurantInfo().ToString();
            return data;
        }

    }
}
