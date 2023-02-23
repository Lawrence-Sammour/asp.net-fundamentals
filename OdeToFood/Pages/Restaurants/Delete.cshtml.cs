using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;
using System.Reflection.Metadata.Ecma335;

namespace OdeToFood.Pages.Restaurants
{
    public class DelModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        public Restaurant restaurant { get; set; }

        public DelModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            restaurant = restaurantData.getById(restaurantId);
            if (restaurant == null)
            {
                return RedirectToPage("./Not_Found");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            var restaurant = restaurantData.Delete(restaurantId);

            if (restaurant == null)
            {
                return RedirectToPage("./Not_Found");
            }
            restaurantData.Commit();
            TempData["Message"] = $"{restaurant.Name} deleted";
            return RedirectToPage("./List");
        }
    }
}
