using GoEng.Enums.Firebase;
using GoEng.Enums.User;
using GoEng.Models.Firebase;
using GoEng.Models.Game;
using GoEng.Models.User;
using GoEng.Services.Auth;
using GoEng.Services.Cache;
using GoEng.Services.DefaultRepository;
using GoEng.Services.Game;
using GoEng.Services.Mapper;
using GoEng.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoEng.Services.AccountService
{
    public class AccountService : IAccountService
    {
        private readonly IAuth _auth;
        private readonly IGame _game;
        private readonly IMapperService _mapperService;
        private readonly ICacheService _cacheService;
        private readonly IDefaultRepository _defaultRepos;
        public AccountService(
            IAuth auth,
            IGame game,
            IMapperService mapperService,
            ICacheService cacheService, 
            IDefaultRepository defaultRepos)
        {
            _auth = auth;
            _game = game;
            _mapperService = mapperService;
            _cacheService = cacheService;
            _defaultRepos = defaultRepos;
        }

        public async Task<FirebaseResponse> CreateUserAsync(string name, 
            string email, DateTime dateOfBirth, 
            EGender gender, string password, string photoUrl = "")
        {
            var gamesBindable = _defaultRepos.GetStartGames();
            var games = await _mapperService.MapRangeAsync<GameModel>(gamesBindable);
            var authRes = await _auth.CreateUserAsync(name, email, dateOfBirth, gender, password, photoUrl);
            if (authRes.IsSuccessful)
            {
                var gameRes = await _game.UpdateGamesAsync(games);
                if (!gameRes.IsSuccessful)
                    return new FirebaseResponse 
                    { 
                        Status = EFirebaseStatus.ServerException 
                    };
                return new FirebaseResponse()
                {
                    Status = EFirebaseStatus.Ok,
                    IsSuccessful = true,
                };
            }
            return authRes;
        }

        public async Task<FirebaseResponse> GetUserAsync()
        {
            var res = await _auth.GetUserAsync();
            var user = res.Content as UserModel;
            var bindableModel = await _mapperService.MapAsync<UserBindableModel>(user);
            res.Content = bindableModel;
            return res;
        }

        public async Task<bool> LoginSilentAsync()
        {
            var email = _cacheService.Get(CacheSettings.Email);
            var pass = _cacheService.Get(CacheSettings.Password);
            if (email != null && 
                pass != null)
            {
                var res = await _auth.LoginAsync(email, pass);
                return res.IsSuccessful;
            }
            return false;
        }

        public async Task<bool> LoginAsync(string email, string password, bool remember)
        {
            var res = await _auth.LoginAsync(email, password);

            if (res.IsSuccessful 
                && remember)
            {
                _cacheService.Add(CacheSettings.Email, email, TimeSpan.FromDays(2));
                _cacheService.Add(CacheSettings.Password, password, TimeSpan.FromDays(2));
            }
            return res.IsSuccessful;
        }

        public async Task<FirebaseResponse> GetUserGames()
        {
            var res = await _game.GetUserGames();
            if (res.IsSuccessful)
            {
                var models = res.Content as List<GameModel>;
                var bindableModels = await _defaultRepos.GetGameBindableModels(models);
                return new FirebaseResponse
                {
                    Content = bindableModels,
                    Status = EFirebaseStatus.Ok,
                    IsSuccessful = true,
                };
            }
            else
            {
                return new FirebaseResponse
                {
                    Status = EFirebaseStatus.Exception,
                };
            }
        }

        public async Task<bool> RecheckEmailVerify()
        {
            var res = await _auth.RechekEmailVerification();
            return res.IsSuccessful;
        }

        public async Task<bool> IsUserEmailVerified()
        {
            var res = await _auth.IsUserEmailVerified();
            return res.IsSuccessful;
        }
    }
}
