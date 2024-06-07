using System.Collections.Generic;
using UnityEngine;

namespace Movement
{
    public class PoolManager<T> : SerializedMonoBehaviourSingleton<PoolManager<T>> where T : Component
    {
        protected readonly Queue<T> inactiveObjects = new Queue<T>();
    
        public virtual T Get()
        {
            return null;
        }
    
        public virtual T Get(Transform parent)
        {
            var component = Get();
            if (component is null) return null;
        
            component.transform.SetParent(parent);
            return component;
        }
    
        public virtual T Get(T prefab, Transform parent)
        {
            T spawnableObj = inactiveObjects.Count == 0 ? Instantiate(prefab, parent) : inactiveObjects.Dequeue();
            spawnableObj.gameObject.SetActive(true);
            spawnableObj.transform.SetParent(parent);
            return spawnableObj;
        }

        public virtual void Release(T obj)
        {
            obj.transform.SetParent(transform);
            obj.gameObject.SetActive(false);
            inactiveObjects.Enqueue(obj);
        }
    }
}