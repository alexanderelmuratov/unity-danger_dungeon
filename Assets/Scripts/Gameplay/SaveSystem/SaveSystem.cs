using System;
using UnityEngine;

public interface ISaveSystem
{
    void Save(string key, object saveObject);
    object Load(string key, Type type);
    T Load<T>(string key);
}

public class SaveSystem : ISaveSystem
{
    public void Save(string key, object saveObject)
    {
        string json = JsonUtility.ToJson(saveObject);
        PlayerPrefs.SetString(key, json);
    }

    public object Load(string key, Type type)
    {
        string json = PlayerPrefs.GetString(key, "");

        if (string.IsNullOrEmpty(json))
            return default;

        object loadObject = JsonUtility.FromJson(json, type);
        return loadObject;
    }

    public T Load<T>(string key)
    {
        string json = PlayerPrefs.GetString(key, "");

        if (string.IsNullOrEmpty(json))
            return default;

        T loadT = JsonUtility.FromJson<T>(json);
        return loadT;
    }

}
