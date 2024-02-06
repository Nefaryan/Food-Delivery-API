using FoodDataLayer.DTO.UserDTO;

namespace Food_Delivery_API.Service.interfaces
{
    public interface IRegistrationSerivce
    {
        public void RegisterUser(RegistrationDTO registrationDTO);
        public void RegisterRider(RegistrationDTO registrationDTO);
        public void RegisterResturantOwner(RegistrationDTO registrationDTO);
        public void RegisterAdmin(RegistrationDTO registrationDTO);
    }
}
