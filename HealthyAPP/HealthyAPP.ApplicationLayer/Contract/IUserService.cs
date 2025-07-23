using HealthyAPP.ApplicationLayer.DTOs.User;

namespace HealthyAPP.ApplicationLayer.Contract
{
    public interface IUserService
    {
        Task<UserDTO> CreateUser(CreateUserDTO request);
        Task DeleteUser(int id);
        Task<List<UserDTO>> GetAllUsers();
        Task<UserDTO> GetUserById(int id);
        Task UpdateUser(UpdateUserDTO request);
    }
}