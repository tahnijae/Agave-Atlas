using Capstone.Models;
using System.Collections.Generic;

namespace Capstone.DAO.Interfaces
{
    public interface IRestaurantDao
    {
        public IList<Restaurant> GetAllRestaurants();
        public IList<Restaurant> GetRestaurantsByZipCode(string zipcode);
        public Restaurant GetRestaurantByID(int ID);
    }
}
