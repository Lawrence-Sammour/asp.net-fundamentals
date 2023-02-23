using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public Restaurant restaurant { get; set; }
        public readonly IRestaurantData restaurantData;

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            restaurant = restaurantData.getById(restaurantId);

            if(restaurant == null)
            {
                return RedirectToPage("./Not_Found");
            }

            return Page();
        }
    }
}
