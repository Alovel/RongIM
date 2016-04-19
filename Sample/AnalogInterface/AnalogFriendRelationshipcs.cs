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

namespace Sample.AnalogInterface
{
    public class AnalogFriendRelationshipcs
    {
        private static List<string> userOneFriendList = new List<string>()
        {
            "10001"
        };

        private static List<string> userTwoFriendList = new List<string>()
        {
            "10000"
        };

        private static Dictionary<string, List<string>> userOneFriendDictionary
            = new Dictionary<string, List<string>>
            {
                {"10000", userOneFriendList },
                { "10001",userTwoFriendList}
            };

        private static Dictionary<string, List<string>> userTwoFriendDictionary
            = new Dictionary<string, List<string>>
            {
                { "10001",userTwoFriendList}
            };


        private static Dictionary<string, string> userIdAndToken = new Dictionary<string, string>()
        {
            { "10000", "OPNy8Dqj00pCrKpg0GKLhk0F6E/AvTTPe+oz2abWHRYjaLgFagbKd7ZNHRoD12+mMHAlOYDyVJCDNofCSx1qxw=="},
            {"10001" ,"h66xBSG6tjDe2KJEB9/zQk6UjQhdA5jCxaKmJ0Ey8qDfmSD+rq/CbI/wPQl8V6yo48SHe3fBqFWR6DpFGmVLJw=="}
        };

        private static Dictionary<string, string> tokenAndIdMap = new Dictionary<string, string>()
        {
            {"10000","http://lab.grapeot.me/xiong/imgs/159.jpg" },
            { "10001","http://lab.grapeot.me/xiong/imgs/172.jpg"}
        };

        public static List<string> GetUserFriends(string userId)
        {
            return userOneFriendDictionary[userId];
        }


        public static string GetAvatorByUserId(string userId)
        {
            return tokenAndIdMap[userId];
        }

        public static string GetCurrentUserTokenByUesrId(string userId)
        {
            return userIdAndToken[userId];
        }
    }
}