using TMPro;
using UnityEngine;

namespace ChuongCustom
{
    public abstract class DoubleValuePurchase : ButtonPurchase<IAPDoubleValueData>
    {
        [SerializeField] public TextMeshProUGUI price;
        [SerializeField] public TextMeshProUGUI firstValueTMP;
        [SerializeField] public TextMeshProUGUI secondValueTMP;
        protected int Value1;
        protected int Value2;

        protected override void SetupPurchaseData(IAPDoubleValueData iapData)
        {
            price.SetText(iapData.price);
            firstValueTMP.SetText(iapData.value1.ToString());
            secondValueTMP.SetText(iapData.value2.ToString());
            Value1 = iapData.value1;
            Value2 = iapData.value2;
        }
    }
}