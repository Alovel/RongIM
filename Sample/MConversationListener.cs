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
using IO.Rong.Imlib.Model;
using Sample.UI;

namespace Sample
{
    public class MConversationListener : Java.Lang.Object, RongIM.IConversationBehaviorListener
    {
        

        public bool OnMessageClick(Context p0, View p1, IO.Rong.Imlib.Model.Message p2)
        {
            return false;
        }

        public bool OnMessageLinkClick(Context p0, string p1)
        {
            return false;
        }

        public bool OnMessageLongClick(Context p0, View p1, IO.Rong.Imlib.Model.Message p2)
        {
            return false;
        }

        public bool OnUserPortraitClick(Context p0, Conversation.ConversationType p1, UserInfo p2)
        {
            if (p2 != null)
            {
                Intent intent = new Intent(p0, typeof(PersonalDetailActivity));
                intent.PutExtra("CONTACTS_USER", p2);
                p0.StartActivity(intent);
            }

            return false;
        }

        public bool OnUserPortraitLongClick(Context p0, Conversation.ConversationType p1, UserInfo p2)
        {
            return false;
        }
    }
}