using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Restaurant restaurant { get; set; }
        public readonly IRestaurantData restaurantData;
        public IEnumerable<SelectListItem> Cuisines { get; set; }
        public IHtmlHelper helper { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper helper)
        {
            this.restaurantData = restaurantData;
            this.helper = helper;
        }


        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = helper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                restaurant = restaurantData.getById(restaurantId.Value);
            }
            else
            {
                restaurant = new Restaurant();
            }
            if(restaurant == null)
            {
                return RedirectToPage("./Not_Found");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
     
            if (!ModelState.IsValid)
            {
                Cuisines = helper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if(restaurant.Id == 0)
            {
                restaurantData.Add(restaurant);
            }
            if(restaurant.Id > 0)
            {
                restaurantData.Update(restaurant); 
            }
            restaurantData.Commit();
            TempData["Message"] = "Restaurant Saved!";
            return RedirectToPage("./Detail", new { restaurantId = restaurant.Id });
        }
    }
}
