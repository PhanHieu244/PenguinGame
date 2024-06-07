using UnityEngine;

namespace ChuongCustom
{
    public class BuyGemIAP : ValuePurchase
    {
        protected override void Setup()
        {
        }

        protected override void OnPurchaseSuccess()
        {
            ToastManager.Instance.ShowMessageToast("Buy Success!!");
            Data.Player.Gem += Value;
        }
    }
}