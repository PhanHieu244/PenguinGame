using DG.Tweening;
using Movement;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ChuongCustom
{
    public class InGameManager : Singleton<InGameManager>
    {
        [SerializeField] public int PriceToPrice = 1;

        private void Start()
        {
            Time.timeScale = 0f;
            ScoreManager.Reset();
            CountPoint();
        }

        private void CountPoint()
        {
            DOVirtual.DelayedCall(0.5f, () =>
            {
                ScoreManager.Score += 1;
            }, false).SetTarget(transform).SetLoops(-1);
        }

        private void OnDestroy()
        {
            transform.DOKill();
        }

        public void TapToStart()
        {
            DOVirtual.DelayedCall(1f, () =>
            {
                Time.timeScale = 1f;
                LoopBackground.Instance.OnStartGame();
            }).SetTarget(transform);
        }

        [Button]
        public void Win()
        {
            Manager.ScreenManager.OpenScreen(ScreenType.Result);
            //todo:
        }

        [Button]
        public void Lose()
        {
            Manager.ScreenManager.OpenScreen(ScreenType.Lose);
            //todo:
        }

        [Button]
        public void BeforeLose()
        {
            Manager.ScreenManager.OpenScreen(ScreenType.BeforeLose);
            Time.timeScale = 0f;
            //todo:
        }

        public void Retry()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void Continue()
        {
            Time.timeScale = 1f;
            Player.Instance.Revive();
        }
    }
}