using System;
using System.Threading.Tasks;
using MapNotepad.Helpers.ProcessHelpers;
using MapNotepad.Model;
using MapNotepad.Services.Repository;

namespace MapNotepad.Services.EntityServices
{
    public class UserService
    {
        private IRepositoryService _repositoryService;

        public UserService(IRepositoryService repositoryService)
        {
            _repositoryService = repositoryService;
        }

        public async Task<AOResult<int>> InsertAsync(UserModel user)
        {
            var result = new AOResult<int>();
            
            try
            {
                int numRowsInserted = await _repositoryService.InsertAsync(user);
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
                var user = await _repositoryService.FindWithQueryAsync<UserModel>("SELECT * FROM User WHERE Email = ?", email);
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