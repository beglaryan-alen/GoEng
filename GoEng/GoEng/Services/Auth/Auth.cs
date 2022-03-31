using Firebase.Auth;
using Firebase.Database;
using GoEng.Enums;
using GoEng.Models.FirebaseResponse;
using GoEng.Models.Registration;
using GoEng.Services.Cache;
using GoEng.Services.Mapper;
using GoEng.Settings;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace GoEng.Services.Auth
{
    public class Auth : IAuth
    {
        private readonly ICacheService _cache;
        private readonly IMapperService _mapper;
        public Auth(
            ICacheService cache,
            IMapperService mapper)
        {
            _cache = cache;
            _mapper = mapper;
        }

        public async Task<string> GetUserUID()
        {
            return _cache.Get(CacheSettings.UserUid);
        }

        public async Task<FirebaseResponse> SignIn(string email, string password, bool shouldRemember)
        {
            using (var authProvider = new FirebaseAuthProvider(new FirebaseConfig(FirebaseSettings.WebApiKey)))
            {
                try
                {
                    var res = await authProvider.SignInWithEmailAndPasswordAsync(email, password);

                    if (shouldRemember)
                    {
                        _cache.Add(CacheSettings.UserUid, res.User.LocalId, TimeSpan.FromSeconds(res.ExpiresIn));
                    }
                    
                    return new FirebaseResponse() { IsSuccess = true};
                }
                catch (FirebaseAuthException ex)
                {
                    return await _mapper.MapAsync<FirebaseResponse>(ex);
                }
            }
        }

        public async Task<bool> SignInSilent()
        {
            return !_cache.IsExpired(CacheSettings.UserUid);
        }

        public async Task<bool> SignOut()
        {
            try
            {
                _cache.Empty(CacheSettings.UserUid);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<FirebaseResponse> SignUp(string email, string password, 
            string name, EGender gender, DateTime birthDate)
        {
            using (var authProvider = new FirebaseAuthProvider(new FirebaseConfig(FirebaseSettings.WebApiKey)))
            {
                try
                {
                    var res = await authProvider.CreateUserWithEmailAndPasswordAsync(email, password);
                    await authProvider.SendEmailVerificationAsync(res);

                    RegistrationModel user = new RegistrationModel()
                    {
                        Id = Guid.NewGuid().ToString(),
                        UserUID = res.User.LocalId,
                        Email = email,
                        BirthDate = birthDate,
                        IsEmailVerified = false,
                        Gender = gender,
                        Name = name,
                        Password = password,
                    };
                    using (var client = new FirebaseClient(FirebaseSettings.BaseUrl))
                    {
                        var users = client
                            .Child("users")
                            .PostAsync(JsonConvert.SerializeObject(user));
                    }
                    return new FirebaseResponse() { IsSuccess = true };
                }
                catch (FirebaseAuthException ex)
                {
                    return await _mapper.MapAsync<FirebaseResponse>(ex);
                }
            }
        }
    }
}