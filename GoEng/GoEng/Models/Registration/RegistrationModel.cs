using GoEng.Enums;
using System;

namespace GoEng.Models.Registration
{
    public class RegistrationModel
    {
        public string Id { get; set; }
        public string UserUID { get; set; }
        public string Name { get; set; }
        public EGender Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public bool IsEmailVerified { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
