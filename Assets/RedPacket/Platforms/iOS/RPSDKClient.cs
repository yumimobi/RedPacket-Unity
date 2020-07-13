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

        public event EventHandler<EventArgs> OnSdkFailToInitCallback;
        public event EventHandler<RPSDKEventArgs> OnSdkSuccessToInitCallback;
        public event EventHandler<EventArgs> OnSdkLeftViewHasBeenShownCallback;
        public event EventHandler<EventArgs> OnSdkLeftViewHasBeenClickedCallback;
        public event EventHandler<EventArgs> OnSdkRedPacketControllerHasBeenShownCallback;
        public event EventHandler<EventArgs> OnSdkRedPacketControllerHasBeenDismissedCallback;
        public event EventHandler<EventArgs> OnSdkRedPacketControllerHasBeenClickedCallback;
        public event EventHandler<EventArgs> OnSdkFinalControllerHasBeenShownCallback;
        public event EventHandler<EventArgs> OnSdkFinalControllerHasBeenDismissedCallback;

        public RPSDKClient(GameObject gameObject)
        {
            sdkClientPtr = (IntPtr)GCHandle.Alloc(this);
            sdkPtr = Externs.RedPacketCreateSDK(windowAdClientPtr);
            Externs.RedPacketSetSDKCallbacks(
                sdkPtr,
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
            return Externs.RPSDKIsReady(windowAdPtr);
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

            Externs.rpSDKShowLeftView(sdkPtr ,x, y, width);
        }

        public void DestroyLeftView()
        {
            Externs.rpSDKDestroyLeftView(sdkPtr);
        }

        public void ShowRedPacketController()
        {
            Externs.rpSDKShowRedPacketVc(sdkPtr);
        }

        public void ShowFinalRedPacketController()
        {
            Externs.rpSDKShowRedPacketFinalVc(sdkPtr);
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
            if (client.OnSdkFailToInitCallback != null)
            {
                client.OnSdkFailToInitCallback(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKInitSuccessCallback))]
        private static void rpSDKInitSuccessCallback(IntPtr sdkClient， string zplayID)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnSdkSuccessToInitCallback != null)
            {
                RPSDKEventArgs args = new RPSDKEventArgs()
                {
                    Message = zplayID
                };
                client.OnSdkSuccessToInitCallback(client, args);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKLeftViewHasBeenShown))]
        private static void rpSDKLeftViewHasBeenShown(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnSdkLeftViewHasBeenShownCallback != null)
            {
                client.OnSdkLeftViewHasBeenShownCallback(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKLeftViewHasBeenClicked))]
        private static void rpSDKLeftViewHasBeenClicked(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnSdkLeftViewHasBeenClickedCallback != null)
            {
                client.OnSdkLeftViewHasBeenClickedCallback(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKRedPacketControllerHasBeenShown))]
        private static void rpSDKRedPacketControllerHasBeenShown(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnSdkRedPacketControllerHasBeenShownCallback != null)
            {
                client.OnSdkRedPacketControllerHasBeenShownCallback(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKRedPacketControllerHasBeenDismissed))]
        private static void rpSDKRedPacketControllerHasBeenDismissed(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnSdkRedPacketControllerHasBeenDismissedCallback != null)
            {
                client.OnSdkRedPacketControllerHasBeenDismissedCallback(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKRedPacketControllerHasBeenClicked))]
        private static void rpSDKRedPacketControllerHasBeenClicked(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnSdkRedPacketControllerHasBeenClickedCallback != null)
            {
                client.OnSdkRedPacketControllerHasBeenClickedCallback(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKFinalControllerHasBeenShown))]
        private static void rpSDKFinalControllerHasBeenShown(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnSdkFinalControllerHasBeenShownCallback != null)
            {
                client.OnSdkFinalControllerHasBeenShownCallback(client, EventArgs.Empty);
            }
        }

        [MonoPInvokeCallback(typeof(RPSDKFinalControllerHasBeenDismissed))]
        private static void rpSDKFinalControllerHasBeenShown(IntPtr sdkClient)
        {
            RPSDKClient client = IntPtrToRPSDKClient(sdkClient);
            if (client.OnSdkFinalControllerHasBeenDismissedCallback != null)
            {
                client.OnSdkFinalControllerHasBeenDismissedCallback(client, EventArgs.Empty);
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