using FoodDataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDataLayer.Models.Food
{
    public class Resturant : BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<Product>? Menu { get; set; }
        public TimeSpan OpeingTime { get; set; }
        public TimeSpan CloseingTime { get; set; }

        public User? ResturantOwner { get; set; }

    }
}
