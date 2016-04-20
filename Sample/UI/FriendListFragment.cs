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
using Sino.Droid.ContactListView.Views;
using Sample.AnalogInterface;
using Sino.Droid.ContactListView;
using IO.Rong.Imkit;

namespace Sample.UI
{
    public class FriendListFragment:Android.Support.V4.App.Fragment
    {
        private  ContactListLayout mFirendList;

        private static FriendListFragment mInstance;

        public static FriendListFragment Instance
        {
            get
            {
                if (mInstance == null)
                {
                    mInstance = new FriendListFragment();
                }
                return mInstance;
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var view = inflater.Inflate(Resource.Layout.demo_friendList, container, false);
            mFirendList = view.FindViewById<ContactListLayout>(Resource.Id.demo_contactlist);
            mFirendList.ContactFirstLetterIndex(false);
            mFirendList.ListViewItemClick = (s, e) => 
            {
                if (e.UserId != null)
                {
                    if (RongIM.Instance != null)
                    {
                        RongIM.Instance.StartPrivateChat(Activity, e.UserId, e.Name);
                    }
                }
            };
            RequestFriendListFromRemote();
            return view;
        }


        private void RequestFriendListFromRemote()
        {
            string curentUserId = LocalDB.GetUserInfo();
            var friendUserInfo = TestData.GetUserFriends(curentUserId);
            if (mFirendList == null)
                return;
            List<ContactsInfo> list = new List<ContactsInfo>();
            foreach (var item in friendUserInfo)
            {
                list.Add(new ContactsInfo() { Name = item.Name, UserId = item.UserId,
                    URL = item.PortraitUri.ToString() });
            }

            mFirendList.AddContacts(list);
        }



    }
}