using IO.Rong.Imlib;
using System;

namespace Sample
{
    internal class RongIMClientCallback : RongIMClient.ConnectCallback
    {
        public EventHandler<RongIMClient.ErrorCode> Error;
        public EventHandler<string> Success;
        public EventHandler TokenIncorrect;

        public override void OnError(RongIMClient.ErrorCode p0)
        {
            Error?.Invoke(null, p0);
        }

        public override void OnSuccess(string p0)
        {
            Success?.Invoke(null, p0);
        }

        public override void OnTokenIncorrect()
        {
            TokenIncorrect?.Invoke(null, null);
        }
    }
}