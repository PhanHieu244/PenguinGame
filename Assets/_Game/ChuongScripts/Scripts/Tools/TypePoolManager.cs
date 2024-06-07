using System;
using System.Collections.Generic;
using Sirenix.Serialization;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Movement
{
    public class TypePoolManager<T, TE> : SerializedMonoBehaviourSingleton<TypePoolManager<T, TE>> where T : Component, IPoolIdentifier<TE>
    {
        [OdinSerialize, NonSerialized] protected Dictionary<TE, T> prefabs;
        protected Dictionary<TE, Queue<T>> inactiveObjectsDictionary;
        private List<TE> availableKey;

        protected override void Awake()
        {
            base.Awake();
            inactiveObjectsDictionary = new Dictionary<TE, Queue<T>>();
            availableKey = new List<TE>();
            foreach (var (key, value) in prefabs)
            {
                value.Identifier = key;
                inactiveObjectsDictionary[key] = new Queue<T>();
                availableKey.Add(key);
            }
        }

        public virtual T Get(Transform parent = null)
        {
            return Get(availableKey[Random.Range(0, availableKey.Count)], parent);
        }

        public virtual T Get(TE key, Transform parent = null)
        {
            if (!inactiveObjectsDictionary.TryGetValue(key, out var inactiveObjects))
            {
                Debug.LogError($"{key} not exist in POOL: {name}");
                return null;
            }
            T spawnableObj = inactiveObjects.Count == 0 ? Instantiate(prefabs[key], parent) : inactiveObjects.Dequeue();
            spawnableObj.gameObject.SetActive(true);
            spawnableObj.transform.SetParent(parent);
            return spawnableObj;
        }

        public virtual void Release(T obj)
        {
            obj.transform.SetParent(transform);
            obj.gameObject.SetActive(false);
            if (!inactiveObjectsDictionary.TryGetValue(obj.Identifier, out var inactiveObjects))
            {
                Destroy(obj.gameObject); 
                Debug.LogWarning($"{obj.Identifier} not exist in POOL: {name}");
                return;
            }
            inactiveObjects.Enqueue(obj);
        }
    }
    
    public interface IPoolIdentifier<T>
    {
        T Identifier { get; internal set; }
    }
}