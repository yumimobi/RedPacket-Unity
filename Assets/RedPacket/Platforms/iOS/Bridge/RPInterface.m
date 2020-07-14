#import <Foundation/Foundation.h>
#import "RPTypes.h"
#import "RPSDKBridge.h"

RPTypeSDKRef RedPacketCreateSDK(RPTypeSDKClientRef *sdkClient) 
{
    RPSDKBridge *sdk = [[RPSDKBridge alloc] initRPSDKWithSDKClientReference:sdkClient];
    return (__bridge RPTypeSDKRef)sdk;
}

void RedPacketSetSDKCallbacks(
        RPTypeSDKRef sdk,
        RPSDKFailToInitCallback sdkFailToInitCallback,
        RPSDKInitSuccessCallback sdkSuccessToInitCallback,
        RPSDKLeftViewHasBeenShown sdkLeftViewHasBeenShownCallback,
        RPSDKLeftViewHasBeenClicked sdkLeftViewHasBeenClickedCallback,
        RPSDKRedPacketControllerHasBeenShown sdkRedPacketControllerHasBeenShownCallback,
        RPSDKRedPacketControllerHasBeenDismissed sdkRedPacketControllerHasBeenDismissedCallback,
        RPSDKRedPacketControllerHasBeenClicked sdkRedPacketControllerHasBeenClickedCallback,
        RPSDKFinalControllerHasBeenShown sdkFinalControllerHasBeenShownCallback,
        RPSDKFinalControllerHasBeenDismissed sdkFinalControllerHasBeenDismissedCallback) {
    RPSDKBridge *sdkBridge = (__bridge RPSDKBridge *)sdk;
    sdkBridge.sdkFailToInitCallback = sdkFailToInitCallback;
    sdkBridge.sdkSuccessToInitCallback = sdkSuccessToInitCallback;
    sdkBridge.sdkLeftViewHasBeenShownCallback = sdkLeftViewHasBeenShownCallback;
    sdkBridge.sdkLeftViewHasBeenClickedCallback = sdkLeftViewHasBeenClickedCallback;
    sdkBridge.sdkRedPacketControllerHasBeenShownCallback = sdkRedPacketControllerHasBeenShownCallback;
    sdkBridge.sdkRedPacketControllerHasBeenDismissedCallback = sdkRedPacketControllerHasBeenDismissedCallback;
    sdkBridge.sdkRedPacketControllerHasBeenClickedCallback = sdkRedPacketControllerHasBeenClickedCallback;
    sdkBridge.sdkFinalControllerHasBeenShownCallback = sdkFinalControllerHasBeenShownCallback;
    sdkBridge.sdkFinalControllerHasBeenDismissedCallback = sdkFinalControllerHasBeenDismissedCallback;
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

BOOL rpSDKIsInitCompleted(RPTypeSDKRef sdk) {
    RPSDKBridge *sdkBridge = (__bridge RPSDKBridge *)sdk;
    [sdkBridge isInitCompleted];
}
