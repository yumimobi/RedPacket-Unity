#if UNITY_IOS
using System;
using RedPacket.Common;
using RedPacket.API;
using System.Runtime.InteropServices;
using UnityEngine;

namespace RedPacket.iOS
{
    public class RPSDKClient : IRedPacketSDKClient
    {
        private IntPtr sdkPtr;
        private IntPtr sdkClientPtr;
        private GameObject currentGameObject;
        private int x;
        private int y;
        private int width;

#region sdk callback types
        internal delegate void RPSDKFailToInitCallback(IntPtr sdkClient);
        internal delegate void RPSDKInitSuccessCallback(IntPtr sdkClient, string zplayID);
        internal delegate void RPSDKLeftViewHasBeenShown(IntPtr sdkClient);
        internal delegate void RPSDKLeftViewHasBeenClicked(IntPtr sdkClient);
        internal delegate void RPSDKRedPacketControllerHasBeenShown(IntPtr sdkClient);
        internal delegate void RPSDKRedPacketControllerHasBeenDismissed(IntPtr sdkClient);
        internal delegate void RPSDKRedPacketControllerHasBeenClicked(IntPtr sdkClient);
        internal delegate void RPSDKFinalControllerHasBeenShown(IntPtr sdkClient);
        internal delegate void RPSDKFinalControllerHasBeenDismissed(IntPtr sdkClient);
#endregion

        public event EventHandler<EventArgs> OnSDKInitFailed;
        public event EventHandler<RPSDKEventArgs> OnSDKInitSuccess;
        public event EventHandler<EventArgs> OnLeftViewHasBeenShown;
        public event EventHandler<EventArgs> OnLeftViewHasBeenClicked;
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenShown;
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenDismissed;
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenClicked;
        public event EventHandler<EventArgs> OnFinalRedPacketControllerHasBeenShown;
        public event EventHandler<EventArgs> OnFinalRedPacketControllerHasBeenDismissed;

        private IntPtr SDKPtr
        {
            get
            {
                return sdkPtr;
            }

            set
            {
                sdkPtr = value;
            }
        }

        public RPSDKClient(GameObject gameObject)
        {
            sdkClientPtr = (IntPtr)GCHandle.Alloc(this);
            SDKPtr = Externs.RedPacketCreateSDK(sdkClientPtr);
            Externs.RedPacketSetSDKCallbacks(
                SDKPtr,
                rpSDKFailToInitCallback,
                rpSDKInitSuccessCallback,
                rpSDKLeftViewHasBeenShown,
                rpSDKLeftViewHasBeenClicked,
                rpSDKRedPacketControllerHasBeenShown,
                rpSDKRedPacketControllerHasBeenDismissed,
                rpSDKRedPacketControllerHasBeenClicked,
                rpSDKFinalControllerHasBeenShown,
                rpSDKFinalControllerHasBeenDismissed
            );

            currentGameObject = gameObject;
        }

#region IRedPacketSDKClient implement 
        public bool IsReady()
        {
            return Externs.rpSDKIsReady(SDKPtr);
        }

        public bool IsInitCompleted()
        {
            return Externs.rpSDKIsInitCompleted(SDKPtr);
        }

        public void ShowLeftView(Transform rect)
        {
            if (rect != null)
            {
                Camera camera = Camera.main;
                Rect sdkRectTransform = getGameObjectRect(rect as RectTransform, camera);

                x = (int)sdkRectTransform.x;
                y = (int)sdkRectTransform.y;
                width = (int)sdkRectTransform.width;
            }

            Externs.rpSDKShowLeftView(SDKPtr ,x, y, width);
        }

        public void DestroyLeftView()
        {
            Externs.rpSDKDestroyLeftView(SDKPtr);
        }

        public void ShowRedPacketController()
        {
            Externs.rpSDKShowRedPacketVc(SDKPtr);
        }

        public void ShowFinalRedPacketController()
        {
            Externs.rpSDKShowRedPacketFinalVc(SDKPtr);
        }

