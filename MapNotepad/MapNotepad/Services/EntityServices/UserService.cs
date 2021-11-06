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

        public async Task<AOResult<int>> InsertAsync(UserModel user)
        {
            var result = new AOResult<int>();
            
            try
            {
                int numRowsInserted = await _repository.InsertAsync(user);
                if (numRowsInserted != 0)
                {
                    result.SetSuccess(numRowsInserted);
                }
                else
                {
                    result.SetFailure();
                }
            }
            catch (Exception ex)
            {
                result.SetError($"{nameof(InsertAsync)} exception: ", "Something went wrong", ex);
            }

            return result;
        }

        public async Task<AOResult<UserModel>> FindByEmailAsync(string email)
        {
            var result = new AOResult<UserModel>();
            
            try
            {
                var user = await _repository.FindWithQueryAsync<UserModel>("SELECT * FROM User WHERE Email = ?", email);
                if (user != null)
                {
                    result.SetSuccess(user);
                }
                else
                {
                    result.SetFailure();
                }
            }
            catch (Exception ex)
            {
                result.SetError($"{nameof(InsertAsync)} exception: ", "Something went wrong", ex);
            }

            return result;
        }

    }
}