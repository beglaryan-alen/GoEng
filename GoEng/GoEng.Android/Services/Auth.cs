using Firebase.Auth;
using Firebase.Firestore;
using GoEng.Droid.ServiceListeners;
using GoEng.Droid.Services;
using GoEng.Enums.Firebase;
using GoEng.Enums.User;
using GoEng.Models.Firebase;
using GoEng.Services.Auth;
using Java.Util;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(Auth))]
namespace GoEng.Droid.Services
{
    public class Auth : IAuth
    {
        public Task<FirebaseResponse> GetUserAsync()
        {
            var tcs = new TaskCompletionSource<FirebaseResponse>();

            FirebaseFirestore.Instance
                .Collection("users")
                .Document(FirebaseAuth.Instance.CurrentUser.Uid)
                .Get()
                .AddOnCompleteListener(new OnGetUserCompleteListener(tcs));

            return tcs.Task;
        }

        public async Task<FirebaseResponse> LoginAsync(string email, 
            string password)
        {
            try
            {
                FirebaseAuth.Instance.SignOut();
                await FirebaseAuth.Instance.SignInWithEmailAndPasswordAsync(email, password);
                return new FirebaseResponse
                {
                    Status = EFirebaseStatus.Ok,
                    IsSuccessful = true,
                };
            }
            catch (System.Exception ex)
            {
                return new FirebaseResponse
                {
                    Status = EFirebaseStatus.InvalidEmailOrPassword,
                };
            }
        }

        public async Task<FirebaseResponse> CreateUserAsync(string name, string email,
            DateTime dateOfBirth, EGender gender,
            string password, string photoUrl = "")
        {
            try
            {
                var pass = new Guid(password).ToString();

                await FirebaseAuth.Instance.CreateUserWithEmailAndPasswordAsync(email, password);
                string Uid = FirebaseAuth.Instance.CurrentUser.Uid;
                HashMap userMap = new HashMap();
                userMap.Put("name", name);
                userMap.Put("email", email);
                userMap.Put("dateOfBirth", dateOfBirth.ToString());
                userMap.Put("gender", (int)gender);
                userMap.Put("coins", 5);
                userMap.Put("activeDays", 0);
                FirebaseFirestore.Instance.Collection("users")
                    .Document(Uid)
                    .Set(userMap);

                return new FirebaseResponse
                {
                    Status = EFirebaseStatus.Ok,
                    IsSuccessful = true,
                };
            }
            catch (FirebaseAuthEmailException ex)
            {
                return new FirebaseResponse
                {
                    Status = EFirebaseStatus.InvalidEmail,
                    Message = ex.Message,
                };
            }
            catch (FirebaseAuthWeakPasswordException ex)
            {
                return new FirebaseResponse 
                {
                    Message = ex.Message,
                    Status = EFirebaseStatus.InvalidPassword,
                };
            }
            catch (FirebaseAuthInvalidCredentialsException ex)
            {
                return new FirebaseResponse
                {
                    Status = EFirebaseStatus.InvalidEmailOrPassword,
                    Message = ex.Message,
                };
            }
            catch(Exception ex)
            {
                return new FirebaseResponse
                {
                    Status = EFirebaseStatus.Exception
                };
            }
        }

        public async Task<FirebaseResponse> RechekEmailVerification()
        {
            await FirebaseAuth.Instance.CurrentUser.ReloadAsync();
            if (FirebaseAuth.Instance.CurrentUser.IsEmailVerified)
            {
                return new FirebaseResponse()
                {
                    Status = EFirebaseStatus.Ok,
                    IsSuccessful = true,
                };
            }
            else
            {
                FirebaseAuth.Instance.CurrentUser.SendEmailVerification();
                return new FirebaseResponse()
                {
                    Status = EFirebaseStatus.EmailNotVerified,
                };
            }
        }

        public async Task<FirebaseResponse> IsUserEmailVerified()
        {
            if (FirebaseAuth.Instance.CurrentUser.IsEmailVerified)
                return new FirebaseResponse()
                {
                    Status = EFirebaseStatus.EmailVerified,
                    IsSuccessful = true,
                };
            return new FirebaseResponse()
            {
                Status = EFirebaseStatus.EmailNotVerified,
            };
        }
    }
}
