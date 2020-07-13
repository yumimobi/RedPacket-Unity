#if UNITY_IOS

using System;
using System.Runtime.InteropServices;

namespace RedPacket.iOS
{    
    class Externs
    {   
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
        internal static extern void rpSDKShowLeftView(IntPtr sdk, int x, int y, int width);
        
        [DllImport("__Internal")]
        internal static extern void rpSDKDestroyLeftView(IntPtr sdk);
        
        [DllImport("__Internal")]
        internal static extern void rpSDKShowRedPacketVc(IntPtr sdk);

        [DllImport("__Internal")]
        internal static extern void rpSDKShowRedPacketFinalVc(IntPtr sdk);
        
        [DllImport("__Internal")]
        internal static extern bool rpSDKIsReady(IntPtr sdk);

        [DllImport("__Internal")]
        internal static extern bool rpSDKIsInitCompleted(IntPtr sdk);
        #endregion
    }
}
#endif