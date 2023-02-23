using Microsoft.AspNetCore.Mvc;
using OdeToFood.Data;

namespace OdeToFood.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        public readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        } 

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.GetCount();
            return View(count);
        }

    }
}
