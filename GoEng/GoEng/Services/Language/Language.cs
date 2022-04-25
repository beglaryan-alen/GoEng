using GoEng.Enums.Game;
using GoEng.Enums.Language;
using System;

namespace GoEng.Services.Language
{
    public class Language : ILanguage
    {
        public string GetGameName(ELanguage language, EGame game)
        {
            if (language is ELanguage.Eng)
                return GetEngNameFromGame(game);
            else if(language is ELanguage.Arm)
                return GetArmNameFromGame(game);
            else
            {
                throw new NotImplementedException();
            }
        }
        private string GetEngNameFromGame(EGame game) =>
            game switch
            {
                EGame.Animals => "Animals",
                EGame.Birds => "Birds",
                EGame.Colors => "Colors",
                EGame.Test1 => "Test 1",
                EGame.WeekDays => "Week Days",
                EGame.YearMonths => "Year months",
                EGame.Numbers => "Numbers",
                EGame.Test2 => "Test 2",
                EGame.YearWeather => "Year weather",
                EGame.DayWeather => "Day weather",
                EGame.SimpleAdjectives => "Simple adjectives",
                EGame.Test3 => "Test 3",
                _ => throw new NotImplementedException(),
            };
        private string GetArmNameFromGame(EGame game) =>
            game switch
            {
                EGame.Animals => "Կենդանիներ",
                EGame.Birds => "Թռչուններ",
                EGame.Colors => "Գույներ",
                EGame.Test1 => "Թեստ 1",
                EGame.WeekDays => "Շաբաթվա օրեր",
                EGame.YearMonths => "12 ամիսները",
                EGame.Numbers => "Թվեր",
                EGame.Test2 => "Թեստ 2",
                EGame.YearWeather => "Տարվա 4 եղանակները",
                EGame.DayWeather => "Oրվա եղանակը",
                EGame.SimpleAdjectives => "Պարզ ածականներ",
                EGame.Test3 => "Թեստ 3",
                _ => throw new NotImplementedException(),
            };
    }
}
