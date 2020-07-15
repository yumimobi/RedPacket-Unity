package com.zplay.android;

public interface UnityRedPacketListener {
    void onSDKInitFailed();
    void onSDKInitSuccess(String userid);
    void onLeftViewHasBeenShown();
    void onLeftViewHasBeenClicked();
    void onRedPacketControllerHasBeenShown();
    void onRedPacketControllerHasBeenDismissed();
    void onRedPacketControllerHasBeenClicked();
    void onFinalRedPacketControllerHasBeenShown();
    void onFinalRedPacketControllerHasBeenDismissed();
}
