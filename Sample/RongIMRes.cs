using IO.Rong.Imkit;
using System.Text;

namespace Sample
{
	public class RongIMRes
	{
		public static void FixRes(System.Type origin,System.Type dest)
		{
			var properties = origin.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
			foreach (var property in properties)
			{
				var name = property.Name;
				string name2 = ConvertName(name);
				System.Reflection.PropertyInfo field = null;

				field = dest.GetProperty(name, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
				if (field == null && name2 != null)
				{
					field = dest.GetProperty(name2, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
				}
				if (field != null)
				{
					try
					{
						int value = (int)property.GetValue(null);
						field.SetValue(null, value);
					}
					catch(System.Exception)
					{
						continue;
					}
				}
			}
		}

		public static string ConvertName(string name)
		{
			var names = name.Split('_');
			if(name.Length <= 0)
			{
				return null;
			}
			StringBuilder str = new StringBuilder();
			foreach (var item in names)
			{
				str.Append(char.ToUpper(item[0]) + item.Substring(1));
			}
			return str.ToString();
		}

		public static void Init()
		{
			FixRes(typeof(Resource.Array), typeof(R.Array));
			FixRes(typeof(Resource.Attribute), typeof(R.Attr));
			FixRes(typeof(Resource.Boolean), typeof(R.Attr));
			FixRes(typeof(Resource.Color), typeof(R.Color));
			FixRes(typeof(Resource.Dimension), typeof(R.Dimen));
			FixRes(typeof(Resource.Drawable), typeof(R.Drawable));
			FixRes(typeof(Resource.Id), typeof(R.Id));
			FixRes(typeof(Resource.Integer), typeof(R.Integer));
			FixRes(typeof(Resource.Layout), typeof(R.Layout));
			FixRes(typeof(Resource.String), typeof(R.String));
			FixRes(typeof(Resource.Style), typeof(R.Style));
			FixRes(typeof(Resource.Styleable), typeof(R.Styleable));

            //R.Drawable.RcIcDefCoversationPortrait = Resource.Drawable.rc_ic_def_coversation_portrait;
			//R.Array.RcEmojiCode = Resource.Array.rc_emoji_code;
			//R.Array.RcEmojiRes = Resource.Array.rc_emoji_res;
        }
	}
}