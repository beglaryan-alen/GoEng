using Firebase.Auth;
using Firebase.Database;
using GoEng.Enums;
using GoEng.Models.Home;
using GoEng.Models.Registration;
using GoEng.Services.Auth;
using GoEng.Services.Mapper;
using GoEng.Settings;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoEng.Services.Home
{
    public class HomeService : IHomeService
    {
        private readonly IMapperService _mapper;
        private readonly IAuth _auth;
        public HomeService(
            IMapperService mapper,
            IAuth auth)
        {
            _mapper = mapper;
            _auth = auth;
        }

        public async Task<IEnumerable<HomeBindableModel>> GetHomeModels()
        {
            using (var client = new FirebaseClient(FirebaseSettings.BaseUrl))
            {
                var userUID = await _auth.GetUserUID();
                var gamesJson = await client
                    .Child("games")
                    .OnceAsync<List<HomeModel>>();

                var model = gamesJson.FirstOrDefault(x => x.Object.FirstOrDefault(x => x.UserUID == userUID) != null);
                if (gamesJson == null ||
                    gamesJson.Count <= 0 &&
                    model != null)
                {
                    List<HomeModel> defaultModels = new List<HomeModel>()
                    {
                        new HomeModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserUID = userUID,
                            IsBlocked = true,
                            IsPassed = false,
                            IsTest = false,
                            Name = "Կենդանիներ",
                            Star = EStar.None,
                        },
                        new HomeModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserUID = userUID,
                            IsBlocked = true,
                            IsPassed = false,
                            IsTest = false,
                            Name = "Թռչուններ",
                            Star = EStar.None,
                        },
                        new HomeModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserUID = userUID,
                            IsBlocked = true,
                            IsPassed = false,
                            IsTest = false,
                            Name = "Գույներ",
                            Star = EStar.None,
                        },
                        new HomeModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserUID = userUID,
                            IsBlocked = true,
                            IsPassed = false,
                            IsTest = true,
                            Name = "Թեստ 1",
                            Star = EStar.None,
                        },
                        new HomeModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserUID = userUID,
                            IsBlocked = true,
                            IsPassed = false,
                            IsTest = false,
                            Name = "Շաբաթվա օրեր",
                            Star = EStar.None,
                        },
                        new HomeModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserUID = userUID,
                            IsBlocked = true,
                            IsPassed = false,
                            IsTest = false,
                            Name = "12 ամիսները",
                            Star = EStar.None,
                        },
                        new HomeModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserUID = userUID,
                            IsBlocked = true,
                            IsPassed = false,
                            IsTest = false,
                            Name = "Թվեր",
                            Star = EStar.None,
                        },
                        new HomeModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserUID = userUID,
                            IsBlocked = true,
                            IsPassed = false,
                            IsTest = true,
                            Name = "Թեստ 2",
                            Star = EStar.None,
                        },
                        new HomeModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserUID = userUID,
                            IsBlocked = true,
                            IsPassed = false,
                            IsTest = false,
                            Name = "Տարվա 4 եղանակները",
                            Star = EStar.None,
                        },
                        new HomeModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserUID = userUID,
                            IsBlocked = true,
                            IsPassed = false,
                            IsTest = false,
                            Name = "Oրվա եղանակը",
                            Star = EStar.None,
                        },
                        new HomeModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserUID = userUID,
                            IsBlocked = true,
                            IsPassed = false,
                            IsTest = false,
                            Name = "Պարզ ածականներ",
                            Star = EStar.None,
                        },
                        new HomeModel()
                        {
                            Id = Guid.NewGuid().ToString(),
                            UserUID = userUID,
                            IsBlocked = true,
                            IsPassed = false,
                            IsTest = true,
                            Name = "Թեստ 3",
                            Star = EStar.None,
                        },
                    };

                    await client
                        .Child("games")
                        .PostAsync(JsonConvert.SerializeObject(defaultModels));
                    return await _mapper.MapRangeAsync<HomeBindableModel>(defaultModels);
                }
                else
                {
                    var res = await _mapper.MapRangeAsync<HomeBindableModel>(model.Object);
                    return res;
                    //foreach (var item in gamesJson)
                    //{
                    //    if (item.Object != null ||
                    //        item.Object.Count > 0)
                    //    {
                    //        if (item.Object[0].UserUID == userUID)
                    //        {
                    //            var res = await _mapper.MapRangeAsync<HomeBindableModel>(item.Object);
                    //            return res;
                    //        }
                    //    }
                    //};
                }
            }
        }

        public Task<bool> UpdateGameStatus(HomeBindableModel model)
        {
            throw new NotImplementedException();
        }
    }
}
