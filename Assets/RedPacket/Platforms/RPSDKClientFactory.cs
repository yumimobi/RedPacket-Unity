using RedPacket.API;
using RedPacket.Common;
using UnityEngine;

namespace RedPacket
{
    public class RedPacketClientFactory
    {
        public static IRedPacketSDKClient BuildRedPacketSDKClient(GameObject gameObject)
        {
#if UNITY_ANDROID
            return new Android.RedPacketSDKClient(gameObject);
#elif UNITY_IPHONE
            return new iOS.RPSDKClient(gameObject);
#else
            return new DummyClient();
#endif
        }
    }
}