using FoodDataLayer.DTO.UserDTO;
using FoodDataLayer.Models;
using FoodDataLayer.Util;

namespace Food_Delivery_API.Service.interfaces
{
    public interface ILoginServicecs
    {
        public User LogIn(LogInDTO logInDTO);
    }
}
