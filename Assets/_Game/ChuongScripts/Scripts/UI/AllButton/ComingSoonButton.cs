using System.Collections;
using System.Collections.Generic;
using ChuongCustom;
using UnityEngine;

public class ComingSoonButton : AButton
{
    protected override void OnClickButton()
    {
        ToastManager.Instance.ShowWarningToast("This feature coming soon");
    }

    protected override void OnStart()
    {
    }
}
