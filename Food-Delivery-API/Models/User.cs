using FoodDataLayer.Enum;
using FoodDataLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDataLayer.Util
{
    public class User : BaseEntity
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public DateTime DateofBirth { get; set; }
        public UserTypeEnum? UserType { get; set; }
        public string? FiscalCode { get; set; }
        public string? Email { get; set; }
        public string? Salt { get; set; }
        public string? PasswordHash { get; set; }
        public bool? isActive { get; set; }
        public string? TelephoneNumber { get; set; }
    }
}
