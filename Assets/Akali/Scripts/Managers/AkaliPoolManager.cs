using System.Collections.Generic;
using System.Linq;
using Akali.Common;
using Akali.Scripts.Core;
using Akali.Scripts.ScriptableObjects;
using UnityEngine;

namespace Akali.Scripts.Managers
{
    public class AkaliPoolManager : Singleton<AkaliPoolManager>
    {
        [SerializeField] private PoolListScriptableObject pools;
        public List<Queue<GameObject>> queues = new List<Queue<GameObject>>();
        private PoolScriptableObject GetPool<T>() => pools.list.Find(o => o.poolPrefab.GetComponent<T>() != null);
        private List<PoolScriptableObject> GetPoolList<T>() => pools.list.Where(o => o.poolPrefab.GetComponent<T>() != null).ToList();
        private Queue<GameObject> GetQueue<T>() => queues.Find(queue => queue.Any(o => o.GetComponent<T>() != null));
        public GameObject Dequeue<T>() => GetPool<T>().Dequeue(GetQueue<T>());
        public void Enqueue<T>(GameObject obj) => GetPool<T>().Enqueue(obj, GetQueue<T>(), gameObject.transform);

        private void Awake()
        {
            for (var i = 0; i < pools.list.Count; i++)
            {
                queues.Add(new Queue<GameObject>());
                pools.list[i].CreatePool(queues[i], gameObject.transform);
            }
        }
        
        public GameObject DequeueRandomLevel()
        {
            var randomLevelPool = GetPoolList<MovementController>();
            var randomLevel = Random.Range(0, randomLevelPool.Count);
            var x = randomLevelPool[randomLevel];
            var prefLevel = pools.list.Where(i => i.poolPrefab.name == x.poolPrefab.name).First();
            prefLevel.poolPrefab.SetActive(true);
            return prefLevel.poolPrefab;
        }
    }
}