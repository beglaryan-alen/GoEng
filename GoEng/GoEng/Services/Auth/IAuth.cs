using GoEng.Enums.User;
using GoEng.Models.Firebase;
using System;
using System.Threading.Tasks;

namespace GoEng.Services.Auth
{
    public interface IAuth
    {
        Task<FirebaseResponse> LoginAsync(string email, string password);
        Task<FirebaseResponse> GetUserAsync();
        Task<FirebaseResponse> IsUserEmailVerified();
        Task<FirebaseResponse> RechekEmailVerification();
        Task<FirebaseResponse> CreateUserAsync(string name, string email,
            DateTime dateOfBirth, EGender gender,
            string password, string photoUrl = "");
    }
}
