using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
    }

    // Basic mockup data
    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Malabadi", Location = "Tampere", Cuisine = CuisineType.Turkish},
                new Restaurant { Id = 2, Name = "Pikkubistro Kattila", Location = "Tampere", Cuisine = CuisineType.French},
                new Restaurant { Id = 3, Name = "Maruseki", Location = "Tampere", Cuisine = CuisineType.Japanese}
            };
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name, true, null)
                   orderby r.Name
                   select r;
        }
    }
    
}
