
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using IO.Rong.Imkit.Fragment;
using IO.Rong.Imlib.Model;

namespace Sample
{
	//[Activity]
	//public class ConversationListActivity : FragmentActivity
	//{
	//	protected override void OnCreate(Bundle savedInstanceState)
	//	{
	//		base.OnCreate(savedInstanceState);
	//		SetContentView(Resource.Layout.ConverSationList);

	//		EnterFragment();
	//	}

	//	private void EnterFragment()
	//	{
 //           var fragment = (ConversationListFragment)SupportFragmentManager.FindFragmentById(Resource.Id.conversationlist);
 //           var uri = Android.Net.Uri.Parse($"rong://{ApplicationInfo.PackageName}").BuildUpon()
 //               .AppendPath("conversationlist")
 //               .AppendQueryParameter(Conversation.ConversationType.Private.Name, "false")
 //               .AppendQueryParameter(Conversation.ConversationType.Group.Name, "true")
 //               .AppendQueryParameter(Conversation.ConversationType.Discussion.Name, "false")
 //               .AppendQueryParameter(Conversation.ConversationType.System.Name, "false")
 //               .Build();

 //           fragment.Uri = uri;
 //       }
	//}
}