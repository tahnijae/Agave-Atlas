﻿using Azure;
using Capstone.DAO.Interfaces;
using Capstone.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using Capstone.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Capstone.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class YelpApiController : ControllerBase
    {
        private readonly IRestaurantSqlDao restaurantDao;
        private readonly YelpFusionApiService yelp;

       
        public YelpApiController(IRestaurantSqlDao restaurantDao, YelpFusionApiService yelp)
        {
            this.restaurantDao = restaurantDao;
            this.yelp = yelp;
        }

        [HttpGet]
        public ActionResult<Yelp> Get()
        {
            Yelp data = yelp.GetRestaurantInfo();
            return data;
        }

    }
}
