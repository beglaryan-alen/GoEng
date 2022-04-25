using GoEng.Enums.Game;
using Prism.Mvvm;

namespace GoEng.Models.GameVariant
{
    public class GameVariantBindableModel : BindableBase
    {
        #region Public Properties

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _icon;
        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        private EGame _game;
        public EGame Game
        {
            get => _game;
            set => SetProperty(ref _game, value);
        }

        private EGameVariant _gameVariant;
        public EGameVariant GameVariant
        {
            get => _gameVariant;
            set => SetProperty(ref _gameVariant, value);
        }

        public string _armDescription;
        public string ArmDescription
        {
            get => _armDescription;
            set => SetProperty(ref _armDescription, value);
        }

        public bool _isQuestion;
        public bool IsQuestion
        {
            get => _isQuestion;
            set => SetProperty(ref _isQuestion, value);
        }

        public bool _isStart;
        public bool IsStart
        {
            get => _isStart;
            set => SetProperty(ref _isStart, value);
        }

        public string _engDescription;
        public string EngDescription
        {
            get => _engDescription;
            set => SetProperty(ref _engDescription, value);
        }

        #endregion
    }
}
