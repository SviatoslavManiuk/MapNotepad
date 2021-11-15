using System;
using System.Threading.Tasks;
using MapNotepad.Helpers.ProcessHelpers;
using MapNotepad.Model;
using MapNotepad.Services.EntityServices;
using MapNotepad.Services.SettingsManager;
using MapNotepad.Services.SettingsWrapper;

namespace MapNotepad.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private UserService _userService;
        private ISettingsWrapper _settingsWrapper;

        public AuthenticationService(UserService userService, ISettingsWrapper settingsWrapper)
        {
            _userService = userService;
            _settingsWrapper = settingsWrapper;
        }

        #region -- Public Helpers

        public async Task<AOResult<UserModel>> SignInAsync(string email, string password)
        {
            var result = new AOResult<UserModel>();
            bool success = false;

            try
            {
                var resultFromDB = await _userService.FindByEmailAsync(email);
                var user = resultFromDB.Result;

                if (resultFromDB.IsSuccess)
                {
                    if (user.Password == password)
                    {
                        success = true;
                        _settingsWrapper.SetAuthorizedUserId(user.Id);
                    }
                }

                if (success)
                {
                    result.SetSuccess(user);
                }
                else
                {
                    result.SetFailure(user);
                }
            }
            catch (Exception ex)
            {
                result.SetError($"{nameof(SignInAsync)} exception:", "Something went wrong", ex);
            }

            return result;
        }

        public async Task<AOResult> SignUpAsync(string name, string email, string password)
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
                        Name = name,
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