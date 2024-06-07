using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Movement
{
    public class LoopBackground : SerializedMonoBehaviourSingleton<LoopBackground>
    {
        [SerializeField] private MonoBackground background;
        [SerializeField] private Transform spawnMilestone, releaseMilestone;
        private void Start()
        {
            SetupBackgroundElement(background);
        }

        public void OnStartGame()
        {
            background.Move();
        }

        private void SetupBackgroundElement(MonoBackground monoBackground)
        {
            monoBackground.StartCheckMilestone(spawnMilestone, SpawnBackground);
            monoBackground.StartCheckMilestone(releaseMilestone, ReleaseBackground);
        }
        
        private void SpawnBackground(MonoBackground monoBackground)
        {
            var newBackground = BackgroundPool.Instance.Get();
            var newPos = monoBackground.transform.position;
            newPos.y = monoBackground.EndPoint.position.y;
            newBackground.transform.position = newPos;
            SetupBackgroundElement(newBackground);
            newBackground.Move();
        }

        private void ReleaseBackground(MonoBackground monoBackground)
        {
            monoBackground.Release();
        }
    }
}