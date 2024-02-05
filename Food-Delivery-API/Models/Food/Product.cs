using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDataLayer.Models.Food
{
    public class Product : BaseEntity
    {
        public string? Name { get; set; }
        public ICollection<Ingredient>? Ingredeints { get; set; }
        public decimal PreparationTime { get; set; }
        public decimal? Price { get; set;}
        public bool? IsVegan { get; set; }

        public decimal TotalNutritionalValue {
            get { return Ingredeints?.Sum(i => i.NutritionalVelue) ?? 0; }
        }
    }
}
