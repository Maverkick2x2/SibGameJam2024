using System;
using System.Collections.Generic;
using UnityEngine;

public class PoolMono<T> where T : MonoBehaviour
{
    public T Prefab { get; }
    public bool AutoExpand { get; set; }

    public Transform Container { get; }

    private List<T> _pool;

    public PoolMono(T prefab, int count)
    {
        Prefab = prefab;
        Container = null;

        CreatePool(count);
    }

    public PoolMono(T prefab, int count, Transform container)
    {
        Prefab = prefab;
        Container = container;

        CreatePool(count);
    }

    private void CreatePool(int count)
    {
        _pool = new List<T>();

        for (int i = 0; i < count; i++)
        {
            CreateObject();
        }
    }

    private T CreateObject(bool isActiveByDefault = false)
    {
        var createdObject = UnityEngine.Object.Instantiate(Prefab, Container);
        createdObject.gameObject.SetActive(isActiveByDefault);
        _pool.Add(createdObject);
        return createdObject;
    }

    public bool HasFreeElement(out T element)
    {
        foreach (var item in _pool)
        {
            if (!item.gameObject.activeInHierarchy)
            {
                element = item;
                item.gameObject.SetActive(true);
                return true;
            }
        }

        element = null;
        return false;
    }

    public T GetFreeElement()
    {
        if (HasFreeElement(out var element))
        {
            return element;
        }

        if (AutoExpand)
        {
            return CreateObject(true);
        }

        throw new Exception($"There is no free element in pool of type {typeof(T)}");
    }
}
