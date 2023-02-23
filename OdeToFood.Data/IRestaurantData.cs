using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OdeToFood.Core;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantByName(string name);
        Restaurant getById(int id);
        Restaurant Update(Restaurant restaurant);
        Restaurant Add(Restaurant restaurant);
        Restaurant Delete(int id);
        int GetCount();
        int Commit();
    }
}