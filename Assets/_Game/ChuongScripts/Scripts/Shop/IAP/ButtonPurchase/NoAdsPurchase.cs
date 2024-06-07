using TMPro;
using UnityEngine;

namespace ChuongCustom
{
    public class NoAdsPurchase : ButtonPurchase
    {
        [SerializeField] protected TextMeshProUGUI price;
        [SerializeField] protected bool hideWhenBuy = true;
        public static bool NoAdsAvailable
        {
            get => PlayerPrefs.GetInt("NoAdsPurchaseKey", 0) != 0;
            set => PlayerPrefs.SetInt("NoAdsPurchaseKey", value ? 1 : 0);
        }
        
        protected override void Setup()
        {
            if(hideWhenBuy) gameObject.SetActive(NoAdsAvailable);
        }

        protected override void SetupPurchaseData(IAPData iapData)
        {
            price.text = iapData.price;
        }

        protected override void OnPurchaseSuccess()
        {
            NoAdsAvailable = true;
            BuyNoAds();
            Refresh();
        }

        private void BuyNoAds()
        {
            //todo add noAds InGame
        }

        private void Refresh()
        {
            Setup();
            //todo something 
        }
    }
}