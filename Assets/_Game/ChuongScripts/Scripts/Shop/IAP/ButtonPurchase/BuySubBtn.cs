using TMPro;

namespace ChuongCustom
{
    using UnityEngine;

    public class BuySubIAP : ButtonPurchase<IAPSingleValueData>
    {
        [SerializeField] public TextMeshProUGUI price;
        [SerializeField] public TextMeshProUGUI valueTMP;
        private int Value;

        protected override void SetupPurchaseData(IAPSingleValueData iapData)
        {
            price.SetText(iapData.price);
            valueTMP.SetText(iapData.value.ToString() + "day(s)");
            Value = iapData.value;
        }

        protected override void Setup()
        {
        }

        protected override void OnPurchaseSuccess()
        {
            ToastManager.Instance.ShowMessageToast("Buy Success!!");

            AddTime(Value);
        }

        private void AddTime(int time)
        {
            Manager.Register.AddTime(time);
            GameAction.SetRegisterTime.Invoke(time);
        }
    }
}