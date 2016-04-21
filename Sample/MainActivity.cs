using Android.App;
using Android.Widget;
using Android.OS;
using IO.Rong.Imkit;
using Android.Util;
using Android.Content;
using Sample.UI;
using Sample.AnalogInterface;

namespace Sample
{
    [Activity(Label = "Sample", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);
			SetContentView(Resource.Layout.Main);
			Button button = FindViewById<Button>(Resource.Id.MyButton);
            Button btn1 = FindViewById<Button>(Resource.Id.mBtn1);
            btn1.Click += (s, e) => 
            {
                Connect("4Ajc30pgab3NRKfT8kmLqGYdDZRj6BeRoAR/bJf7QdjPTC/v5UhAkvY7Rhiy2PRE6jts2/CvARo3gX1rpNGu5A==");
            };

			button.Click += delegate
			{
				Connect("mPqbWyp9IwwhG2uZhiG46mYdDZRj6BeRoAR/bJf7QdjPTC/v5UhAkk6+6JnWlOcYEmOUo2HdtR1233CXsBt44A==");
			};
		}

		private void Connect(string token)
		{
            if (ApplicationInfo.PackageName.Equals(App.GetCurProcessName(ApplicationContext)))
            {
                RongIM.Connect(token, new RongIMClientCallback
                {
                    TokenIncorrect = (e, s) =>
                    {
                        RunOnUiThread(() =>
                        {
                            Toast.MakeText(this, "TokenIncorrect", ToastLength.Short).Show();
                        });

                        Log.Debug("MainActivity", "--TokenIncorrent");
                    },
                    Success = (e, s) =>
                    {
                        RunOnUiThread(() =>
                        {
                            Toast.MakeText(this, "Success", ToastLength.Short).Show();
                        });
                        if (RongIM.Instance != null)
                        {
                            string userId = TestData.GetUserIdByToken(token);
                            string avatorUri = TestData.GetAvatorByUserId(userId);
                            RongIM.Instance.SetCurrentUserInfo(new IO.Rong.Imlib.Model.UserInfo(userId,"###"+userId
                                ,Android.Net.Uri.Parse(avatorUri)));
                            LocalDB.SaveUserInfo(userId);
                            Intent intent = new Intent(this, typeof(HomeActivity));
                            StartActivity(intent);
                            Log.Debug("MainActivity", "-Success");
                        }

                    },
                    Error = (e, s) =>
                    {
                        RunOnUiThread(() =>
                        {
                            Toast.MakeText(this, "Error", ToastLength.Short).Show();
                        });

                        Log.Debug("MainActivity", "Error");
                    }
                });
            }
        }
	}
}

