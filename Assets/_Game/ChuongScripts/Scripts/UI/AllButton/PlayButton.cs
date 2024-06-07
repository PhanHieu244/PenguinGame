using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : AButton
{
    public bool CheckRegister = false;

    protected override void OnClickButton()
    {
        if (Data.Player.time > 0 || CheckRegister)
        {
            SceneManager.LoadScene("GameScene");
        }
        else
        {
            Manager.ScreenManager.OpenScreen(ScreenType.RegisterScreen);
        }
    }

    protected override void OnStart()
    {
    }
}