        private Rect getGameObjectRect(RectTransform rectTransform, Camera camera)
        {
            if (rectTransform == null)
            {
                return Rect.zero;
            }

            Vector3[] worldCorners = new Vector3[4];
            Canvas canvas = getCanvas(this.currentGameObject);

            rectTransform.GetWorldCorners(worldCorners);
            Vector3 gameObjectBottomLeft = worldCorners[0];
            Vector3 gameObjectTopRight = worldCorners[2];
            Vector3 cameraBottomLeft = camera.pixelRect.min;
            Vector3 cameraTopRight = camera.pixelRect.max;

            if (canvas.renderMode != RenderMode.ScreenSpaceOverlay)
            {
                gameObjectBottomLeft = camera.WorldToScreenPoint(gameObjectBottomLeft);
                gameObjectTopRight = camera.WorldToScreenPoint(gameObjectTopRight);
            }

            return new Rect(Mathf.Round(gameObjectBottomLeft.x),
                            Mathf.Floor((cameraTopRight.y - gameObjectTopRight.y)),
                            Mathf.Ceil((gameObjectTopRight.x - gameObjectBottomLeft.x)),
                            Mathf.Round((gameObjectTopRight.y - gameObjectBottomLeft.y)));
        }
        private Canvas getCanvas(GameObject gameObject)
        {
            if (gameObject.GetComponent<Canvas>() != null)
            {
                return gameObject.GetComponent<Canvas>();
            }
            else
            {
                if (gameObject.transform.parent != null)
                {
                    return getCanvas(gameObject.transform.parent.gameObject);
                }
            }
            return null;
        }
        
#endregion

#region sdk callback methods
        [MonoPInvokeCallback(typeof(RPSDKFailToInitCallback))]
        private static void rpSDKFailToInitCallback(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnSDKInitFailed != null)
            {
                client.OnSDKInitFailed(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKInitSuccessCallback))]
        private static void rpSDKInitSuccessCallback(IntPtr sdkClient, string zplayID)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnSDKInitSuccess != null)
            {
                RPSDKEventArgs args = new RPSDKEventArgs()
                {
                    Message = zplayID
                };
                client.OnSDKInitSuccess(client, args);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKLeftViewHasBeenShown))]
        private static void rpSDKLeftViewHasBeenShown(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnLeftViewHasBeenShown != null)
            {
                client.OnLeftViewHasBeenShown(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKLeftViewHasBeenClicked))]
        private static void rpSDKLeftViewHasBeenClicked(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnLeftViewHasBeenClicked != null)
            {
                client.OnLeftViewHasBeenClicked(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKRedPacketControllerHasBeenShown))]
        private static void rpSDKRedPacketControllerHasBeenShown(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnRedPacketControllerHasBeenShown != null)
            {
                client.OnRedPacketControllerHasBeenShown(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKRedPacketControllerHasBeenDismissed))]
        private static void rpSDKRedPacketControllerHasBeenDismissed(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnRedPacketControllerHasBeenDismissed != null)
            {
                client.OnRedPacketControllerHasBeenDismissed(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKRedPacketControllerHasBeenClicked))]
        private static void rpSDKRedPacketControllerHasBeenClicked(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnRedPacketControllerHasBeenClicked != null)
            {
                client.OnRedPacketControllerHasBeenClicked(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKFinalControllerHasBeenShown))]
        private static void rpSDKFinalControllerHasBeenShown(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnFinalRedPacketControllerHasBeenShown != null)
            {
                client.OnFinalRedPacketControllerHasBeenShown(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKFinalControllerHasBeenDismissed))]
        private static void rpSDKFinalControllerHasBeenDismissed(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnFinalRedPacketControllerHasBeenDismissed != null)
            {
                client.OnFinalRedPacketControllerHasBeenDismissed(client, EventArgs.Empty);
            }
        }

        private static RPSDKClient IntPtrToRPSDKClient(IntPtr sdkClient)
        {
            GCHandle handle = (GCHandle)sdkClient;
            return handle.Target as RPSDKClient;
        }

#endregion
        }
    }
#endif