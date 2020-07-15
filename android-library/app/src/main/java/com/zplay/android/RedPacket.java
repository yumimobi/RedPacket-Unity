package com.zplay.android;

import android.app.Activity;
import android.util.Log;
import com.zplay.android.sdk.redpacket.ZplayRedPacketSDK;
import com.zplay.android.sdk.redpacket.listener.ZplayRedpacketListener;


public class RedPacket {
    private static final String TAG = "RedPacket";
    private Activity mActivity;

    public RedPacket(Activity activity, final UnityRedPacketListener adListener) {
        Log.d(TAG, "init: ");
        this.mActivity = activity;

        ZplayRedPacketSDK.init(mActivity, new ZplayRedpacketListener() {
            @Override
            public void onInitSuccess(final String zplayId) {
                if (adListener != null) {
                    mActivity.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onSDKInitSuccess(zplayId);
                            }
                        }
                    });
                }
            }

            @Override
            public void onInitFail() {
                if (adListener != null) {
                    mActivity.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onSDKInitFailed();
                            }
                        }
                    });
                }
            }

            @Override
            public void onLeftViewHasBeenShown() {
                if (adListener != null) {
                    mActivity.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onLeftViewHasBeenShown();
                            }
                        }
                    });
                }
            }

            @Override
            public void onLeftViewHasBeenClicked() {
                if (adListener != null) {
                    mActivity.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onLeftViewHasBeenClicked();
                            }
                        }
                    });
                }
            }

            @Override
            public void onRedPacketIsShowing() {
                if (adListener != null) {
                    mActivity.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onRedPacketControllerHasBeenShown();
                            }
                        }
                    });
                }
            }

            @Override
            public void onRedPacketIsDismissed() {
                if (adListener != null) {
                    mActivity.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onRedPacketControllerHasBeenDismissed();
                            }
                        }
                    });
                }
            }

            @Override
            public void onRedPacketIsClicked() {
                if (adListener != null) {
                    mActivity.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onRedPacketControllerHasBeenClicked();
                            }
                        }
                    });
                }
            }

            @Override
            public void onRedPacketFinalIsShowing() {
                if (adListener != null) {
                    mActivity.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onFinalRedPacketControllerHasBeenShown();
                            }
                        }
                    });
                }
            }

            @Override
            public void onRedPacketFinalIsDismissed() {
                if (adListener != null) {
                    mActivity.runOnUiThread(new Runnable() {
                        @Override
                        public void run() {
                            if (adListener != null) {
                                adListener.onFinalRedPacketControllerHasBeenDismissed();
                            }
                        }
                    });
                }
            }
        });

    }

    public boolean isInitCompleted() {
        Log.d(TAG, "isInitCompleted");
        return ZplayRedPacketSDK.initIsSuccess();
    }

    public boolean isLoaded() {
        Log.d(TAG, "isLoaded");
        return ZplayRedPacketSDK.isReady();
    }


    public void showLeftView(final int mPointX, final int mPointY, final int width) {
        Log.d(TAG, "showLeftView ");
        mActivity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                if (ZplayRedPacketSDK.initIsSuccess()) {
                    ZplayRedPacketSDK.showUserView(mActivity, mPointX, mPointY, width);
                }
            }
        });
    }


    public void destroyLeftView() {
        Log.d(TAG, "destroyLeftView");
        mActivity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                ZplayRedPacketSDK.destroyUserView(mActivity);
            }
        });
    }

    public void showRedPacketController() {
        Log.d(TAG, "showRedPacketController");
        mActivity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                ZplayRedPacketSDK.showRedPacket(mActivity);
            }
        });
    }

    public void showFinalRedPacketController() {
        Log.d(TAG, "showFinalRedPacketController");
        mActivity.runOnUiThread(new Runnable() {
            @Override
            public void run() {
                ZplayRedPacketSDK.showRedPacketFinal(mActivity);
            }
        });
    }

}
