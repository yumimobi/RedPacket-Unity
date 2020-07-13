using System;
using System.Reflection;

using UnityEngine;

using RedPacket.Api;

namespace RedPacket.Common
{
    public class DummyClient : IRedPacketSDKClient
    {
        public DummyClient()
        {
            Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
        }

        // Disable warnings for unused dummy ad events.
#pragma warning disable 67
        event EventHandler<EventArgs> OnSDKInitFailed;
        event EventHandler<RPSDKEventArgs> OnSDKInitSuccess;
        event EventHandler<EventArgs> onLeftViewHasBeenShown;
        event EventHandler<EventArgs> OnLeftViewHasBeenClicked;
        event EventHandler<EventArgs> OnRedPacketControllerHasBeenShown;
        event EventHandler<EventArgs> OnRedPacketControllerHasBeenDismissed;
        event EventHandler<EventArgs> OnRedPacketControllerHasBeenClicked;
        event EventHandler<EventArgs> OnFinalRedPacketControllerHasBeenShown;
        event EventHandler<EventArgs> OnFinalRedPacketControllerHasBeenDismissed;
#pragma warning restore 67
        public bool IsReady(string adUnitId)
        {
            Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
            return true;
        }

        public void ShowLeftView()
        {
            Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
        }
        public void DestroyLeftView()
        {
            Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
        }
        public void ShowRedPacketController()
        {
            Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
        }
        public void showFinalRedPacketController()
        {
            Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
        }
    }
}
