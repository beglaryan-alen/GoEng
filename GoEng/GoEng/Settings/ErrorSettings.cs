namespace GoEng.Settings
{
    public class ErrorSettings
    {
        public const string IncorrectAgeErrorMessage = "Age is not correct, please change it.";
        public const string IncorrectLoginAndPass = "Login or password are wrong.";
        public const string RegisterErrorMessage = "Your information are wrong, please set the right info.";
        public const string RegisterErrorMessage_InvalidEmailAddress = "Your email is invalid, please type correct one.";
        public const string RegisterErrorMessage_PasswordWithoutLetter = "Password needs at least 1 letter in your password.";
        public const string RegisterErrorMessage_PasswordWithoutSymbol = "Password needs at least 1 symbol in your password.";
        public const string RegisterErrorMessage_PasswordWithoutNumber = "Password needs at least 1 number in your password.";
        public const string RegisterErrorMessage_PasswordWithWhiteSpace = "Password is not correct.";
        public const string RegisterErrorMessage_LetterLength = "Password minimun length is 4.";
        public const string RegisterErrorMessage_WeakPassword = "Your password is too weak, please change it.";
        public const string RegisterErrorMessage_EmailExist = "Your email is already registered, please login.";
        public const string RegisterErrorMessage_TooManyAttempts = "Too many request, try later.";
        public const string EmailVerificationMessage = "Please verify your email and log in.";
    }
}
