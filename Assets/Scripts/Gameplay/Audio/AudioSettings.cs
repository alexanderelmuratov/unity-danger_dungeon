using UnityEngine;

public class AudioSettings
{
    public string key;
    public float volume;
    public float pitch;
    public Vector3 position;

    public AudioSettings(string key, Vector3 position = default, float volume = 1, float pitch = 1)
    {
        this.key = key;
        this.volume = volume;
        this.pitch = pitch;
        this.position = position;
    }
}
