using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using IO.Rong.Imkit;

namespace Sample
{
	public class App : Application
	{
		public override void OnCreate()
		{
			base.OnCreate();

			if (ApplicationInfo.PackageName.Equals(GeetCurProcessName(ApplicationContext)) || "io.rong.push".Equals(GeetCurProcessName(ApplicationContext)))
			{
				RongIM.Init(this);
			}
		}

		public static string GeetCurProcessName(Context context)
		{
			int pid = Android.OS.Process.MyPid();

			ActivityManager activityManager = (ActivityManager)context
					.GetSystemService(Context.ActivityService);

			foreach (ActivityManager.RunningAppProcessInfo appProcess in activityManager
					.RunningAppProcesses)
			{

				if (appProcess.Pid == pid)
				{
					return appProcess.ProcessName;
				}
			}
			return null;
		}
	}
}