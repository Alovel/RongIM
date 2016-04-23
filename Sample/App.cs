using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using IO.Rong.Imkit;
using IO.Rong.Imlib.Ipc;
using UniversalImageLoader.Core;
using UniversalImageLoader.Cache.Disc.Naming;
using UniversalImageLoader.Core.Assist;

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
            var config = new ImageLoaderConfiguration.Builder(this);
            config.ThreadPriority(Java.Lang.Thread.NormPriority - 2);
            config.DenyCacheImageMultipleSizesInMemory();
            config.DiskCacheFileNameGenerator(new Md5FileNameGenerator());
            config.DiskCacheSize(50 * 1024 * 1024); 
            config.TasksProcessingOrder(QueueProcessingType.Lifo);
            config.WriteDebugLogs(); 
            ImageLoader.Instance.Init(config.Build());

            if (ApplicationInfo.PackageName.Equals(GetCurProcessName(ApplicationContext)) 
                || "io.rong.push".Equals(GetCurProcessName(ApplicationContext)))
			{
                RongIM.Init(this);
                RongIM.SetConversationBehaviorListener(new MConversationListener());
                if (ApplicationInfo.PackageName.Equals(GetCurProcessName(ApplicationContext)))
                {
                    LocalDB.Init(this);
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