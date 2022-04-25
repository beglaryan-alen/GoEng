using GoEng.Enums.Game;
using GoEng.Enums.User;

namespace GoEng.Models.Game
{
    public class GameModel
    {
        public EGame Game { get; set; }
        public EStar Star { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsCurrent { get; set; }
        public bool IsPassed { get; set; }
        public bool IsTest { get; set; }
        public EGameVariant GameVariant { get; set; }
    }
}
