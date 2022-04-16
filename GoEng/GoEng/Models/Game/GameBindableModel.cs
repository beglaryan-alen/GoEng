using GoEng.Enums.Game;
using GoEng.Enums.User;
using Prism.Mvvm;

namespace GoEng.Models.Game
{
    public class GameBindableModel : BindableBase
    {
        #region Public Properties

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private EGame _gameType;
        public EGame Game
        {
            get => _gameType;
            set => SetProperty(ref _gameType, value);
        }

        private bool _isTest;
        public bool IsTest
        {
            get => _isTest;
            set => SetProperty(ref _isTest, value);
        }

        private bool _isCurrent;
        public bool IsCurrent
        {
            get => _isCurrent;
            set => SetProperty(ref _isCurrent, value);
        }

        private EStar _star;
        public EStar Star
        {
            get => _star;
            set => SetProperty(ref _star, value);
        }

        private EGameVariant _gameVariant;
        public EGameVariant GameVariant
        {
            get => _gameVariant;
            set => SetProperty(ref _gameVariant, value);
        }

        #endregion
    }
}
