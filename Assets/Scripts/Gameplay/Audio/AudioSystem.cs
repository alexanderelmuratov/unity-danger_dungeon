using System;

public interface IAudioSystem
{
    float SFXVolume { get; set; }
    float MusicVolume { get; set; }

    event Action<float> SFXVolumeChangedEvent;
    event Action<float> MusicVolumeChangedEvent;
    event Action<AudioSettings> OnSFXEvent;
    event Action<AudioSettings> OnMusicEvent;

    void PlaySFX(string key);
    void PlaySFX(AudioSettings settings);
    void PlayMusic(string key);
    void PlayMusic(AudioSettings settings);
}

public class AudioSystem : IAudioSystem
{
    public float SFXVolume { get; set; }
    public float MusicVolume { get; set; }

    public event Action<float> SFXVolumeChangedEvent;
    public event Action<float> MusicVolumeChangedEvent;
    public event Action<AudioSettings> OnSFXEvent;
    public event Action<AudioSettings> OnMusicEvent;

    public void PlaySFX(string key)
    {
        PlaySFX(new AudioSettings(key));
    }

    public void PlaySFX(AudioSettings settings)
    {
        OnSFXEvent?.Invoke(settings);
    }

    public void PlayMusic(string key)
    {
        PlayMusic(new AudioSettings(key));
    }

    public void PlayMusic(AudioSettings settings)
    {
        OnMusicEvent?.Invoke(settings);
    }
}
