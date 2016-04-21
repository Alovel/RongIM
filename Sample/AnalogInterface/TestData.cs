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
using IO.Rong.Imlib.Model;

namespace Sample.AnalogInterface
{
    public class TestData
    {
        private static List<UserInfo> userOneFriendList = new List<UserInfo>()
        {
            new UserInfo("10001","Jerry",Android.Net.Uri.Parse("http://lab.grapeot.me/xiong/imgs/172.jpg")),
            new UserInfo("10000","Lee",Android.Net.Uri.Parse("http://lab.grapeot.me/xiong/imgs/159.jpg")),
            new UserInfo("10003","Lisa",Android.Net.Uri.Parse("http://lab.grapeot.me/xiong/imgs/1194.jpg")),
            new UserInfo("10004","单雄信",Android.Net.Uri.Parse("http://lab.grapeot.me/xiong/imgs/158.jpg")),
            new UserInfo("10005","万俟阿门",Android.Net.Uri.Parse("http://lab.grapeot.me/xiong/imgs/190.jpg")),
            new UserInfo("10006","岑云",Android.Net.Uri.Parse("http://lab.grapeot.me/xiong/imgs/186.jpg")),
            new UserInfo("10007","#就是",Android.Net.Uri.Parse("http://lab.grapeot.me/xiong/imgs/1449.jpg")),
            new UserInfo("10007","迪斯卡",Android.Net.Uri.Parse("http://lab.grapeot.me/xiong/imgs/851.jpg")),
        };

        private static List<UserInfo> userTwoFriendList = new List<UserInfo>()
        {
            new UserInfo("10001","Tom",Android.Net.Uri.Parse("http://lab.grapeot.me/xiong/imgs/172.jpg")),
            new UserInfo("10002","Lisa",Android.Net.Uri.Parse("http://lab.grapeot.me/xiong/imgs/189.jpg"))
        };

        private static Dictionary<string, List<UserInfo>> userFriendDictionary
            = new Dictionary<string, List<UserInfo>>
            {
                {"10002", userOneFriendList },
                { "10000",userTwoFriendList}
            };

        private static Dictionary<string, string> userIdAndToken = new Dictionary<string, string>()
        {
            { "10000", "mPqbWyp9IwwhG2uZhiG46mYdDZRj6BeRoAR/bJf7QdjPTC/v5UhAkk6+6JnWlOcYEmOUo2HdtR1233CXsBt44A=="},
            { "10001","rnXKQBiOzeOChqFg0ITxn2YdDZRj6BeRoAR/bJf7QdjPTC/v5UhAkj4sTQo9Dh8d6jts2/CvARpmxJy9vRVwtA=="},
            { "10002","4Ajc30pgab3NRKfT8kmLqGYdDZRj6BeRoAR/bJf7QdjPTC/v5UhAkvY7Rhiy2PRE6jts2/CvARo3gX1rpNGu5A=="},
            { "10003","Cs7Xd+NNHRaAA/cq5CueJJqTvD/Kg2uK5PVbEjMK8zbcXOGPnkQ1vzAXtGDh19HTmyeeQ/+60BNjMWYv7nd4bA=="},
            { "10004","U4a3MTTJwQDmH7XJtzqZWyfgVEH7kxr5BSGB4B2K5oBwdqByXl+ty3AQogwJNwJYOuJJlpxZpULcDshXSGN/qg=="},
            { "10005","AqQ16S0Vl/rlDVV5q3TC72YdDZRj6BeRoAR/bJf7QdjPTC/v5UhAklyWI7SQ4pcASb2xymm+bqJHBUpj0JoNfQ=="},
            { "10006","2Lzk6i+6/w52F0eW9MzxP2YdDZRj6BeRoAR/bJf7QdjPTC/v5UhAkqYkvs1AwKV5PKiE4K3QsQkN8EOm86o8fw=="},
            { "10007","3jNTajnUBarNJ6g7uBVxeyfgVEH7kxr5BSGB4B2K5oBwdqByXl+ty1FebJzkb0P0oe5WoeFqrXtvua0t0+0xVA=="},
            { "10008","uQkdkobzhtlYJo0B3NHDBJqTvD/Kg2uK5PVbEjMK8zYX6zqFZcn/OIi9xJm2zl1BmyeeQ/+60BP3hMpzYeoK5w=="}
        };

        private static Dictionary<string, string> avatorAndIdMap = new Dictionary<string, string>()
        {
            {"10000","http://lab.grapeot.me/xiong/imgs/159.jpg" },
            { "10001","http://lab.grapeot.me/xiong/imgs/172.jpg"},
            { "10002","http://lab.grapeot.me/xiong/imgs/189.jpg"},
            { "10003","http://lab.grapeot.me/xiong/imgs/1194.jpg"},
            { "10004","http://lab.grapeot.me/xiong/imgs/158.jpg"},
            {"10005","http://lab.grapeot.me/xiong/imgs/190.jpg" },
            { "10006","http://lab.grapeot.me/xiong/imgs/186.jpg"},
            { "10007","http://lab.grapeot.me/xiong/imgs/1449.jpg"},
            { "10008","http://lab.grapeot.me/xiong/imgs/851.jpg"}
        };


        public static List<UserInfo> GetUserFriends(string userId)
        {
            return userFriendDictionary[userId];
        }


        public static string GetAvatorByUserId(string userId)
        {
            return avatorAndIdMap[userId];
        }

        public static string GetCurrentUserTokenByUesrId(string userId)
        {
            return userIdAndToken[userId];
        }

        public static string GetUserIdByToken(string token)
        {
            return userIdAndToken.FirstOrDefault(p => p.Value == token).Key;
        }
    }
}