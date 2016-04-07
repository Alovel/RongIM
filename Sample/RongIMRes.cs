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

namespace Sample
{
	public class RongIMRes
	{
		public static void Init()
		{
			IO.Rong.Imkit.R.Array.RcEmojiCode = Resource.Array.rc_emoji_code;
			IO.Rong.Imkit.R.Array.RcEmojiRes = Resource.Array.rc_emoji_res;
		}
	}
}