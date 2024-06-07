using ChuongCustom;
using TMPro;
using UnityEngine;

namespace _Game.ChuongScripts.Scripts.UI.TextDisplay
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class HeartTextDisplay : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            GameAction.OnChangeHeart += Show;
            Show(0);
        }

        private void Show(int value)
        {
            _text.text = Data.Player.Heart.ToString();
        }
    }
}