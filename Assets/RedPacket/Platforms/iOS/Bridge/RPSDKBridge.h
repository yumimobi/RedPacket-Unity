#import <Foundation/Foundation.h>
#import "RPTypes.h"
#import <RedPacket/RPSDK.h>

@interface RPSDKBridge: NSObject
@property(nonatomic, assign) RPTypeSDKClientRef *sdkClient;
@property(nonatomic, strong) RPSDK *sdk;
@property(nonatomic, assign) RPSDKFailToInitCallback sdkFailToInitCallback;
@property(nonatomic, assign) RPSDKInitSuccessCallback sdkSuccessToInitCallback;
@property(nonatomic, assign) RPSDKLeftViewHasBeenShown sdkLeftViewHasBeenShownCallback;
@property(nonatomic, assign) RPSDKLeftViewHasBeenClicked sdkLeftViewHasBeenClickedCallback;
@property(nonatomic, assign) RPSDKRedPacketControllerHasBeenShown sdkRedPacketControllerHasBeenShownCallback;
@property(nonatomic, assign) RPSDKRedPacketControllerHasBeenDismissed sdkRedPacketControllerHasBeenDismissedCallback;
@property(nonatomic, assign) RPSDKRedPacketControllerHasBeenClicked sdkRedPacketControllerHasBeenClickedCallback;
@property(nonatomic, assign) RPSDKFinalControllerHasBeenShown sdkFinalControllerHasBeenShownCallback;
@property(nonatomic, assign) RPSDKFinalControllerHasBeenDismissed sdkFinalControllerHasBeenDismissedCallback;

- (instancetype)initRPSDKWithSDKClientReference:(RPTypeSDKClientRef *)sdkClientRef;
// 展示左上角用户中心入口，请在初始化成功后调用
// 最小宽度100pt，宽高比为2.35
// SDK将根据传入的宽度自动计算高度
- (void)showLeftViewWithX:(CGFloat)x 
                        y:(CGFloat)y
                    width:(CGFloat)width;

// 销毁左上角用户中心入口视图
- (void)destroyLeftView;

// 展示红包界面
// 展示条件：
// 1. 激励视频加载完成
// 2. 触发奖励条件
- (void)showRedPacketVc;

// 展示红包结算界面
// 展示条件：
// 1. 激励视频关闭且获得奖励
- (void)showRedPacketFinalVc;

// 红包是否准备好
- (BOOL)isReady;

@end
