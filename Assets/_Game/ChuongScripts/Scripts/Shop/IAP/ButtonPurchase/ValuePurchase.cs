using TMPro;
using UnityEngine;

namespace ChuongCustom
{
    public abstract class ValuePurchase : ButtonPurchase<IAPSingleValueData>
    {
        [SerializeField] public TextMeshProUGUI price;
        [SerializeField] public TextMeshProUGUI valueTMP;
        protected int Value;

        protected override void SetupPurchaseData(IAPSingleValueData iapData)
        {
            price.SetText(iapData.price);
            valueTMP.SetText(iapData.value.ToString());
            Value = iapData.value;
        }
    }
}