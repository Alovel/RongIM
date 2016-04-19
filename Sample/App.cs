using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using IO.Rong.Imkit;
using IO.Rong.Imlib.Ipc;

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

				if (ApplicationInfo.PackageName.Equals(GetCurProcessName(ApplicationContext)))
				{
					Java.Lang.Thread.DefaultUncaughtExceptionHandler = new RongExceptionHandler(this);
				}
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