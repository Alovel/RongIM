using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using IO.Rong.Imlib.Model;

namespace Sample.UI
{
    [Activity(Label = "ConversationActivity")]
    [IntentFilter(new string[] { "android.intent.action.VIEW" },
        Categories = new string[] { "android.intent.category.DEFAULT"  },
        DataScheme = "rong",
        DataPathPrefix = "/conversation/",
        DataHost ="Sample.Sample"
        )]

    public class ConversationActivity :FragmentActivity
    {

        private TextView mTitle;
        private RelativeLayout mBack;

        private string mTargetId;
        private string mTargetIds;

        private Conversation.ConversationType mConversationType;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.demo_conversation);
            mTitle = FindViewById<TextView>(Resource.Id.txt1);
            mBack = FindViewById<RelativeLayout>(Resource.Id.back);

            mBack.Click += MBack_Click;
            // Create your application here
        }

        private void MBack_Click(object sender, EventArgs e)
        {
            Finish();
        }

        private void GetIntentData(Intent intent)
        {
            mTargetId = intent.Data.GetQueryParameter("targetId");
            mTargetIds = intent.Data.GetQueryParameter("mTargetIds");

            if (mTargetId != null)
            {
                SetActionBarTitle(mTargetId);
            }

        }

        private void SetActionBarTitle(string mTargetId)
        {
            mTitle.Text = mTargetId;
        }
    }
}