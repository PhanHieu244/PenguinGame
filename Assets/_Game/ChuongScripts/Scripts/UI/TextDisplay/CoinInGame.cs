using ChuongCustom;
using TMPro;
using UnityEngine;

namespace TextDisplay
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class CoinInGame : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            GameAction.OnChangeCoin += Show;
            Show(0);
        }

        private void Show(int value)
        {
            _text.text = GameDataManager.Instance.playerData.Coin.ToString();
        }
    }
}