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
        
        public async Task<AOResult<UserModel>> SignInAsync(string email, string password)
        {
            var result = new AOResult<UserModel>();
            try
            {
                var user = await _userService.FindByEmailAsync(email);
                if (user == null || user.Password != password)
                {
                    result.SetFailure(user);
                }
                else
                {
                    _settingsManager.UserId = user.Id;
                    result.SetSuccess(user);
                }
            }
            catch (Exception e)
            {
                result.SetError($"Exception in: {nameof(SignInAsync)}", "Something went wrong", e);
            }

            return result;
        }

        public async Task<AOResult> SignUpAsync(string email, string password)
        {
            var result = new AOResult();
            try
            {
                bool success = false;
                var userInDB = await _userService.FindByEmailAsync(email);
                
                if (userInDB == null)
                {
                    UserModel user = new UserModel() {Email = email, Password = password};
                    int numRowsInserted = await _userService.InsertAsync(user);
                    if (numRowsInserted != 0)
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
            catch (Exception e)
            {
                result.SetError($"Exception in: {nameof(SignUpAsync)}", "Something went wrong", e);
            }

            return result;
        }
    }
}