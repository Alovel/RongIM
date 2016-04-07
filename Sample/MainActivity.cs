using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using IO.Rong.Imkit;
using Android.Util;

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

			button.Click += delegate
			{
				Connect("PyLYBPLwOfzJQyqpkyqBfNt18QCZINfKI5RA2QFIW/kn/kbXFrVxArggEI+YfZ9jR4q7wP+reIE=");
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
						Log.Debug("MainActivity", "--TokenIncorrent");
					},
					Success = (e, s) =>
					{
						Log.Debug("MainActivity", "-Success");
					},
					Error = (e, s) =>
					{
						Log.Debug("MainActivity", "Error");
					}
				});
			}
		}
	}
}

