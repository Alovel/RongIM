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

            IO.Rong.Imkit.R.Layout.RcFrConversationlist = Resource.Layout.rc_fr_conversationlist;
            IO.Rong.Imkit.R.Color.RcTextColorPrimaryInverse = Resource.Color.rc_text_color_primary_inverse;

        }
	}
}