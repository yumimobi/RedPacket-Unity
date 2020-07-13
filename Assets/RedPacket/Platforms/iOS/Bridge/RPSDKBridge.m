#import "RPSDKBridge.h"

@interface RPSDKBridge ()<RPSDKDelegate>
@end

@implementation RPSDKBridge
- (instancetype)initRPSDKWithSDKClientReference:(RPTypeSDKClientRef *)sdkClientRef {
    if (self = [super init]) {
        _sdkClient = sdkClientRef;
        _sdk = [RPSDK shared];
        _sdk.delegate = self;
    }
    return self;
}
// 展示左上角用户中心入口，请在初始化成功后调用
// 最小宽度100pt，宽高比为2.35
// SDK将根据传入的宽度自动计算高度
- (void)showLeftViewWithX:(CGFloat)x 
                        y:(CGFloat)y
                    width:(CGFloat)width {
    CGFloat height = width/2.35;
    CGRect frame = CGRectMake(x, y, width, height);
    [self.sdk showUserViewWith:frame viewController:UnityGetGLViewController()];
}

// 销毁左上角用户中心入口视图
- (void)destroyLeftView {
    [self.sdk destroyUserView];
}

// 展示红包界面
// 展示条件：
// 1. 激励视频加载完成
// 2. 触发奖励条件
- (void)showRedPacketVc {
    [self.sdk showRedPacketVcWith:UnityGetGLViewController()];
}

// 展示红包结算界面
// 展示条件：
// 1. 激励视频关闭且获得奖励
- (void)showRedPacketFinalVc {
    [self.sdk showRedPacketFinalVcWith:UnityGetGLViewController()];
}

// 红包是否准备好
- (BOOL)isReady {
    return self.sdk.isReady;
}

- (BOOL)isInitCompleted {
    return self.sdk.initSuccess;
}

#pragma mark - RPSDKDelegate
// 初始化失败
- (void)rpFailToInit {
    if (self.sdkFailToInitCallback) {
        self.sdkFailToInitCallback(self.sdkClient);
    }
}
// 初始化成功
- (void)rpSuccessToInitWith:(NSString *)zplayID {
    if (self.sdkSuccessToInitCallback) {
        self.sdkSuccessToInitCallback(self.sdkClient, [zplayID cStringUsingEncoding:NSUTF8StringEncoding]);
    }
}
//
// 展示左上角用户中心入口
- (void)rpLeftViewHasBeenShown {
    if (self.sdkLeftViewHasBeenShownCallback) {
        self.sdkLeftViewHasBeenShownCallback(self.sdkClient);
    }
    
}
// 左上角用户中心入口被点击
- (void)rpLeftViewHasBeenClicked {
    if (self.sdkLeftViewHasBeenClickedCallback) {
        self.sdkLeftViewHasBeenClickedCallback(self.sdkClient);
    }
}
//
// 红包界面开始展示
- (void)rpRedPacketControllerIsShowing {
    if (self.sdkRedPacketControllerHasBeenShownCallback) {
        self.sdkRedPacketControllerHasBeenShownCallback(self.sdkClient);
    }
}
// 红包界面被关闭
- (void)rpRedPacketControllerIsDismissed {
    if (self.sdkRedPacketControllerHasBeenDismissedCallback) {
        self.sdkRedPacketControllerHasBeenDismissedCallback(self.sdkClient);
    }
}
// 用户点击红包界面
- (void)rpRedPacketControllerIsClicked {
    if (self.sdkRedPacketControllerHasBeenClickedCallback) {
        self.sdkRedPacketControllerHasBeenClickedCallback(self.sdkClient);
    }
}
//
// 红包结算界面展示
- (void)rpFinalControllerIsShowing {
    if (self.sdkFinalControllerHasBeenShownCallback) {
        self.sdkFinalControllerHasBeenShownCallback(self.sdkClient);
    }
}
// 红包结算界面关闭
- (void)rpFinalControllerIsDismissed {
    if (self.sdkFinalControllerHasBeenDismissedCallback) {
        self.sdkFinalControllerHasBeenDismissedCallback(self.sdkClient);
    }
}

@end
