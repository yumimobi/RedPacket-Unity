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

        public event EventHandler<EventArgs> OnSDKInitFailed;
        public event EventHandler<RPSDKEventArgs> OnSDKInitSuccess;
        public event EventHandler<EventArgs> OnLeftViewHasBeenShown;
        public event EventHandler<EventArgs> OnLeftViewHasBeenClicked;
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenShown;
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenDismissed;
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenClicked;
        public event EventHandler<EventArgs> OnFinalRedPacketControllerHasBeenShown;
        public event EventHandler<EventArgs> OnFinalRedPacketControllerHasBeenClicked;

        public bool IsReady()
        {
            return client.IsReady();
        }

        public void ShowLeftView(Transform windowAdRect)
        {
            client.ShowLeftView(windowAdRect);
        }
        public void DestroyLeftView()
        {
            client.DestroyLeftView();
        }
        public void ShowRedPacketController()
        {
            client.ShowRedPacketController();
        }
        public void ShowFinalRedPacketController()
        {
            client.ShowFinalRedPacketController();
        }
        
    }
}