using System;
using RedPacket.Common;
using UnityEngine;

namespace RedPacket.Api
{
    public class RedPacketSDK
    {
        IRedPacketSDKClient client;

        // Creates WindowAd instance.
        public RedPacketSDK(GameObject gameObject)
        {
            client = RedPacketClientFactory.BuildRedPacketSDKClient(gameObject);

            client.OnSDKInitFailed += (sender, args) =>
            {
                if (OnSDKInitFailed != null)
                {
                    OnSDKInitFailed(this, args);
                }
            };
            client.OnSDKInitSuccess += (sender, args) =>
            {
                if (OnSDKInitSuccess != null)
                {
                    OnSDKInitSuccess(this, args);
                }
            };
            client.OnLeftViewHasBeenShown += (sender, args) =>
            {
                if (OnLeftViewHasBeenShown != null)
                {
                    OnLeftViewHasBeenShown(this, args);
                }
            };
            client.OnLeftViewHasBeenClicked += (sender, args) =>
            {
                if (OnLeftViewHasBeenClicked != null)
                {
                    OnLeftViewHasBeenClicked(this, args);
                }
            };
            client.OnRedPacketControllerHasBeenShown += (sender, args) =>
            {
                if (OnRedPacketControllerHasBeenShown != null)
                {
                    OnRedPacketControllerHasBeenShown(this, args);
                }
            };
            client.OnRedPacketControllerHasBeenDismissed += (sender, args) =>
            {
                if (OnRedPacketControllerHasBeenDismissed != null)
                {
                    OnRedPacketControllerHasBeenDismissed(this, args);
                }
            };
            client.OnRedPacketControllerHasBeenClicked += (sender, args) =>
            {
                if(OnRedPacketControllerHasBeenClicked != null)
                {
                    OnRedPacketControllerHasBeenClicked(this, args);
                }
            };
            client.OnFinalRedPacketControllerHasBeenShown += (sender, args) =>
            {
                if(OnFinalRedPacketControllerHasBeenShown != null)
                {
                    OnFinalRedPacketControllerHasBeenShown(this, args);
                }
            };
            client.OnFinalRedPacketControllerHasBeenClicked += (sender, args) =>
            {
                if(OnFinalRedPacketControllerHasBeenClicked != null)
                {
                    OnFinalRedPacketControllerHasBeenClicked(this, args);
                }
            };
        }
        
        /// <summary>
        /// 初始化失败
        /// </summary>
        public event EventHandler<EventArgs> OnSDKInitFailed;
        /// <summary>
        ///  初始化成功
        /// </summary>
        public event EventHandler<RPSDKEventArgs> OnSDKInitSuccess;
        /// <summary>
        /// 展示左上角用户中心入口
        /// </summary>
        public event EventHandler<EventArgs> OnLeftViewHasBeenShown;
        /// <summary>
        /// 左上角用户中心入口被点击
        /// </summary>
        public event EventHandler<EventArgs> OnLeftViewHasBeenClicked;
        /// <summary>
        /// 红包界面开始展示
        /// </summary>
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenShown;
        /// <summary>
        /// 红包界面被关闭
        /// </summary>
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenDismissed;
        /// <summary>
        /// 用户点击红包界面
        /// </summary>
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenClicked;
        /// <summary>
        /// 红包结算界面展示
        /// </summary>
        public event EventHandler<EventArgs> OnFinalRedPacketControllerHasBeenShown;
        /// <summary>
        /// 红包结算界面关闭
        /// </summary>
        public event EventHandler<EventArgs> OnFinalRedPacketControllerHasBeenDismissed;

        /// <summary>
        /// 红包是否准备好
        /// </summary>
        /// <returns></returns>
        public bool IsReady()
        {
            return client.IsReady();
        }
        /// <summary>
        /// 展示左上角用户中心入口，请在初始化成功后调用
        /// 最小宽度100pt，宽高比为2.35
        /// SDK将根据传入的宽度自动计算高度
        /// </summary>
        /// <param name="rect"></param>
        public void ShowLeftView(Transform rect)
        {
            client.ShowLeftView(windowAdRect);
        }
        /// <summary>
        /// 销毁左上角用户中心入口视图
        /// </summary>
        public void DestroyLeftView()
        {
            client.DestroyLeftView();
        }
        /// <summary>
        /// 展示红包界面
        /// 展示条件：
        /// 1. 激励视频加载完成
        /// 2. 触发奖励条件
        /// </summary>
        public void ShowRedPacketController()
        {
            client.ShowRedPacketController();
        }
        /// <summary>
        /// 展示红包结算界面
        /// 展示条件：
        /// 1. 激励视频关闭且获得奖励
        /// </summary>
        public void ShowFinalRedPacketController()
        {
            client.ShowFinalRedPacketController();
        }
        
    }
}