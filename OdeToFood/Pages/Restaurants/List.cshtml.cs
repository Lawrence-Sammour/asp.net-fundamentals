using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        public string Message { get; set; }
        public readonly IConfiguration config;
        private readonly IRestaurantData restaurantData;

        [BindProperty (SupportsGet = true)]
        public string searchTerm { get; set; }
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string Configuration { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            Message = "Hello World";
            Configuration = config["Message"];
            Restaurants = restaurantData.GetRestaurantByName(searchTerm);
        }
    }
}
