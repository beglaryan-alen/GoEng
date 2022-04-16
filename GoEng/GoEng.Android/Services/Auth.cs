using Firebase.Auth;
using Firebase.Firestore;
using GoEng.Droid.ServiceListeners;
using GoEng.Droid.Services;
using GoEng.Enums.Firebase;
using GoEng.Enums.User;
using GoEng.Models.Firebase;
using GoEng.Models.Game;
using GoEng.Models.User;
using GoEng.Services.Auth;
using GoEng.Services.Game;
using GoEng.Settings;
using Java.Util;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Auth))]
namespace GoEng.Droid.Services
{
    public class Auth : IAuth
    {
        private IGame _game => App.Resolve<IGame>();
        public Task<FirebaseResponse> GetUserAsync()
        {
            var tcs = new TaskCompletionSource<FirebaseResponse>();

            FirebaseFirestore.Instance
                .Collection("users")
                .Document(FirebaseAuth.Instance.CurrentUser.Uid)
                .Get()
                .AddOnCompleteListener(new OnGetUserCompleteListener(tcs));

            return tcs.Task;
        }

        public async Task<FirebaseResponse> LoginAsync(string email, 
            string password)
        {
            try
            {
                await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                return new FirebaseResponse(
                    EFirebaseExcType.Ok);
            }
            catch (System.Exception ex)
            {
                return new FirebaseResponse(
                    EFirebaseExcType.InvalidEmailOrPassword);
            }
        }

        public async Task<FirebaseResponse> CreateUserAsync(string name, string email,
            DateTime dateOfBirth, EGender gender,
            string password, string photoUrl = "")
        {
            try
            {
                await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                string Uid = FirebaseAuth.Instance.CurrentUser.Uid;
                UserModel user = new UserModel()
                {
                    Name = name,
                    DateOfBirth = dateOfBirth,
                    Email = email,
                    IsEmailVerified = false,
                    Gender = gender,
                    PhotoUrl = photoUrl,
                };
                
                HashMap userMap = new HashMap();
                userMap.Put("name", name);
                userMap.Put("email", email);
                userMap.Put("isEmailVerified", false);
                userMap.Put("dateOfBirth", dateOfBirth.ToString());
                userMap.Put("gender", (int)gender);
                FirebaseFirestore.Instance.Collection("users")
                    .Document(Uid)
                    .Set(userMap);

                return new FirebaseResponse(
                    EFirebaseExcType.Ok);
            }
            catch (FirebaseAuthEmailException ex)
            {
                return new FirebaseResponse(
                    EFirebaseExcType.InvalidEmail,
                    ex.Message);
            }
            catch (FirebaseAuthWeakPasswordException ex)
            {
                return new FirebaseResponse(
                    EFirebaseExcType.InvalidPassword,
                    ex.Message);
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                return new FirebaseResponse(
                    EFirebaseExcType.InvalidEmailOrPassword,
                    ex.Message);
            }
            catch(Exception ex)
            {
                return new FirebaseResponse(
                    EFirebaseExcType.Exception);
            }
        }

        //public async Task<FirebaseResponse> UpdateUserGameLevel(EGame gameToUpdate)
        //{
        //    try
        //    {
        //        var dictionary = new Dictionary<string, Java.Lang.Object>();
        //        dictionary.Add("gameLevel", (int)gameToUpdate);
        //        FirebaseFirestore.Instance.Collection("users")
        //        .Document(FirebaseAuth.Instance.CurrentUser.Uid)
        //        .Update(dictionary);

        //        return new FirebaseResponse(
        //            EFirebaseExcType.Ok);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new FirebaseResponse(
        //            EFirebaseExcType.Exception);
        //    }

        //}

        //public async Task<FirebaseResponse> UpdateUserGameLevelVariant(EGameVariant gameVariantToUpdate)
        //{
        //    try
        //    {
        //        var dictionary = new Dictionary<string, Java.Lang.Object>();
        //        dictionary.Add("gameLevelVariant", (int)gameVariantToUpdate);
        //        FirebaseFirestore.Instance.Collection("users")
        //        .Document(FirebaseAuth.Instance.CurrentUser.Uid)
        //        .Update(dictionary);

        //        return new FirebaseResponse(
        //            EFirebaseExcType.Ok);
        //    }
        //    catch (Exception ex)
        //    {
        //        return new FirebaseResponse(
        //            EFirebaseExcType.Exception);
        //    }
        //}

        //public async Task<EGame> GetGame()
        //{
        //    var res = await GetUserAsync();
        //    return res.GameLevel;
        //}

        //public async Task<EGameVariant> GetGameVariant()
        //{
        //    var res = await GetUserAsync();
        //    return res.GameLevelVariant;
        //}

        //public async Task<FirebaseResponse> UpdateUserPassedGame(GameModel game)
        //{
        //    try
        //    {
        //        var user = await GetUserAsync();
        //        if (!user.Games.Contains(game))
        //        {
        //            user.Games.Add(game);
        //        }
        //        else
        //        {
        //        }
        //        HashMap hash = new HashMap();
        //        foreach (var item in user.Games)
        //        {
        //            hash.Put("game", item.Game.ToString());
        //            hash.Put("star", item.Star.ToString());
        //        }

        //        FirebaseFirestore.Instance.Collection("users")
        //            .Document(FirebaseAuth.Instance.Uid)
        //            .Update("games", hash);
        //        return new FirebaseResponse(
        //                EFirebaseExcType.Ok);
        //    }
        //    catch (Exception)
        //    {
        //        return new FirebaseResponse(
        //            EFirebaseExcType.Exception);
        //    }

        //}

        //public async Task<IEnumerable<GameModel>> GetAllPassedGames()
        //{
        //    try
        //    {
        //        var user = await GetUserAsync();
        //        return user.Games;
        //    }
        //    catch (Exception)
        //    {
        //        return null;
        //    }
        //}
    }
}
