using System.Collections.Generic;

using Android.App;
using Android.OS;
using Android.Views;
using Android.Support.V4.App;
using Android.Support.V4.View;
using IO.Rong.Imlib.Model;
using IO.Rong.Imkit.Fragment;

namespace Sample.UI
{
    [Activity(Label = "HomeActivity", WindowSoftInputMode = SoftInput.AdjustPan)]
    public class HomeActivity : FragmentActivity
    {
        private ViewPager mViewPager;
        private Android.Support.V4.App.Fragment mConversationList;
        private List<Android.Support.V4.App.Fragment> mFragments =
            new List<Android.Support.V4.App.Fragment>();

       
        FAdapter mAdapter;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.demo_home);
            mViewPager = FindViewById<ViewPager>(Resource.Id.viewPager);
            mConversationList = InitConversationList();
            mFragments.Add(mConversationList);
            mFragments.Add(FriendListFragment.Instance);
            mFragments.Add(ChatFragment.Instance);
            mAdapter = new FAdapter(SupportFragmentManager, mFragments);
            mViewPager.Adapter = mAdapter;
        }




        private Android.Support.V4.App.Fragment InitConversationList()
        {
            if (mConversationList == null)
            {
                ConversationListFragment listFragment
                    = ConversationListFragment.Instance;

                Android.Net.Uri uri = Android.Net.Uri
                    .Parse("rong://" + ApplicationInfo.PackageName)
                    .BuildUpon()
                    .AppendPath("conversationlist")
                    .AppendQueryParameter(Conversation.ConversationType.Private.Name, "false")
                    .AppendQueryParameter(Conversation.ConversationType.Group.Name, "false")
                    .AppendQueryParameter(Conversation.ConversationType.Discussion.Name, "false")
                    .AppendQueryParameter(Conversation.ConversationType.System.Name, "false")
                    .Build();


                listFragment.Uri = uri;
                return listFragment;
            }
            else
            {
                return mConversationList;
            }

        }


        private class FAdapter : FragmentPagerAdapter
        {
            private List<Android.Support.V4.App.Fragment> mFragments;


            public FAdapter(Android.Support.V4.App.FragmentManager fm 
                ,List<Android.Support.V4.App.Fragment> fragments)
                :base(fm)
            {
                mFragments = fragments;
            }

            public override int Count
            {
                get
                {
                    return mFragments.Count;
                }
            }

            public override Android.Support.V4.App.Fragment GetItem(int position)
            {
                return mFragments[position];
            }
        }
    }
}