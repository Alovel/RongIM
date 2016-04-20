using Android.OS;
using Android.Widget;
using Android.Support.V4.App;
using Android.App;

namespace Sample.UI
{

    [Activity]
    public class ConversationListActivity :FragmentActivity
    {
        private TextView mTitle;
        private RelativeLayout mBack;

        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            mTitle = FindViewById<TextView>(Resource.Id.txt1);
            mBack = FindViewById<RelativeLayout>(Resource.Id.back);
            mBack.Click += delegate
            {
                Finish();
            };
            mTitle.Text = "会话列表";
        }
    }
}