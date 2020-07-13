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
            return new Android.Client();
#elif UNITY_IPHONE
            return new iOS.RPSDKClient(GameObject gameObject);
#else
            return new DummyClient();
#endif
        }
    }
}