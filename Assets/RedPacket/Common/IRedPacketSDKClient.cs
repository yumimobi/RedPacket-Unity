using System;
using RedPacket.API;
using UnityEngine;

namespace RedPacket.Common
{
    public interface IRedPacketSDKClient
    {
        event EventHandler<EventArgs> OnSDKInitFailed;
        event EventHandler<RPSDKEventArgs> OnSDKInitSuccess;
        event EventHandler<EventArgs> OnLeftViewHasBeenShown;
        event EventHandler<EventArgs> OnLeftViewHasBeenClicked;
        event EventHandler<EventArgs> OnRedPacketControllerHasBeenShown;
        event EventHandler<EventArgs> OnRedPacketControllerHasBeenDismissed;
        event EventHandler<EventArgs> OnRedPacketControllerHasBeenClicked;
        event EventHandler<EventArgs> OnFinalRedPacketControllerHasBeenShown;
        event EventHandler<EventArgs> OnFinalRedPacketControllerHasBeenDismissed;

        bool IsReady();
        bool IsInitCompleted();
        void ShowLeftView(Transform rect);
        void DestroyLeftView();
        void ShowRedPacketController();
        void ShowFinalRedPacketController();
        
    }
}