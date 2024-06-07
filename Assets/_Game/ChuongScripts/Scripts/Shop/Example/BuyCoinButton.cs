using TMPro;
using UnityEngine;

namespace ChuongCustom
{
    public class BuyCoinButton : AShopBtn
    {
        [SerializeField] private int _amount = 1, _price = 500;
        [SerializeField] private TextMeshProUGUI _amountText, _priceText;

        protected override void ShowNotEnoughMoney()
        {
            ToastManager.Instance.ShowMessageToast("Not enough gem!!");
        }

        protected override bool IsEnoughResource()
        {
            return Data.Player.Gem >= _price;
        }

        protected override void OnBuySuccess()
        {
            Data.Player.Gem -= _price;
            Data.Player.Coin += _amount;
            ToastManager.Instance.ShowMessageToast("Buy Success!!");
            //todo:
        }

        protected override void OnStart()
        {
            _amountText.SetText(_amount.ToString());
            _priceText.SetText(_price.ToString());
        }
    }
}