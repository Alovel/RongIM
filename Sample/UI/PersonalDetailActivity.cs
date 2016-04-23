
using Android.App;
using Android.OS;
using Android.Text;
using Android.Widget;
using IO.Rong.Imkit;
using IO.Rong.Imlib.Model;
using UniversalImageLoader.Core;

namespace Sample.UI
{
    [Activity(Label = "PersonalDetailActivity")]
    public class PersonalDetailActivity : Activity
    {

        private RelativeLayout mBack;
        private TextView mTitle;
        private ImageView mPersonalImage;
        private TextView mPersonalName;
        private TextView mPersonalId;
        private Button mSendMessage;


        private DisplayImageOptions mDisplayImageOptions;

        private UserInfo mUserInfo;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            RequestWindowFeature(Android.Views.WindowFeatures.NoTitle);
            SetContentView(Resource.Layout.demo_personalDetail);
            mPersonalImage = FindViewById<ImageView>(Resource.Id.personal_portrait);
            mPersonalName = FindViewById<TextView>(Resource.Id.personal_name);
            mPersonalId = FindViewById<TextView>(Resource.Id.personal_id);
            mSendMessage = FindViewById<Button>(Resource.Id.send_message);
            mTitle = FindViewById<TextView>(Resource.Id.txt1);
            mBack = FindViewById<RelativeLayout>(Resource.Id.back);
            mBack.Click += delegate
            {
                Finish();
            };
            mTitle.Text = "个人资料";
            mDisplayImageOptions = new DisplayImageOptions.Builder()
                    .ShowImageOnLoading(Resource.Drawable.rc_default_portrait)
                    .ShowImageForEmptyUri(Resource.Drawable.rc_default_portrait)
                    .ShowImageOnFail(Resource.Drawable.rc_default_portrait)
                    .CacheInMemory(true)
                    .CacheOnDisk(true)
                    .ConsiderExifParams(true)
                    .Build();
            Init();
        }

        private void Init()
        {
            if (Intent.HasExtra("CONTACTS_USER"))
            {
                mUserInfo = (UserInfo)Intent.GetParcelableExtra("CONTACTS_USER");
               
                if (mUserInfo != null)
                {
                    mPersonalName.Text = TextUtils.IsEmpty(mUserInfo.Name) ? "" : mUserInfo.Name ;
                    mPersonalId.Text = mUserInfo.UserId;
                    if (mUserInfo.PortraitUri != null)
                    {
                        ImageLoader.Instance.DisplayImage(mUserInfo.PortraitUri.ToString(),
                          mPersonalImage, mDisplayImageOptions);
                    }
                    else
                    {
                        mPersonalImage.SetBackgroundResource(Resource.Drawable.rc_default_portrait);
                    }
                    var currentUserId = LocalDB.GetUserInfo();
                    if (currentUserId != mUserInfo.UserId)
                    {
                        mSendMessage.Visibility = Android.Views.ViewStates.Visible;
                        mSendMessage.Click += (s, e) =>
                        {
                            //Toast.MakeText(this, "Test Chat", ToastLength.Short).Show();
                            if (RongIM.Instance != null)
                            {
                                if (mUserInfo.UserId != null && mUserInfo.Name != null)
                                {
                                    RongIM.Instance.StartPrivateChat(this, mUserInfo.UserId, mUserInfo.Name);
                                    Finish();
                                }
                            }
                        };
                    }
                    else
                    {
                        mSendMessage.Visibility = Android.Views.ViewStates.Invisible;
                    }
                }
            }
        }


    }
}