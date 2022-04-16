using GoEng.Enums.Game;
using GoEng.Enums.User;
using GoEng.Models.Game;
using System;
using System.Collections.Generic;

namespace GoEng.Services.Default
{
    public class DefaultValues : IDefaultValues
    {
        public DefaultValues()
        {
            FillValues();
        }

        public IEnumerable<GameBindableModel> DefaultGames { get; set; }

        public IEnumerable<GameBindableModel> GetDefaultGames()
        {
            return DefaultGames;
        }

        public IEnumerable<GameBindableModel> GetGamesFromLevel(EGame game)
        {
            return null;
        }

        private void FillValues()
        {
        }
    }
}
