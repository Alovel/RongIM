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
using Sample.AnalogInterface;

namespace Sample.UI
{
    public class ChatFragment:Android.Support.V4.App.Fragment
    {

        private static ChatFragment mInstance;

        public static ChatFragment Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new ChatFragment();
                }
                return mInstance;
            }
        }

        private Button mPrivateChatBtn;
        private Button mGroupChatBtn;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.demo_chat, container, false);
            mPrivateChatBtn = view.FindViewById<Button>(Resource.Id.startChatBtn);
            mGroupChatBtn = view.FindViewById<Button>(Resource.Id.startGroupBtn);
            
            mPrivateChatBtn.Click += (s, e) =>
            {
                if (RongIM.Instance != null)
                {
                    string currentUserId = LocalDB.GetUserInfo();
                    var friends = TestData.GetUserFriends(currentUserId).FirstOrDefault();
                    RongIM.Instance.StartPrivateChat(Activity, friends.UserId, friends.Name);
                }
            };

            mGroupChatBtn.Click += (s, e) =>
            {
                if (RongIM.Instance != null)
                {
                    string currentUserId = LocalDB.GetUserInfo();
                    RongIM.Instance.StartGroupChat(Activity, "8888", "Èº×éÁÄÌì");
                }
            };
            return view;
        }
    }
}