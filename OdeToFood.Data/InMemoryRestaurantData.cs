using OdeToFood.Core;

namespace OdeToFood.Data
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                
                new Restaurant(1, "Zuwadeh","BeitJala", CuisineType.Italian),
                new Restaurant(2, "Little Italy","Bethlehem", CuisineType.Indian),
                new Restaurant(3, "Bevero","BeitSahour", CuisineType.Mexican) };
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
           restaurants.Add(newRestaurant);
           newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
           return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }

        public Restaurant Delete(int id)
        {
           var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if(restaurant != null)
            {
                restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public Restaurant getById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var wantedRestaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if(wantedRestaurant != null)
            {
                wantedRestaurant.Location = updatedRestaurant.Location;
                wantedRestaurant.Name = updatedRestaurant.Name;
                wantedRestaurant.Cuisine = updatedRestaurant.Cuisine;
                
            }
            return wantedRestaurant;
        }

    }
}