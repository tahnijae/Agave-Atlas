using Capstone.DAO.Interfaces;
using Capstone.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography.Xml;

namespace Capstone.DAO
{
    public class RestaurantSqlDao : IRestaurantSqlDao
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

                    SqlCommand cmd = new SqlCommand("SELECT * FROM restaurants", conn);
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
                    SqlCommand cmd = new SqlCommand("SELECT * FROM restaurants WHERE restaurant_id = @id", conn);
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

        public Restaurant AddRestaurant(NewRestaurantInput inputRestaurant)
        {
            Restaurant restaurant = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO restaurants (name, zip_code) " + 
                        "OUTPUT INSERTED.restaurant_id " +
                        "VALUES (@name, @zip_code);", conn);
                    cmd.Parameters.AddWithValue("@name", inputRestaurant.Name);
                    cmd.Parameters.AddWithValue("@zip_code", inputRestaurant.ZipCode);

                    int restaurantID = Convert.ToInt32(cmd.ExecuteScalar());
                    restaurant = GetRestaurantByID(restaurantID);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error adding new restaurant to server");
            }
            return restaurant;
        }


        public Restaurant UpdateRestaurant(Restaurant inputRestaurant)
        {
            Restaurant restaurant = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("" +
                        "UPDATE restaurants " +
                        "SET name = @name, zip_code = @zip_code " +
                        "WHERE restaurant_id = @restaurant_id;"
                        ,conn);
                    cmd.Parameters.AddWithValue("@name", inputRestaurant.Name);
                    cmd.Parameters.AddWithValue("@zip_code", inputRestaurant.ZipCode);
                    cmd.Parameters.AddWithValue("@restaurant_id", inputRestaurant.ID);
                    //cmd.Parameters.AddWithValue("@image_file_path", inputRestaurant.ImageFilePath);

                    cmd.ExecuteNonQuery();
                    restaurant = GetRestaurantByID(inputRestaurant.ID);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error updating restaurant on the server");
            }
            return restaurant;
        }


        public void DeleteRestaurant(int restaurantID)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM restaurants WHERE restaurant_id = @restaurant_id;"
                        , conn);
                    cmd.Parameters.AddWithValue("@restaurant_id", restaurantID);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error updating restaurant on the server");
            }
        }

        public Restaurant CreateRestaurantFromReader(SqlDataReader sdr)
    {
        Restaurant restaurant = new Restaurant()
        {
            ID = Convert.ToInt32(sdr["restaurant_id"]),
            Name = Convert.ToString(sdr["name"]),
            ZipCode = Convert.ToString(sdr["zip_code"]),
            ImageFilePath = Convert.ToString(sdr["image_file_path"])
        };
        return restaurant;
    }

    }
}
