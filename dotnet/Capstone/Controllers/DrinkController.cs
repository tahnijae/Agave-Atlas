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

    public class DrinkController : ControllerBase
    {
        private readonly IUserDao userDao;
        private readonly IDrinkDao drinkDao;

        public DrinkController(IDrinkDao drinkDao, IUserDao userDao)
        {
            this.drinkDao = drinkDao;
            this.userDao = userDao;
        }

        [HttpGet]
        public ActionResult<IList<Drink>> GetAllDrinks()
        {
            IList<Drink> drinks = drinkDao.GetAllDrinks();

            if (drinks.Count == 0)
            {
                return NoContent();
            }

            return Ok(drinks);
        }
        [HttpGet("{id}")]
        public ActionResult<Drink> GetDrinkByDrinkId(int id)
        {
            Drink drink = drinkDao.GetDrinkById(id);

            if(drink.Name == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }

        [HttpPost("drinks")]
         public ActionResult<Drink> AddNewDrink(Drink newDrink)
        {
            Drink drink = drinkDao.AddDrink(newDrink);
            if(drink == null)
            {
                return NotFound();
            }
            return drink;
        }

        [HttpPut("{drink_ID}")]
        public ActionResult<Drink> UpdateDrink(Drink newDrink)
        {
            if(GetDrinkByDrinkId(newDrink.drink_ID)== null)
            {
                return NotFound();
            }
            else
            {
                Drink drink = drinkDao.UpdateDrink(newDrink);
                if (drink == null)
                {
                    return NoContent();
                }
                return Ok(drink);
            }
            
        }

        [HttpDelete("{drinkID}")]
        public ActionResult DeleteRestaurantFromDB(int drinkID)
        {
            Drink deletedDrink = drinkDao.GetDrinkById(drinkID);
            if (deletedDrink == null)
            {
                return NotFound();
            }
            else
            {
                drinkDao.DeleteDrink(drinkID);
                deletedDrink = drinkDao.GetDrinkById(drinkID);
                if (deletedDrink == null)
                {
                    return NoContent();
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
