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
	[Application]
	public class App : Application
	{
		public App()
			: base() { }

		protected App(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer) { }

		public override void OnCreate()
		{
			base.OnCreate();
			RongIMRes.Init();

			if (ApplicationInfo.PackageName.Equals(GetCurProcessName(ApplicationContext)) || "io.rong.push".Equals(GetCurProcessName(ApplicationContext)))
			{
				RongIM.Init(this);
			}
		}

		public static string GetCurProcessName(Context context)
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