using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace ChuongCustom
{
    public class SkinItem : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private Image icon;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private GameObject tick;
        
        private int _id;
        private SkinData _skinData;

        public static event Action OnDataChange;

        private void Awake()
        {
            button.onClick.AddListener(OnClick);
        }

        private void OnEnable()
        {
            OnDataChange += Setup;
        }

        private void OnDisable()
        {
            OnDataChange -= Setup;
        }

        public void Setup(int id)
        {
            this._id = id;
            _skinData = SkinDataManager.Instance.Skins[id];
            icon.sprite = _skinData.sprite;
            Setup();
        }

        public void Setup()
        {
            priceText.SetText(_skinData.price.ToString());
            priceText.gameObject.SetActive(Data.Player.skinUnlocks[_id] <= 0);
            tick.SetActive(Data.Player.currentSkin == _id);
        }

        public void OnClick()
        {
            if (Data.Player.skinUnlocks[_id] > 0)
            {
                if (Data.Player.currentSkin == _id)
                {
                    return;
                }

                Selected();
                return;
            }

            if (Data.Player.Coin < _skinData.price)
            {
                ToastManager.Instance.ShowMessageToast("Not enough Gem!!");
                return;
            }

            Data.Player.Coin -= _skinData.price;

            Data.Player.skinUnlocks[_id] = 1;
            Selected();
            ToastManager.Instance.ShowMessageToast("Buy Success!!");
        }

        private void Selected()
        {
            Data.Player.currentSkin = _id;
            OnDataChange?.Invoke();
        }
    }
}