using Android.Gms.Tasks;
using Firebase.Firestore;
using GoEng.Enums.Firebase;
using GoEng.Enums.User;
using GoEng.Models.Firebase;
using GoEng.Models.User;
using System;
using System.Threading.Tasks;

namespace GoEng.Droid.ServiceListeners
{
    public class OnGetUserCompleteListener : Java.Lang.Object, IOnCompleteListener
    {
        private TaskCompletionSource<FirebaseResponse> _tcs;

        public OnGetUserCompleteListener(TaskCompletionSource<FirebaseResponse> tcs)
        {
            _tcs = tcs;
        }

        public void OnComplete(Android.Gms.Tasks.Task task)
        {
            if (task.IsSuccessful)
            {
                // process document
                var result = task.Result;
                if (result is DocumentSnapshot doc)
                {
                    var user = new UserModel();
                    user.DateOfBirth = DateTime.Parse(doc.GetString("dateOfBirth"));
                    user.Email = doc.GetString("email");
                    user.Name = doc.GetString("name");
                    user.Gender = (EGender)(Double)doc.GetDouble("gender");
                    user.Coins = Convert.ToInt32(doc.GetDouble("coins"));
                    user.ActiveDays = Convert.ToInt32(doc.GetDouble("activeDays"));
                    _tcs.TrySetResult(new FirebaseResponse
                    {
                        Content = user,
                        IsSuccessful = true,
                        Status = EFirebaseStatus.Ok,
                    });
                }
            }
            // something went wrong
            _tcs.TrySetResult(new FirebaseResponse
            {
                Status = EFirebaseStatus.ServerException,
            });
        }
    }
}
