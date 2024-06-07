using UnityEngine;

namespace ChuongCustom
{
    public class BuyCoinIAP : ValuePurchase
    {
        protected override void Setup()
        {
        }

        protected override void OnPurchaseSuccess()
        {
            ToastManager.Instance.ShowMessageToast("Buy Success!!");
            Data.Player.Coin += Value;
        }
    }
}