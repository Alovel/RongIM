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
using Android.Preferences;

namespace Sample
{
    public class LocalDB
    {
        private static LocalDB mLocalDBContext;
        private static Context mContext;
        private static ISharedPreferences mPreferences;

        public LocalDB Instance {
            get
            {
                return mLocalDBContext;
            }
        }

        private LocalDB() { }

        private LocalDB(Context context)
        {
            mContext = context;
            mLocalDBContext = this;
            mPreferences = PreferenceManager.GetDefaultSharedPreferences(context);
        }

        public static void Init(Context context)
        {
            mLocalDBContext = new LocalDB(context);
        }

        public static ISharedPreferences GetSharedPreferences()
        {
            return mPreferences;
        }

        public static void SaveUserInfo(string userId)
        {
            ISharedPreferencesEditor edit = mPreferences.Edit();
            edit.PutString("DEMO_USERID", userId);
            edit.Apply();
        }

        public static string GetUserInfo()
        {
            return mPreferences.GetString("DEMO_USERID","default");
        }

    }
}