using System;
using System.Collections;
using System.Collections.Generic;
using RedPacket;
using RedPacket.API;
using RedPacket.Common;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RedPacketSDKSceneScript : MonoBehaviour
{
    public InputField pointX;
    public InputField pointY;
    public InputField width;
    public GameObject leftView;
    public Text statusText;
    RedPacketSDK redPacketSDK;

    void Start()
    {


    }

    public void init()
    {
        redPacketSDK = new RedPacketSDK(gameObject);
        redPacketSDK.OnSDKInitFailed += HandleInitFailed;
        redPacketSDK.OnSDKInitSuccess += HandleInitSuccess;
        redPacketSDK.OnLeftViewHasBeenShown += HandleLeftViewHasBeenShown;
        redPacketSDK.OnLeftViewHasBeenClicked += HandleLeftViewHasBeenClicked;
        redPacketSDK.OnRedPacketControllerHasBeenShown += HandleRedPacketControllerHasBeenShown;
        redPacketSDK.OnRedPacketControllerHasBeenDismissed += HandleRedPacketControllerHasBeenDismissed;
        redPacketSDK.OnRedPacketControllerHasBeenClicked += HandleRedPacketControllerHasBeenClicked;
        redPacketSDK.OnFinalRedPacketControllerHasBeenShown += HandleFinalRedPacketControllerHasBeenShown;
        redPacketSDK.OnFinalRedPacketControllerHasBeenDismissed += HandleFinalRedPacketControllerHasBeenDismissed;
    }


    public void showLeftView()
    {
        statusText.text = "showLeftView";
       
        // x, y, width
        float x = 0;
        float y = 0;
        float w = 0;
        if (pointX.text != null && pointX.text.Length > 0)
        {
            x = float.Parse(pointX.text);
        }

        if (pointY.text != null && pointY.text.Length > 0)
        {
            y = float.Parse(pointY.text);
        }

        if (width.text != null && width.text.Length > 0)
        {
            w = float.Parse(width.text);
        }

        if (x > 0 && y > 0 && w > 0) {
            leftView.transform.position = new Vector3(x, y, 200);
            leftView.GetComponent<RectTransform>().sizeDelta = new Vector2(w, w);
        }

        if (leftView != null)
        {
            redPacketSDK.ShowLeftView(leftView.transform);
        }
    }

    public void isReady()
    {
        if (redPacketSDK != null)
        {
            redPacketSDK.IsReady();
            statusText.text = "isReady: " + redPacketSDK.IsReady();
        }
    }

    public void showRedPacketController()
    {
        if (redPacketSDK != null)
        {
            redPacketSDK.ShowRedPacketController();
        }
    }

    public void showFinalRedPacketController()
    {
        if (redPacketSDK != null)
        {
            redPacketSDK.ShowFinalRedPacketController();
           
        }
    }

    #region RedPacket callback handlers
    public void HandleInitFailed(object sender, EventArgs args)
    {
        statusText.text = "HandleInitFailed";
        print("Redpacket---HandleInitFailed");
    }

    public void HandleInitSuccess(object sender, RPSDKEventArgs args)
    {
        statusText.text = "HandleInitSuccess: " + args.Message;
        print("Redpacket---HandleInitSuccess:" + args.Message);
    }

    public void HandleLeftViewHasBeenShown(object sender, EventArgs args)
    {
        statusText.text = "HandleLeftViewHasBeenShown";
        print("Redpacket---HandleLeftViewHasBeenShown");
    }

    public void HandleLeftViewHasBeenClicked(object sender, EventArgs args)
    {
        statusText.text = "HandleLeftViewHasBeenClicked";
        print("Redpacket---HandleLeftViewHasBeenClicked");
    }


    public void HandleRedPacketControllerHasBeenShown(object sender, EventArgs args)
    {
        statusText.text = "HandleRedPacketControllerHasBeenShown";
        print("Redpacket---HandleRedPacketControllerHasBeenShown");
    }


    public void HandleRedPacketControllerHasBeenDismissed(object sender, EventArgs args)
    {
        statusText.text = "HandleRedPacketControllerHasBeenDismissed";
        print("Redpacket---HandleRedPacketControllerHasBeenDismissed");
    }

    public void HandleRedPacketControllerHasBeenClicked(object sender, EventArgs args)
    {
        statusText.text = "HandleRedPacketControllerHasBeenClicked";
        print("Redpacket---HandleRedPacketControllerHasBeenClicked");
    }

    public void HandleFinalRedPacketControllerHasBeenShown(object sender, EventArgs args)
    {
        statusText.text = "HandleFinalRedPacketControllerHasBeenShown";
        print("Redpacket---HandleFinalRedPacketControllerHasBeenShown");
    }

    public void HandleFinalRedPacketControllerHasBeenDismissed(object sender, EventArgs args)
    {
        statusText.text = "HandleFinalRedPacketControllerHasBeenDismissed";
        print("Redpacket---HandleFinalRedPacketControllerHasBeenDismissed");
    }

  
    #endregion
}
