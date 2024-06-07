using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Movement
{
    public class MonoBackground : SerializedMonoBehaviour, IPoolIdentifier<int>
    {
        [Header("Warning: Set pivot to start point!!!")]
        [SerializeField] private float speed = 5f;
        [SerializeField] private Transform endPoint;
        [SerializeField] private MovementEngine movementEngine;
        public Transform EndPoint => endPoint;
        int IPoolIdentifier<int>.Identifier { get; set; } = -999;

        private void OnValidate()
        {
            movementEngine ??= GetComponent<MovementEngine>();
        }

        public void Move()
        {
            movementEngine.Move(Vector2.up, speed);
        }

        public void Release()
        {
            BackgroundPool.Instance.Release(this);
        }

        public void StartCheckMilestone(Transform milestone, Action<MonoBackground> onPass)
        {
            StartCoroutine(IECheckMilestone(milestone, onPass));
        }

        private IEnumerator IECheckMilestone(Transform milestone, Action<MonoBackground> onPass)
        {
            while (isActiveAndEnabled)
            {
                if (transform.position.y >= milestone.position.y)
                {
                    onPass?.Invoke(this);
                    yield break;
                }
                yield return null;
            }
        }
    }
}