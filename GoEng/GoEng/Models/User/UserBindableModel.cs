using GoEng.Enums;
using GoEng.Enums.User;
using Prism.Mvvm;
using System;

namespace GoEng.Models.User
{
    public class UserBindableModel : BindableBase
    {
        #region Public Properties
        
        private string _photoUrl;
        public string PhotoUrl
        {
            get => _photoUrl;
            set => SetProperty(ref _photoUrl, value);
        }

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private int _coins;
        public int Coins 
        {
            get => _coins;
            set => SetProperty(ref _coins, value);
        }

        private int _activeDays;
        public int ActiveDays
        {
            get => _activeDays;
            set => SetProperty(ref _activeDays, value);
        }

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value);
        }

        private DateTime _dateOfBirth;
        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            set => SetProperty(ref _dateOfBirth, value);
        }

        private EGender _gender;
        public EGender Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }

        #endregion
    }
}
