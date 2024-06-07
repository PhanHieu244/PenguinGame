using UnityEngine;

namespace ChuongCustom
{
    public abstract class BaseIAPButton : AButton
    {
        [SerializeField, IAPKey] private string package_id;

        protected override void OnClickButton()
        {
            IAPManager.OnPurchaseSuccess = OnBuySuccess;
            IAPManager.Instance.BuyProductID(package_id);
        }
        protected abstract void OnBuySuccess();
        protected abstract override void OnStart();
    }
}