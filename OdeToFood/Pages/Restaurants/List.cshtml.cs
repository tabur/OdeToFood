using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
      
        public IEnumerable<Restaurant> Restaurants { get; set; }

        // ASP model binding. By default only populates on POST
        [BindProperty(SupportsGet = true)]
        public String SearchTerm { get; set; }

        public ListModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public void OnGet(string searchTerm)
        {
            SearchTerm = searchTerm;
            Restaurants = restaurantData.GetRestaurantsByName(searchTerm);
        }
    }
}