
using CrudDTOS.DTOs;
using CrudDTOS.Model;

namespace CrudDTOS.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<UserModel>> GetAllUser();
        Task<UserModel> GetOneUser(int id);
        Task<UserModel> SearchOneUser(string email);
        void CreateUser(UserDetailsDto userDetailsDto);
        void UpdateUser(int id, UserDto userDto);
        void DeleteUser(int id, UserModel userModel);


    }
}