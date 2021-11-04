using System;
using System.Threading.Tasks;
using MapNotepad.Helpers.ProcessHelpers;
using MapNotepad.Model;
using MapNotepad.Services.Repository;

namespace MapNotepad.Services.EntityServices
{
    public class UserService
    {
        private IRepository _repository;

        public UserService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<int> InsertAsync(UserModel user)
        {
            return await _repository.InsertAsync(user);
        }

        public async Task<UserModel> FindByEmailAsync(string login)
        {
            return await _repository.FindWithQueryAsync<UserModel>("SELECT * FROM User WHERE Login = ?", login);
        }

    }
}