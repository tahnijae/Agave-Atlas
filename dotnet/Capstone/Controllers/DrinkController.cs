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
            IList<Drink> drinks = drinkDao.GetDrinkById(id);

            if(drinks.Count == 0)
            {
                return NoContent();
            }
            return Ok(drinks);
        }
    }
}
