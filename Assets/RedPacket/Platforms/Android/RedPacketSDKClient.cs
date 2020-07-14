#if UNITY_ANDROID

using System;
using UnityEngine;

using RedPacket.API;
using RedPacket.Common;

namespace RedPacket.Android
{
    public class RedPacketSDKClient : AndroidJavaProxy, IRedPacketSDKClient
    {
        private AndroidJavaObject androidRedPacket;
        private GameObject currentGameObject;

   
        public event EventHandler<EventArgs> OnSDKInitFailed = delegate { };
        public event EventHandler<RPSDKEventArgs> OnSDKInitSuccess = delegate { };
        public event EventHandler<EventArgs> OnLeftViewHasBeenShown = delegate { };
        public event EventHandler<EventArgs> OnLeftViewHasBeenClicked = delegate { };
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenShown = delegate { };
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenDismissed = delegate { };
        public event EventHandler<EventArgs> OnRedPacketControllerHasBeenClicked = delegate { };
        public event EventHandler<EventArgs> OnFinalRedPacketControllerHasBeenShown = delegate { };
        public event EventHandler<EventArgs> OnFinalRedPacketControllerHasBeenDismissed = delegate { };

        public RedPacketSDKClient(GameObject gameObject) : base(Utils.UnityRedPacketListenerClassName)
        {
            currentGameObject = gameObject;
            AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);
            AndroidJavaObject activity = playerClass.GetStatic<AndroidJavaObject>("currentActivity");
            androidRedPacket = new AndroidJavaObject(Utils.RedPacketClassName, activity, this);
        }

        #region IRedPacketClient implementation

        public bool IsInitCompleted()
        {
            return androidRedPacket.Call<bool>("isInitCompleted");
        }

        public void ShowLeftView(Transform rect)
        {
            Camera camera = Camera.main;
            Rect windowAdRect = getGameObjectRect(rect as RectTransform, camera);

            androidRedPacket.Call("showLeftView", (int)windowAdRect.x, (int)windowAdRect.y, (int)windowAdRect.width);
        }

        public void DestroyLeftView()
        {
            androidRedPacket.Call("destroyLeftView");
        }

        public void ShowRedPacketController()
        {
            androidRedPacket.Call("showRedPacketController");
        }

        public void ShowFinalRedPacketController()
        {
            androidRedPacket.Call("showFinalRedPacketController");
        }

        public bool IsReady()
        {
            return androidRedPacket.Call<bool>("isLoaded");
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

        #region Callback from UnityRedPacketListener

        void onSDKInitFailed()
        {
            if (OnSDKInitFailed != null)
            {
                OnSDKInitFailed(this, EventArgs.Empty);
            }
        }

        void onSDKInitSuccess(String userId)
        {
            if (OnSDKInitSuccess != null)
            {
                RPSDKEventArgs args = new RPSDKEventArgs()
                {
                    Message = userId
                };
                OnSDKInitSuccess(this, args);
            }
        }

        void onLeftViewHasBeenShown()
        {
            if (OnLeftViewHasBeenShown != null)
            {
                OnLeftViewHasBeenShown(this, EventArgs.Empty);
            }
        }

        void onLeftViewHasBeenClicked()
        {
            if (OnLeftViewHasBeenClicked != null)
            {
                OnLeftViewHasBeenClicked(this, EventArgs.Empty);
            }
        }

        void onRedPacketControllerHasBeenShown()
        {
            if (OnRedPacketControllerHasBeenShown != null)
            {
                OnRedPacketControllerHasBeenShown(this, EventArgs.Empty);
            }
        }

        void onRedPacketControllerHasBeenDismissed()
        {
            if (OnRedPacketControllerHasBeenDismissed != null)
            {
                OnRedPacketControllerHasBeenDismissed(this, EventArgs.Empty);
            }
        }

        void onRedPacketControllerHasBeenClicked()
        {
            if (OnRedPacketControllerHasBeenClicked != null)
            {
                OnRedPacketControllerHasBeenClicked(this, EventArgs.Empty);
            }
        }

        void onFinalRedPacketControllerHasBeenShown()
        {
            if (OnFinalRedPacketControllerHasBeenShown != null)
            {
                OnFinalRedPacketControllerHasBeenShown(this, EventArgs.Empty);
            }
        }

        void onFinalRedPacketControllerHasBeenDismissed()
        {
            if (OnFinalRedPacketControllerHasBeenDismissed != null)
            {
                OnFinalRedPacketControllerHasBeenDismissed(this, EventArgs.Empty);
            }
        }

        #endregion
    }
}

#endif