using GoEng.Enums.Game;
using GoEng.Enums.Language;
using GoEng.Enums.User;
using GoEng.Models.Game;
using GoEng.Models.GameVariant;
using GoEng.Services.Language;
using GoEng.Services.Mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoEng.Services.DefaultRepository
{
    public class DefaultRepository : IDefaultRepository
    {
        private readonly IMapperService _mapperService;
        private readonly ILanguage _language;
        private IEnumerable<GameBindableModel> StartGames { get; set; }
        private Dictionary<EGame, IEnumerable<GameVariantBindableModel>> GameVariants { get; set; }

        public DefaultRepository(
            IMapperService mapperService,
            ILanguage language)
        {
            _mapperService = mapperService;
            _language = language;
            FillValues();
        }

        public IEnumerable<GameBindableModel> GetStartGames()
        {
            return StartGames;
        }

        public async Task<IEnumerable<GameBindableModel>> GetGameBindableModels(IEnumerable<GameModel> models)
        {
            var bindableModels = (await _mapperService.MapRangeAsync<GameBindableModel>(models)).ToList();
            bindableModels.ForEach(x => x.Name = _language.GetGameName(ELanguage.Eng, x.Game));
            return bindableModels;
        }

        public IEnumerable<GameVariantBindableModel> GetGameVariants(EGameVariant gameVariant, EGame game)
        {
            var variants = GameVariants[game];
            var res = variants
                .TakeWhile(x => x.GameVariant != gameVariant)
                .ToList();
            res.Add(variants.FirstOrDefault(x => x.Game == game 
                                            && x.GameVariant == gameVariant));
            return res;
        }

        private void FillValues()
        {
            StartGames = new List<GameBindableModel>()
            {
                new GameBindableModel()
                {
                    Name = "Կենդանիներ",
                    Game = EGame.Animals,
                    Star = EStar.None,
                    IsCurrent = true,
                    GameVariant = EGameVariant.Panda,
                },
                new GameBindableModel()
                {
                    Name = "Թռչուններ",
                    Game = EGame.Birds,
                    Star = EStar.None,
                    GameVariant = EGameVariant.None,
                    IsBlocked = true,
                },
                new GameBindableModel()
                {
                    Name = "Գույներ",
                    Game = EGame.Colors,
                    Star = EStar.None,
                    GameVariant = EGameVariant.None,
                    IsBlocked = true,
                },
                new GameBindableModel()
                {
                    Name = "Թեստ 1",
                    Game = EGame.Test1,
                    IsTest = true,
                    Star = EStar.None,
                    IsBlocked = true,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Շաբաթվա օրեր",
                    Game = EGame.WeekDays,
                    Star = EStar.None,
                    IsBlocked = true,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "12 ամիսները",
                    Game = EGame.YearMonths,
                    Star = EStar.None,
                    IsBlocked = true,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Թվեր",
                    Game = EGame.Numbers,
                    Star = EStar.None,
                    IsBlocked = true,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Թեստ 2",
                    Game = EGame.Test2,
                    IsTest = true,
                    Star = EStar.None,
                    IsBlocked = true,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Տարվա 4 եղանակները",
                    Game = EGame.YearWeather,
                    Star = EStar.None,
                    IsBlocked = true,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Oրվա եղանակը",
                    Game = EGame.DayWeather,
                    Star = EStar.None,
                    IsBlocked = true,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Պարզ ածականներ",
                    Game = EGame.SimpleAdjectives,
                    Star = EStar.None,
                    IsBlocked = true,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Թեստ 3",
                    Game = EGame.Test3,
                    IsTest = true,
                    IsBlocked = true,
                    Star = EStar.None,
                    GameVariant = EGameVariant.None,
                },
            };
            GameVariants = new Dictionary<EGame, IEnumerable<GameVariantBindableModel>>();
            GameVariants.Add(EGame.Animals, new List<GameVariantBindableModel>()
            {
                new GameVariantBindableModel
                {
                    IsStart = true,
                    Name = "Սկսել",
                },
                new GameVariantBindableModel
                {
                    Name = "Panda",
                    Icon = "panda",
                    Game = EGame.Animals,
                    GameVariant = EGameVariant.Panda,
                    ArmDescription = "Սա պանդա է",
                    EngDescription = "This is a panda",

                },
                new GameVariantBindableModel
                {
                    Name = "Dog",
                    Game = EGame.Animals,
                    Icon = "dog",
                    GameVariant = EGameVariant.Dog,
                    ArmDescription = "Սա շուն է",
                    EngDescription = "This is a dog",
                },
                new GameVariantBindableModel
                {
                    Name = "Cat",
                    Game = EGame.Animals,
                    Icon = "cat",
                    GameVariant = EGameVariant.Cat,
                    ArmDescription = "Սա կատու է",
                    EngDescription = "This is a cat",
                },
                new GameVariantBindableModel
                {
                    Name = "Fox",
                    Game = EGame.Animals,
                    Icon = "fox",
                    GameVariant = EGameVariant.Fox,
                    ArmDescription = "Սա աղվես է",
                    EngDescription = "This is a fox",
                },
                new GameVariantBindableModel
                {
                    Name = "Հարց 1",
                    Game = EGame.Animals,
                    GameVariant = EGameVariant.Animals_Question1,
                    IsQuestion = true,
                },
                new GameVariantBindableModel
                {
                    Name = "Wolf",
                    Icon = "wolf",
                    Game = EGame.Animals,
                    GameVariant = EGameVariant.Wolf,
                    ArmDescription = "Սա գայլ է",
                    EngDescription = "This is a wolf",
                },
                new GameVariantBindableModel
                {
                    Name = "Lion",
                    Icon = "lion",
                    Game = EGame.Animals,
                    GameVariant = EGameVariant.Lion,
                    ArmDescription = "Սա առյուծ է",
                    EngDescription = "This is a lion",
                },
                new GameVariantBindableModel
                {
                    Name = "Tiger",
                    Game = EGame.Animals,
                    Icon = "tiger",
                    GameVariant = EGameVariant.Tiger,
                    ArmDescription = "Սա վագր է",
                    EngDescription = "This is a tiger",
                },
                new GameVariantBindableModel
                {
                    Name = "Bear",
                    Icon = "bear",
                    Game = EGame.Animals,
                    GameVariant = EGameVariant.Bear,
                    ArmDescription = "Սա արջ է",
                    EngDescription = "This is a bear",
                },
                new GameVariantBindableModel
                {
                    Name = "Հարց 2",
                    Game = EGame.Animals,
                    GameVariant = EGameVariant.Animals_Question2,
                    IsQuestion = true,
                },
                new GameVariantBindableModel
                {
                    Name = "Cow",
                    Game = EGame.Animals,
                    Icon = "cow",
                    GameVariant = EGameVariant.Cow,
                    ArmDescription = "Սա կով է",
                    EngDescription = "This is a cow",
                },
                new GameVariantBindableModel
                {
                    Name = "Pig",
                    Game = EGame.Animals,
                    Icon = "pig",
                    GameVariant = EGameVariant.Pig,
                    ArmDescription = "Սա խոզ է",
                    EngDescription = "This is a Pig",
                },
                new GameVariantBindableModel
                {
                    Name = "Sheep",
                    Icon = "sheep",
                    Game = EGame.Animals,
                    GameVariant = EGameVariant.Sheep,
                    ArmDescription = "Սա ոչխար է",
                    EngDescription = "This is a sheep",
                },
                new GameVariantBindableModel
                {
                    Name = "Hippopotamus",
                    Icon = "hippopotamus",
                    Game = EGame.Animals,
                    GameVariant = EGameVariant.Hippopotamus,
                    ArmDescription = "Սա գետաձի է",
                    EngDescription = "This is a hippopotamus",
                },
                new GameVariantBindableModel
                {
                    Name = "Հարց 3",
                    Game = EGame.Animals,
                    GameVariant = EGameVariant.Animals_Question3,
                    IsQuestion = true,
                },
                new GameVariantBindableModel
                {
                    Name = "Elefant",
                    Icon = "elefant",
                    Game = EGame.Animals,
                    GameVariant = EGameVariant.Elefant,
                    ArmDescription = "Սա փիղ է",
                    EngDescription = "This is a elefant",
                },
                new GameVariantBindableModel
                {
                    Name = "Giraffe",
                    Icon = "giraffe",
                    Game = EGame.Animals,
                    GameVariant = EGameVariant.Giraffe,
                    ArmDescription = "Սա ընձուղտ է",
                    EngDescription = "This is a giraffe",
                },
                new GameVariantBindableModel
                {
                    Name = "Camel",
                    Icon = "camel",
                    Game = EGame.Animals,
                    GameVariant = EGameVariant.Camel,
                    ArmDescription = "Սա ուղտ է",
                    EngDescription = "This is a camel",
                },
                new GameVariantBindableModel
                {
                    Name = "Donkey",
                    Icon = "donkey",
                    Game = EGame.Animals,
                    GameVariant = EGameVariant.Donkey,
                    ArmDescription = "Սա էշ է",
                    EngDescription = "This is a donkey",
                },
                new GameVariantBindableModel
                {
                    Name = "Հարց 4",
                    Game = EGame.Animals,
                    GameVariant = EGameVariant.Animals_Question4,
                    IsQuestion = true,
                },
            });
        }

        public int GetGameVariantsCount(EGame game)
        {
            return GameVariants[game].Count();
        }
    }
}
