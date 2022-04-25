using GoEng.Enums.Game;
using GoEng.Enums.User;
using GoEng.Models.Game;
using System;
using System.Collections.Generic;

namespace GoEng.Models.User
{
    public class UserModel
    {
        #region Public Properties

        public string PhotoUrl { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Coins { get; set; }

        public int ActiveDays { get; set; }

        public DateTime DateOfBirth { get; set; }
        
        public EGender Gender { get; set; }
        
        #endregion
    }
}
