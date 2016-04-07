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
using IO.Rong.Imlib;
using Java.Lang;

namespace Sample
{
	internal class RongIMClientCallback : RongIMClient.ConnectCallback
	{
		public override void OnError(RongIMClient.ErrorCode p0)
		{
			throw new NotImplementedException();
		}

		public override void OnSuccess(string p0)
		{
			throw new NotImplementedException();
		}

		public override void OnTokenIncorrect()
		{
			throw new NotImplementedException();
		}
	}
}