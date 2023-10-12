using System.Data;
using CrudDTOS.Data;
using CrudDTOS.DTOs;
using CrudDTOS.Libs;
using CrudDTOS.Model;
using CrudDTOS.Repository;

namespace CrudDTOS.Services
{
    public class UserServices : IUserServices
    {

        private readonly IRepositoryUser _repository;
        private readonly UserContext _context;

        public UserServices(IRepositoryUser repository, UserContext context)
        {
            _repository = repository;
            _context = context;
        }

        public void CreateUser(UserDetailsDto userDetailsDto)
        {

            var user = new UserModel(
                userDetailsDto.Name,
                userDetailsDto.Telefone,
                userDetailsDto.Email,
                userDetailsDto.Cpf,
                userDetailsDto.CreateRegistration = DateTime.UtcNow,
                userDetailsDto.UpdateRegistration = DateTime.UtcNow
            );

            ValidationUser.Validation(user);
            _repository.CreateUser(user);
        }

        public async void DeleteUser(int id, UserModel userModel)
        {
            var user = await _repository.GetOneUser(id);
            if (user == null) throw new ArgumentException("Usuario de nao encontrado.");

            _repository.DeleteUser(userModel);
        }

        public async Task<IEnumerable<UserModel>> GetAllUser()
        {
            return await _repository.GetAllUsers();
        }

        public async Task<UserModel> GetOneUser(int id)
        {
            var user = await _repository.GetOneUser(id);
            if (user == null) throw new ArgumentException("Usuario de nao encontrado.");

            return await _repository.GetOneUser(id);
        }

        public async Task<UserModel> SearchOneUser(string email)
        {
            var user = await _repository.SearchOneUser(email);
            if (user == null) throw new ArgumentException("Usuario de nao encontrado.");

            return await _repository.SearchOneUser(email);
        }

        public async void UpdateUser(int id, UserDto userDto)
        {
            var user = await _repository.GetOneUser(id);

            var userUpdate = new UserModel(
                userDto.Name,
                userDto.Email,
                userDto.Telefone
            );

            user.Name = userUpdate.Name;
            user.Email = userUpdate.Email;
            user.Telefone = userUpdate.Telefone;


            ValidationUser.Validation(userUpdate);

            _repository.UpdateUser(user);
        }
    }
}