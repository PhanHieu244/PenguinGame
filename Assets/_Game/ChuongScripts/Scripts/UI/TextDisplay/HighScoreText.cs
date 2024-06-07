using ChuongCustom;
using TMPro;
using UnityEngine;

namespace TextDisplay
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class HighScoreText : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
            GameAction.OnHighScoreChange += Show;
            Show(0);
        }

        private void Show(int value)
        {
            _text.text = GameDataManager.Instance.playerData.HighScore.ToString();
        }
    }
}