
using CrudDTOS.Data;
using CrudDTOS.Model;
using Microsoft.EntityFrameworkCore;

namespace CrudDTOS.Repository
{
    public class RepositoryUser : IRepositoryUser
    {

        private readonly UserContext _context;

        public RepositoryUser(UserContext context)
        {
            _context = context;
        }
        public void CreateUser(UserModel userModel)
        {
            _context.Add(userModel);
        }

        public void DeleteUser(UserModel userModel)
        {
            _context.Remove(userModel);
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<UserModel> GetOneUser(int id)
        {
            return await _context.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SavesChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<UserModel> SearchOneUser(string email)
        {
            return await _context.Users.Where(x => x.Email == email).FirstOrDefaultAsync();
        }

        public void UpdateUser(UserModel userModel)
        {
            _context.Update(userModel);
        }
    }
}