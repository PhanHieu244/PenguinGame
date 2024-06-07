using ChuongCustom;
using TMPro;
using UnityEngine;

namespace TextDisplay
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class ScoreText : MonoBehaviour
    {
        private TextMeshProUGUI _text;

        private void Awake()
        {
            _text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable()
        {
            ScoreManager.OnScoreChange += Show;
            Show();
        }

        private void OnDisable()
        {
            ScoreManager.OnScoreChange -= Show;
        }

        private void Show(int value = 0)
        {
            _text.SetText(ScoreManager.Score.ToString());
        }
    }
}