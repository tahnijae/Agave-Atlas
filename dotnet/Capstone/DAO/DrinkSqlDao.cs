using Capstone.DAO.Interfaces;
using System.Collections.Generic;
using Capstone.Models;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Capstone.DAO
{
    public class DrinkSqlDao : IDrinkDao
    {
        private readonly string connectionString;

        public DrinkSqlDao(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<Drink> GetAllDrinks()
        {
            IList<Drink> allDrinks = new List<Drink>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM drinks", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Drink drink = CreateDrinkFromReader(reader);
                        allDrinks.Add(drink);
                    }
                }
            }
            catch(SqlException)
            {
                Console.WriteLine("Error getting drinks");
            }
            return allDrinks;
        }

        public IList<Drink> GetRestaurantDrinks(int restID)
        {
            IList<Drink> drinks = new List<Drink>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($@"SELECT drinks.id, drink_name, description, isFrozen FROM drinks 
                    JOIN restaurant_drinks ON drink_id = drinks.id
                    JOIN restaurants ON restaurant_id = restaurants.id
                    WHERE restaurants.id = @restID",conn);
                    cmd.Parameters.AddWithValue("@restID", restID);

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Drink newDrink = CreateDrinkFromReader(reader);
                        drinks.Add(newDrink);
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error getting drinks for restaurant");
            }
            return drinks;
        }

        public Drink GetDrinkById(int drinkID) {
            Drink drink = new Drink();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand($@"SELECT * FROM drinks
                    WHERE drinks.id = @id", conn);
                    cmd.Parameters.AddWithValue("@id", drinkID);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        drink = CreateDrinkFromReader(reader);
                    }
                    
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error getting drink by ID");
            }
            return drink;
        }

        private Drink CreateDrinkFromReader(SqlDataReader reader)
        {
            Drink newDrink = new Drink();

            newDrink.drink_ID = Convert.ToInt32(reader["id"]);
            newDrink.Name = Convert.ToString(reader["drink_name"]);
            newDrink.Description = Convert.ToString(reader["description"]);
            newDrink.isFrozen = Convert.ToBoolean(reader["isFrozen"]);

            return newDrink;

        }
    }
}
