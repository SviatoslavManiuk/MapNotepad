using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using MapNotepad.Helpers.ProcessHelpers;
using MapNotepad.Model;
using MapNotepad.Services.EntityServices;
using MapNotepad.Services.Settings;

namespace MapNotepad.Services.Authentication
{
    public class AuthenticationWithEmail : IAuthenticationService
    {
        private UserService _userService;
        private ISettingsManager _settingsManager;

        public AuthenticationWithEmail(UserService userService, ISettingsManager settingsManager)
        {
            _userService = userService;
            _settingsManager = settingsManager;
        }

        #region -- Public Helpers

        public async Task<AOResult<UserModel>> SignInAsync(string email, string password)
        {
            var result = new AOResult<UserModel>();
            try
            {
                var resultFromDB = await _userService.FindByEmailAsync(email);
                if (!resultFromDB.IsSuccess)
                {
                    result.SetFailure();
                }
                else
                {
                    var user = resultFromDB.Result;
                    _settingsManager.UserId = user.Id;
                    result.SetSuccess(user);
                }
            }
            catch (Exception ex)
            {
                result.SetError($"{nameof(SignInAsync)} exception:", "Something went wrong", ex);
            }

            return result;
        }
        
        public async Task<AOResult> SignUpAsync(string email, string password)
        {
            var result = new AOResult();
            
            try
            {
                bool success = false;
                var resultFound = await _userService.FindByEmailAsync(email);
                
                if (!resultFound.IsSuccess)
                {
                    var user = new UserModel()
                    {
                        Email = email,
                        Password = password
                    };
                    var resultInserted = await _userService.InsertAsync(user);
                    
                    if (resultInserted.IsSuccess)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    result.SetSuccess();
                }
                else
                {
                    result.SetFailure();
                }
            }
            catch (Exception ex)
            {
                result.SetError($"{nameof(SignUpAsync)} exception: ", "Something went wrong", ex);
            }

            return result;
        }
        
        #endregion
    }
}