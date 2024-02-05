using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDataLayer.Models.Food
{
    public class Ingredient : BaseEntity
    {
        public string? Name { get; set; }    
        public decimal? NutritionalVelue { get; set; }
        public decimal GramsOfProtein { get; set; }
        public decimal GramsOfCarboidrate { get; set; }
        public decimal GramasOfFat { get; set; }
    }
}
