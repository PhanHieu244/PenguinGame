using System;

namespace ChuongCustom
{
    public static class ScoreManager
    {
        public static event Action<int> OnScoreChange;
        private static int _score;

        public static int Score
        {
            get => _score;
            set
            {
                _score = value;
                OnScoreChange?.Invoke(value);

                OnUpdateHighScore(value);
            }
        }

        public static void OnUpdateHighScore(int score)
        {
            if (score >= Data.Player.HighScore) Data.Player.HighScore = score;
        }

        public static void Reset()
        {
            Score = 0;
        }
    }
}