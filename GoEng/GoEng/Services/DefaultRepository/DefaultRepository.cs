using GoEng.Enums.Game;
using GoEng.Enums.User;
using GoEng.Models.Game;
using System;
using System.Collections.Generic;

namespace GoEng.Services.DefaultRepository
{
    public class DefaultRepository : IDefaultRepository
    {
        private IEnumerable<GameBindableModel> StartGames { get; set; }
        public DefaultRepository()
        {
            FillValues();
        }

        public IEnumerable<GameBindableModel> GetStartGames()
        {
            return StartGames;
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
                    GameVariant = EGameVariant.Panda,
                    IsCurrent = true,
                },
                new GameBindableModel()
                {
                    Name = "Թռչուններ",
                    Game = EGame.Birds,
                    Star = EStar.None,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Գույներ",
                    Game = EGame.Colors,
                    Star = EStar.None,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Թեստ 1",
                    Game = EGame.Test1,
                    IsTest = true,
                    Star = EStar.None,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Շաբաթվա օրեր",
                    Game = EGame.WeekDays,
                    Star = EStar.None,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "12 ամիսները",
                    Game = EGame.YearMonths,
                    Star = EStar.None,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Թվեր",
                    Game = EGame.Numbers,
                    Star = EStar.None,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Թեստ 2",
                    Game = EGame.Test2,
                    IsTest = true,
                    Star = EStar.None,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Տարվա 4 եղանակները",
                    Game = EGame.YearWeather,
                    Star = EStar.None,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Oրվա եղանակը",
                    Game = EGame.DayWeather,
                    Star = EStar.None,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Պարզ ածականներ",
                    Game = EGame.SimpleAdjectives,
                    Star = EStar.None,
                    GameVariant = EGameVariant.None,
                },
                new GameBindableModel()
                {
                    Name = "Թեստ 3",
                    Game = EGame.Test3,
                    IsTest = true,
                    Star = EStar.None,
                    GameVariant = EGameVariant.None,
                },
            };
        }
    }
}
