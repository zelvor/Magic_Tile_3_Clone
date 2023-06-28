using System.Collections.Generic;
using UnityEngine;

public abstract class ObjectPool<T> : MonoBehaviour where T : Component
{
    [SerializeField] private T prefab;

    public static ObjectPool<T> Instance { get; private set; }
    private Queue<T> _objects = new Queue<T>();

    private void Awake()
    {
        Instance = this;
    }

    public void Add()
    {
        T newObject = GameObject.Instantiate(prefab, transform);
        Return(newObject);
    }

    public T Get()
    {
        if (_objects.Count == 0) Add();
        return _objects.Dequeue();
    }

    public virtual void Return(T obj)
    {
        obj.gameObject.SetActive(false);
        _objects.Enqueue(obj);
    }
}
