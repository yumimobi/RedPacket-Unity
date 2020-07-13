#if UNITY_IOS

using System;
using System.Runtime.InteropServices;

namespace RedPacket.iOS
{    
    class Externs
    {
        #region Common externs
        [DllImport("__Internal")]
        internal static extern IntPtr RPSDKRelease(IntPtr obj);
        #endregion
        
        #region RedPacket SDK externs
        [DllImport("__Internal")]
        internal static extern IntPtr RedPacketCreateSDK(IntPtr sdkClient);
        [DllImport("__Internal")]
        internal static extern void RedPacketSetSDKCallbacks(
            IntPtr sdk,
            RPSDKClient.RPSDKFailToInitCallback sdkFailToInitCallback,
            RPSDKClient.RPSDKInitSuccessCallback sdkSuccessToInitCallback,
            RPSDKClient.RPSDKLeftViewHasBeenShown sdkLeftViewHasBeenShownCallback,
            RPSDKClient.RPSDKLeftViewHasBeenClicked sdkLeftViewHasBeenClickedCallback,
            RPSDKClient.RPSDKRedPacketControllerHasBeenShown sdkRedPacketControllerHasBeenShownCallback,
            RPSDKClient.RPSDKRedPacketControllerHasBeenDismissed sdkRedPacketControllerHasBeenDismissedCallback,
            RPSDKClient.RPSDKRedPacketControllerHasBeenClicked sdkRedPacketControllerHasBeenClickedCallback,
            RPSDKClient.RPSDKFinalControllerHasBeenShown sdkFinalControllerHasBeenShownCallback,
            RPSDKClient.RPSDKFinalControllerHasBeenDismissed sdkFinalControllerHasBeenDismissedCallback
        );

        [DllImport("__Internal")]
        internal static extern void RPSDKShowLeftView(IntPtr sdk, int x, int y, int width);
        
        [DllImport("__Internal")]
        internal static extern void RPSDKDestroyLeftView(IntPtr sdk);
        
        [DllImport("__Internal")]
        internal static extern void RPSDKShowRedPacketVc(IntPtr sdk);

        [DllImport("__Internal")]
        internal static extern void RPSDKShowRedPacketFinalVc(IntPtr sdk);
        
        [DllImport("__Internal")]
        internal static extern bool RPSDKIsReady(IntPtr sdk);
        #endregion
    }
}
#endif