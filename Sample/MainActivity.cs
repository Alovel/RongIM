using Android.App;
using Android.Widget;
using Android.OS;
using IO.Rong.Imkit;
using Android.Util;
using Android.Content;

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
                Connect("OPNy8Dqj00pCrKpg0GKLhk0F6E/AvTTPe+oz2abWHRYjaLgFagbKd7ZNHRoD12+mMHAlOYDyVJCDNofCSx1qxw==");
            };

			button.Click += delegate
			{
				Connect("h66xBSG6tjDe2KJEB9/zQk6UjQhdA5jCxaKmJ0Ey8qDfmSD+rq/CbI/wPQl8V6yo48SHe3fBqFWR6DpFGmVLJw==");
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

                        Intent intent = new Intent(this, typeof(ConversationListActivity));
                        StartActivity(intent);
                        Log.Debug("MainActivity", "-Success");
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

