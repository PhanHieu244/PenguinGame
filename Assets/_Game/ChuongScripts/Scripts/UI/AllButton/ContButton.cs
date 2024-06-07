namespace ChuongCustom
{
    using System.Collections;
    using System.Collections.Generic;
    using ChuongCustom;
    using UnityEngine;

    public class ContButton : AButton
    {
        public bool _openShop = false;

        protected override void OnClickButton()
        {
            if (Data.Player.Gem >= Manager.InGame.PriceToPrice)
            {
                Data.Player.Gem -= Manager.InGame.PriceToPrice;
                Manager.InGame.Continue();
                Manager.ScreenManager.Back();
            }
            else
            {
                Manager.Toast.ShowWarningToast("Not enough money !!!!");

                if (_openShop)
                {
                    Manager.ScreenManager.OpenScreen(ScreenType.IAPScreen);
                }
            }
        }

        protected override void OnStart()
        {
        }
    }
}