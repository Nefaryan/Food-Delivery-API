using BCrypt.Net;
using Food_Delivery_API.Service.interfaces;
using FoodDataLayer.DTO.UserDTO;
using FoodDataLayer.Repository;
using FoodDataLayer.Util;

namespace Food_Delivery_API.Service.AuthService
{
    public class RegistrationService : IRegistrationSerivce
    {
        private readonly IGenericRepository<User>? _repository;
        private readonly ILogger<RegistrationService>? _logger;

        public RegistrationService(IGenericRepository<User>? repository, ILogger<RegistrationService>? logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async void RegisterAdmin(RegistrationDTO registrationDTO)
        {
            await RegisterUserOfType(registrationDTO, FoodDataLayer.Enum.UserTypeEnum.Admin, "Admin");
        }

        public async void RegisterResturantOwner(RegistrationDTO registrationDTO)
        {
            await RegisterUserOfType(registrationDTO, FoodDataLayer.Enum.UserTypeEnum.ResturantOwner, "Restaurant owner");
        }

        public async void RegisterRider(RegistrationDTO registrationDTO)
        {
            await RegisterUserOfType(registrationDTO, FoodDataLayer.Enum.UserTypeEnum.Raider, "Rider");
        }

        public async void RegisterUser(RegistrationDTO registrationDTO)
        {
            await RegisterUserOfType(registrationDTO, FoodDataLayer.Enum.UserTypeEnum.User, "User");
        }

        private async Task RegisterUserOfType(RegistrationDTO registrationDTO, FoodDataLayer.Enum.UserTypeEnum userType, string userTypeDisplayName)
        {
            try
            {
                _logger?.LogInformation($"Registration for {userTypeDisplayName}");

                if (registrationDTO == null)
                {
                    throw new ArgumentNullException("Registration Value is null");
                }

                string salt = BCrypt.Net.BCrypt.GenerateSalt();
                string passwordAshed = BCrypt.Net.BCrypt.HashPassword(registrationDTO.Password, salt);
                User user = new User()
                {
                    Id = Guid.NewGuid(),
                    UserType = userType,
                    PasswordHash = passwordAshed,
                    Salt = salt,
                    Email = registrationDTO.Email,
                    Name = registrationDTO.Name,
                    Surname = registrationDTO.Surname,
                };

                await _repository.Create(user);
                _logger?.LogInformation("Registration completed");
            }
            catch (Exception ex)
            {
                _logger?.LogError($"{ex.Message}");
                throw;
            }
        }

    }

}
