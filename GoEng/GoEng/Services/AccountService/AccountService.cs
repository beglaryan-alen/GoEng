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
            EGender gender, string password, 
            string photoUrl = "")
        {
            var gamesBindable = _defaultRepos.GetStartGames();
            var games = await _mapperService.MapRangeAsync<GameModel>(gamesBindable);
            var authRes = await _auth.CreateUserAsync(name, email, dateOfBirth, gender, password, photoUrl);
            if (authRes.IsSuccessful)
            {
                var gameRes = await _game.UpdateGamesAsync(games);
                if (!gameRes.IsSuccessful)
                    return new FirebaseResponse(EFirebaseExcType.ServerException);
                return new FirebaseResponse(EFirebaseExcType.Ok);
            }
            return authRes;
        }

        public async Task<UserBindableModel> GetUserAsync()
        {
            var res = await _auth.GetUserAsync();
            if (res.IsSuccessful)
            {
                var user = await _mapperService.MapAsync<UserBindableModel>(res.Content as UserModel);
                return user;
            }
            else
            {
                throw new Exception("Something went wrong.");
            }
        }

        public async Task<FirebaseResponse> LoginSilentAsync()
        {
            var email = _cacheService.Get(CacheSettings.Email);
            var pass = _cacheService.Get(CacheSettings.Password);
            if (email != null && 
                pass != null)
            {
                var res = await _auth.LoginAsync(email, pass);
                return res;
            }
            return new FirebaseResponse(
                EFirebaseExcType.Exception);
        }

        public async Task<FirebaseResponse> LoginAsync(string email, string password, bool remember)
        {
            var res = await _auth.LoginAsync(email, password);

            if (res.IsSuccessful 
                && remember)
            {
                _cacheService.Add(CacheSettings.Email, email, TimeSpan.FromDays(2));
                _cacheService.Add(CacheSettings.Password, password, TimeSpan.FromDays(2));
            }
            return res;
        }

        public async Task<List<GameBindableModel>> GetUserGames()
        {
            var res = await _game.GetUserGames();
            if (res.IsSuccessful)
            {
                var models = res.Content as List<GameModel>;
                var bindableModels = await _mapperService.MapRangeAsync<GameBindableModel>(models);
                return bindableModels.ToList();
            }
            else
            {
                throw new Exception("Something went wrong.");
            }
        }
    }
}
