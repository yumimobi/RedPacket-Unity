using RedPacket.Api;
using RedPacket.Common;
using UnityEngine;

namespace RedPacket
{
    public class RedPacketClientFactory
    {
        public static IRedPacketSDKClient BuildRedPacketSDKClient()
        {
#if UNITY_ANDROID
            return new Android.Client();
#elif UNITY_IPHONE
            return new iOS.RPSDKClient();
#else
            return new DummyClient();
#endif
        }
    }
}