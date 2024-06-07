using Sirenix.OdinInspector;
using UnityEngine;

namespace Movement
{
    [DefaultExecutionOrder(-100)]
    public class SerializedMonoBehaviourSingleton<T> : SerializedMonoBehaviour where T : SerializedMonoBehaviourSingleton<T> {
        public static T Instance { get; private set; }

        protected virtual void Awake() {
            if (Instance == null) {
                Instance = this as T;
            }
        }

        protected virtual void OnDestroy() {
            if (ReferenceEquals(Instance, this)) {
                Instance = null;
            }
        }
    }
}