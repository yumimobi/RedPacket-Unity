typedef const void *RPTypeRef;

#pragma mark - rp sdk
typedef const void *RPTypeSDKClientRef;
typedef const void *RPTypeSDKRef;

#pragma mark - rp sdk call backs
/// 初始化失败
typedef void (*RPSDKFailToInitCallback)(RPTypeSDKClientRef *sdkClient);
/// 初始化成功
typedef void (*RPSDKInitSuccessCallback)(RPTypeSDKClientRef *sdkClient, const char *zplayID);
/// 展示左上角用户中心入口
typedef void (*RPSDKLeftViewHasBeenShown)(RPTypeSDKClientRef *sdkClient);
/// 左上角用户中心入口被点击
typedef void (*RPSDKLeftViewHasBeenClicked)(RPTypeSDKClientRef *sdkClient);
/// 红包界面开始展示
typedef void (*RPSDKRedPacketControllerHasBeenShown)(RPTypeSDKClientRef *sdkClient);
/// 红包界面被关闭
typedef void (*RPSDKRedPacketControllerHasBeenDismissed)(RPTypeSDKClientRef *sdkClient);
/// 用户点击红包界面
typedef void (*RPSDKRedPacketControllerHasBeenClicked)(RPTypeSDKClientRef *sdkClient);
/// 红包结算界面展示
typedef void (*RPSDKFinalControllerHasBeenShown)(RPTypeSDKClientRef *sdkClient);
/// 红包结算界面关闭
typedef void (*RPSDKFinalControllerHasBeenDismissed)(RPTypeSDKClientRef *sdkClient);