using System;
using System.Reflection;
using UnityEngine;
using RedPacket.API;

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
        public event EventHandler<EventArgs> OnSDKInitFailed;
        public event EventHandler<RPSDKEventArgs> OnSDKInitSuccess;
        public event EventHandler<EventArgs> OnLeftViewHasBeenShown;
        public event EventHandler<EventArgs> OnLeftViewHasBeenClicked;
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenShown;
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenDismissed;
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenClicked;
        public event EventHandler<EventArgs> OnFinalRedPacketControllerHasBeenShown;
        public event EventHandler<EventArgs> OnFinalRedPacketControllerHasBeenDismissed;
#pragma warning restore 67
        public bool IsReady()
        {
            Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
            return true;
        }

        public void ShowLeftView(Transform rect)
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
        public void ShowFinalRedPacketController()
        {
            Debug.Log("Dummy " + MethodBase.GetCurrentMethod().Name);
        }
    }
}
