using System.Threading.Tasks;
using MapNotepad.Helpers.ProcessHelpers;
using MapNotepad.Model;

namespace MapNotepad.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<AOResult<UserModel>> SignInAsync(string email, string password);

        Task<AOResult> SignUpAsync(string name, string email, string password);
    }
}