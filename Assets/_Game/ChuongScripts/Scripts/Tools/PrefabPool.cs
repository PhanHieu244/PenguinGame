using UnityEngine;

namespace Movement
{
    public class PrefabPool<T> : PoolManager<T> where T : Component
    {
        [SerializeField] private T prefab; 
    
        public override T Get()
        {
            return Get(prefab, null);
        }
    
        public override T Get(Transform parent)
        {
            return Get(prefab, parent);
        }
    }
}