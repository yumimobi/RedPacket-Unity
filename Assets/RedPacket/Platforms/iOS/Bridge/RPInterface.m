#import <Foundation/Foundation.h>
#import "RPTypes.h"
#import "RPSDKBridge.h"

RPTypeSDKRef RedPacketCreateSDK(RPTypeSDKClientRef *sdkClient) 
{
    RPSDKBridge *sdk = [[RPSDKBridge alloc] initRPSDKWithSDKClientReference:sdkClient];
    return (__bridge RPTypeSDKRef)sdk;
}

void RedPacketSetSDKCallbacks(
    RPTypeSDKClientRef sdk,
    RPSDKFailToInitCallback sdkFailToInitCallback,
    RPSDKInitSuccessCallback sdkSuccessToInitCallback,
    RPSDKLeftViewHasBeenShown sdkLeftViewHasBeenShownCallback,
    RPSDKLeftViewHasBeenClicked sdkLeftViewHasBeenClickedCallback,
    RPSDKRedPacketControllerHasBeenShown sdkRedPacketControllerHasBeenShownCallback,
    RPSDKRedPacketControllerHasBeenDismissed sdkRedPacketControllerHasBeenDismissedCallback,
    RPSDKRedPacketControllerHasBeenClicked sdkRedPacketControllerHasBeenClickedCallback,
    RPSDKFinalControllerHasBeenShown sdkFinalControllerHasBeenShownCallback,
    RPSDKFinalControllerHasBeenDismissed sdkFinalControllerHasBeenDismissedCallback
){
    RPSDKBridge *sdk = (__bridge RPSDKBridge *)sdk;
    sdk.sdkFailToInitCallback = sdkFailToInitCallback;
    sdk.sdkSuccessToInitCallback = sdkSuccessToInitCallback;
    sdk.sdkLeftViewHasBeenShownCallback = sdkLeftViewHasBeenShownCallback;
    sdk.sdkLeftViewHasBeenClickedCallback = sdkLeftViewHasBeenClickedCallback;
    sdk.sdkRedPacketControllerHasBeenShownCallback = sdkRedPacketControllerHasBeenShownCallback;
    sdk.sdkRedPacketControllerHasBeenDismissedCallback = sdkRedPacketControllerHasBeenDismissedCallback;
    sdk.sdkRedPacketControllerHasBeenClickedCallback = sdkRedPacketControllerHasBeenClickedCallback;
    sdk.sdkFinalControllerHasBeenShownCallback = sdkFinalControllerHasBeenShownCallback;
    sdk.sdkFinalControllerHasBeenDismissedCallback = sdkFinalControllerHasBeenDismissedCallback;
}

void rpSDKShowLeftView(RPTypeSDKRef sdk, int x, int y, int width) {
    RPSDKBridge *sdkBridge = (__bridge RPSDKBridge *)sdk;
    [sdkBridge showLeftViewWithX:x y:y width:width];
}

void rpSDKDestroyLeftView(RPTypeSDKRef sdk) {
    RPSDKBridge *sdkBridge = (__bridge RPSDKBridge *)sdk;
    [sdkBridge destroyLeftView];
}

void rpSDKShowRedPacketVc(RPTypeSDKRef sdk) {
    RPSDKBridge *sdkBridge = (__bridge RPSDKBridge *)sdk;
    [sdkBridge showRedPacketVc];
}

void rpSDKShowRedPacketFinalVc(RPTypeSDKRef sdk) {
    RPSDKBridge *sdkBridge = (__bridge RPSDKBridge *)sdk;
    [sdkBridge showRedPacketFinalVc];
}

BOOL rpSDKIsReady(RPTypeSDKRef sdk) {
    RPSDKBridge *sdkBridge = (__bridge RPSDKBridge *)sdk;
    [sdkBridge isReady];
}