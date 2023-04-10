using Capstone.DAO.Interfaces;
<<<<<<< HEAD

namespace Capstone.DAO
{
    public class RestaurantSqlDao /*: IRestaurantDao*/
    {

=======
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.Xml;

namespace Capstone.DAO
{
    public class RestaurantSqlDao : IRestaurantDao
    {

        private readonly string connectionString;

        public RestaurantSqlDao(string connString)
        { connectionString = connString; }



        public IList<Restaurant> GetAllRestaurants()
        {
            IList<Restaurant> allRestaurants = new List<Restaurant>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM restaurants", conn);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Restaurant restaurant = CreateRestaurantFromReader(reader);
                        allRestaurants.Add(restaurant);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error getting restaurants");
            }
            return allRestaurants;
        }
        public IList<Restaurant> GetRestaurantsByZipCode(string zipcode)
        {
            IList<Restaurant> restaurants = new List<Restaurant>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(
                        "SELECT * FROM restaurants " +
                        "WHERE zip_code = @zip_code", conn);
                    cmd.Parameters.AddWithValue("@zip_code", zipcode);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Restaurant restaurant = CreateRestaurantFromReader(reader);
                        restaurants.Add(restaurant);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error getting restaurants by zipcode");
            }
            return restaurants;

        }

        public Restaurant GetRestaurantByID(int ID)
        {
            Restaurant restaurant = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM transfer WHERE id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", ID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                       restaurant = CreateRestaurantFromReader(reader);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error getting restaurant by restaurant ID");
            }
            return restaurant;
        }


    public Restaurant CreateRestaurantFromReader(SqlDataReader sdr)
    {
        Restaurant restaurant = new Restaurant
        {
            Restaurant_ID = Convert.ToInt32(sdr["id"]),
            Name = Convert.ToString(sdr["name"]),
            ZipCode = Convert.ToString(sdr["zip_code"])
        };
        return restaurant;
    }

>>>>>>> 65e663621f30135af884833261caa66dc2452fbf
    }
}
