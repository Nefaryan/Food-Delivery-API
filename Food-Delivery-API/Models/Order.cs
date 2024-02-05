using FoodDataLayer.Enum;
using FoodDataLayer.Models.Food;
using FoodDataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDataLayer.Models
{
    public class Order : BaseEntity
    {
        public User? Rider {  get; set; }
        public User? User { get; set; }
        public string? ShippingAddres { get; set; } 
        public OrderStatusEnum? Status { get; set; }
        public ICollection<Product>? Products { get; set; }
        public decimal TotalPreparationTime => Products?.Sum(p => p.PreparationTime) ?? 0;
        public decimal TotalPrice {
            get
            {
                return Products?.Sum(p=> p.Price) ?? 0;
            }
                
        }
    }
}
