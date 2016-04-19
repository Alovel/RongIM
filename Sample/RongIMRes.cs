using IO.Rong.Imkit;

namespace Sample
{
	public class RongIMRes
	{
		public static void Init()
		{
            R.Array.RcEmojiCode = Resource.Array.rc_emoji_code;
			R.Array.RcEmojiRes = Resource.Array.rc_emoji_res;

			R.Attr.RCActiveColor = Resource.Attribute.RCActiveColor;
			R.Attr.RCActiveType = Resource.Attribute.RCActiveType;
			R.Attr.RCCentered = Resource.Attribute.RCCentered;
			R.Attr.RCCornerRadius = Resource.Attribute.RCCornerRadius;


			IO.Rong.Imkit.R.Layout.RcFrConversationlist = Resource.Layout.rc_fr_conversationlist;
            IO.Rong.Imkit.R.Color.RcTextColorPrimaryInverse = Resource.Color.rc_text_color_primary_inverse;

        }
	}
}