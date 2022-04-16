using GoEng.Enums.User;
using GoEng.Models.Firebase;
using GoEng.Models.Game;
using GoEng.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoEng.Services.AccountService
{
    public interface IAccountService
    {
        Task<FirebaseResponse> LoginSilentAsync();
        Task<FirebaseResponse> LoginAsync(string email, string password, bool remember);
        Task<UserBindableModel> GetUserAsync();
        Task<FirebaseResponse> CreateUserAsync(string name, string email,
            DateTime dateOfBirth, EGender gender,
            string password, string photoUrl = "");
        Task<List<GameBindableModel>> GetUserGames();
    }
}
