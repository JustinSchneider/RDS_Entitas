using System.Collections.Generic;
using UnityEngine;

namespace Sources.ObjectPool
{
    public class ObjectPool<T>: MonoBehaviour where T : MonoBehaviour
    {
        [SerializeField] private T prefab;
        [SerializeField] private int size;

        private List<T> _freeList;
        private List<T> _usedList;

        protected virtual void Awake()
        {
            _freeList = new List<T>(size);
            _usedList = new List<T>(size);

            CreateObjectPool();
        }

        private void CreateObjectPool()
        {
            for (int i = 0; i < size; i++)
            {
                var pooledObject = Instantiate(prefab, transform);
                pooledObject.gameObject.SetActive(false);
                _freeList.Add(pooledObject);
            }
        }

        public T Get()
        {
            var numFree = _freeList.Count;
            if (numFree == 0)
                return null;

            var pooledObject = _freeList[numFree - 1];
            _freeList.RemoveAt(numFree - 1);
            _usedList.Add(pooledObject);
            return pooledObject;
        }

        public void ReturnObject(T pooledObject)
        {
            if(!_usedList.Contains(pooledObject))
                Debug.LogError("The object you are trying to return does not belong to this pool.");

            _usedList.Remove(pooledObject);
            _freeList.Add(pooledObject);

            var pooledObjectTransform = pooledObject.transform;
            pooledObjectTransform.SetParent(transform);
            pooledObjectTransform.localPosition = Vector3.zero;
            pooledObject.gameObject.SetActive(false);
        }
    }
}