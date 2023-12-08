using System.Collections.Generic;
using UnityEngine;

public class ObjectPool<T>
    where T : MonoBehaviour
{
    private T prefab;
    private Transform parent;
    private List<T> pool;

    public ObjectPool(T prefab, Transform parent = null, int prewarmSize = 0)
    {
        this.prefab = prefab;
        this.parent = parent;

        pool = new List<T>(prewarmSize);

        for (int i = 0; i < prewarmSize; i++)
        {
            CreateInstance();
        }
    }

    public T GetObject()
    {
        foreach (var obj in pool)
        {
            if (!obj.gameObject.activeSelf)
            {
                obj.gameObject.SetActive(true);
                return obj;
            }
        }

        var instance = CreateInstance();
        instance.gameObject.SetActive(true);
        return instance;
    }

    private T CreateInstance()
    {
        var instance = GameObject.Instantiate(prefab, parent);
        instance.gameObject.SetActive(false);
        pool.Add(instance);
        return instance;
    }
}
