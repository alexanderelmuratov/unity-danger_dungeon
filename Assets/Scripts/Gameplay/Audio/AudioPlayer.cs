using System.Collections;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource source;

    public void Set(AudioSettings settings, AudioClip clip)
    {
        source.clip = clip;
        source.volume = settings.volume;
        source.pitch = settings.pitch;
        transform.position = settings.position;
        source.PlayOneShot(source.clip);

        if (!source.loop)
            StartCoroutine(DisableAfterFinish());
    }

    private IEnumerator DisableAfterFinish()
    {
        yield return new WaitForSeconds(source.clip.length);
        gameObject.SetActive(false);
    }

    public void Fade(bool isIn, float duration)
    {
        StartCoroutine(FadeRoutine(isIn, duration));
    }

    private IEnumerator FadeRoutine(bool isIn, float duration)
    {
        var counter = duration;

        while (counter > 0)
        {
            counter -= Time.deltaTime;
            var normalizedVolume = isIn ? 1 - counter / duration : counter / duration;
            source.volume = normalizedVolume;
            yield return null;
        }

        if (!isIn)
            gameObject.SetActive(false);
    }
}
