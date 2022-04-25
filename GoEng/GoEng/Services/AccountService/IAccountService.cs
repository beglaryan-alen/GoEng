using GoEng.Enums.User;
using GoEng.Models.Firebase;
using System;
using System.Threading.Tasks;

namespace GoEng.Services.AccountService
{
    public interface IAccountService
    {
        Task<bool> LoginSilentAsync();
        Task<bool> IsUserEmailVerified();
        Task<bool> RecheckEmailVerify();
        Task<bool> LoginAsync(string email, string password, bool remember);
        Task<FirebaseResponse> GetUserAsync();
        Task<FirebaseResponse> CreateUserAsync(string name, string email,
            DateTime dateOfBirth, EGender gender,
            string password, string photoUrl = "");
        Task<FirebaseResponse> GetUserGames();
    }
}
