using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IRestaurantDao
    {
        public Restaurant GetRestaurantByID(int ID);

        public List<Restaurant> GetAllRestaurants();
    }
}
