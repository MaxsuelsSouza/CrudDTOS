using CrudDTOS.Model;

namespace CrudDTOS.Repository
{
    public interface IRepositoryUser
    {
        Task<IEnumerable<UserModel>> GetAllUsers();
        Task<UserModel> GetOneUser(int id);
        Task<UserModel> SearchOneUser(string email);
        void CreateUser(UserModel userModel);
        void UpdateUser(UserModel userModel);
        void DeleteUser(UserModel userModel);
        Task<bool> SavesChangesAsync();
    }
}