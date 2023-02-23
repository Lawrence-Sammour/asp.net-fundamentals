using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Core
{
    public class Restaurant
    {

        public Restaurant() { }
        public Restaurant(int Id, string Name, string Location, CuisineType Cuisine)
        {
            this.Id = Id;
            this.Name = Name;
            this.Location = Location;
            this.Cuisine = Cuisine;
        }

        [Required, StringLength(80)]
        public string Name { get; set; }    
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
        public int Id { get; set; }
    }
}
