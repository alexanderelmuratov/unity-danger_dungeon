using System.Linq;
using UnityEngine;

public class AudioSystemView : MonoBehaviour
{
    [SerializeField] private AudioPlayer sfxPrefab;
    [SerializeField] private AudioPlayer musicPrefab;

    [SerializeField] private AudioClip[] sfxClips;
    [SerializeField] private AudioClip[] musicClips;

    private ObjectPool<AudioPlayer> sfxPool;
    private ObjectPool<AudioPlayer> musicPool;
    private AudioPlayer currentAudioPlayer;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        sfxPool = new ObjectPool<AudioPlayer>(sfxPrefab, transform);
        musicPool = new ObjectPool<AudioPlayer>(musicPrefab, transform);

        var audioSystem = Context.Instance.AudioSystem;
        audioSystem.OnSFXEvent += OnPlaySFX;
        audioSystem.OnMusicEvent += OnPlayMusic;
    }

    public void OnPlaySFX(AudioSettings settings)
    {
        var clip = sfxClips.FirstOrDefault(sfx => sfx.name == settings.key);

        if (clip == null)
        {
            Debug.Log($"There is no clip with name {settings.key}");
            return;
        }

        var audioPlayer = sfxPool.GetObject();
        audioPlayer.Set(settings, clip);
    }

    public void OnPlayMusic(AudioSettings settings)
    {
        var clip = musicClips.FirstOrDefault(music => music.name == settings.key);

        if (clip == null)
        {
            Debug.Log($"There is no clip with name {settings.key}");
            return;
        }

        currentAudioPlayer?.Fade(false, 1f);
        currentAudioPlayer = musicPool.GetObject();
        currentAudioPlayer.Set(settings, clip);
        currentAudioPlayer.Fade(true, 1f);
    }
}
