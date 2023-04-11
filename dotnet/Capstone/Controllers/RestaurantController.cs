using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Capstone.Models;
using Capstone.Security;
using Capstone.DAO.Interfaces;
using System.Collections.Generic;
using Capstone.DAO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantSqlDao restaurantDao;
        private readonly IUserDao userDao;

        public RestaurantController(IRestaurantSqlDao restaurantDao, IUserDao userDao)
        {
            this.restaurantDao = restaurantDao;
            this.userDao = userDao;
        }

        [HttpGet]
        
        public ActionResult<IList<Restaurant>> GetAllRestaurants()
        {
            IList<Restaurant> restaurants = restaurantDao.GetAllRestaurants();

            if (restaurants.Count == 0)
            {
                return NoContent();
            }
            return Ok(restaurants);
        }
    }
}
