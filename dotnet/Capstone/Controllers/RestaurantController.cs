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
        private readonly IDrinkDao drinkDao;

        public RestaurantController(IRestaurantSqlDao restaurantDao, IUserDao userDao, IDrinkDao drinkDao)
        {
            this.restaurantDao = restaurantDao;
            this.userDao = userDao;
            this.drinkDao = drinkDao;
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

        [HttpGet("{id}")]
        public ActionResult<Restaurant> GetRestaurantById(int id)
        {
            Restaurant restaurant = restaurantDao.GetRestaurantByID(id);
            if (restaurant == null)
            {
                return NoContent();
            }
            return Ok(restaurant);
        }

        [HttpGet("zipcode/{zip_code}")]
        public ActionResult<IList<Restaurant>> GetRestaurantByZipcode(string zip_code)
        {
            IList<Restaurant> restaurants = restaurantDao.GetRestaurantsByZipCode(zip_code);
            if (restaurants.Count == 0)
            {
                return NoContent();
            }
            return Ok(restaurants);
        }

        [HttpGet("{id}/drinks")]
        public ActionResult<IList<Drink>> GetDrinksForRestaurant(int id)
        {
            IList<Drink> drinks = drinkDao.GetRestaurantDrinks(id);

            if (drinks.Count == 0)
            {
                return NoContent();
            }
            return Ok(drinks);
        }

        [HttpPost("new")]
        public ActionResult<Restaurant> AddRestaurantToDB(NewRestaurantInput newRestaurantInput)
        {
            Restaurant restaurant = restaurantDao.AddRestaurant(newRestaurantInput);
            if (restaurant == null)
            {
                return NoContent();
            }
            return restaurant;
        }

    }
}