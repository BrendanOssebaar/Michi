using System.Collections.Generic;
using UnityEngine;

public class RoomObjectPool<T> where T: MonoBehaviour
{
    private Queue<T> _pool = new Queue<T>();
    private T _prefab;
    private Transform _parent;
    public RoomObjectPool (T prefab, int initialSize, Transform parent = null)
    {
        this._prefab = prefab;
        this._parent = parent;

        for (int i = 0; i < initialSize; i++)
        {
            AddToPool();
        }
    }
    private void AddToPool()
    {
        T obj = Object.Instantiate(_prefab, _parent);
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
    public T Get()
    {
        if (_pool.Count == 0)
        {
            AddToPool();
        }

        T obj = _pool.Dequeue();
        obj.gameObject.SetActive(true);
        return obj;
    }

    public void ReturnToPool(T obj)
    {
        obj.gameObject.SetActive(false);
        _pool.Enqueue(obj);
    }
}

