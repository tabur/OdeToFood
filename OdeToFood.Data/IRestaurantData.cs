using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static OdeToFood.Core.Restaurant;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    // Basic mockup data
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Malabadi", Location = "Tampere", Cuisine = CuisineType.Turkish},
                new Restaurant { Id = 2, Name = "Pikkubistro Kattila", Location = "Tampere", Cuisine=CuisineType.French},
                new Restaurant { Id = 2, Name = "Maruseki", Location = "Tampere", Cuisine=CuisineType.Japanese}
            };
        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants 
                    orderby r.Name
                    select r;
        }
    }
    
}
