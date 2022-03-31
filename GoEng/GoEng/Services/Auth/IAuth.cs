using GoEng.Enums;
using GoEng.Models.FirebaseResponse;
using System;
using System.Threading.Tasks;

namespace GoEng.Services.Auth
{
    public interface IAuth
    {
        Task<string> GetUserUID();
        Task<FirebaseResponse> SignIn(string email, string password, bool shouldRemember);
        Task<FirebaseResponse> SignUp(string email, 
                          string password, string name, 
                          EGender gender, DateTime birtDate);
        Task<bool> SignInSilent();

        Task<bool> SignOut();
    }
}
