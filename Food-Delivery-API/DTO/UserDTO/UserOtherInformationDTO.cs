using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDataLayer.DTO.UserDTO
{
    internal class UserOtherInformationDTO
    {
        public DateTime DateOfBirth { get; set; }
        public string? FiscalCode { get; set; }
        public string? TelephoneNumber { get; set; }
    }
}
