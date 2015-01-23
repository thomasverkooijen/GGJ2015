using UnityEngine;
using System.Collections;

public class SoundEffectPlayer : Singleton<SoundEffectPlayer> {

    public void Play(AudioClip clip)
    {
        Play(clip, Vector3.zero, 1.0f, 1.0f, 0.0f);
    }

    public void Play(AudioClip clip, Vector3 sourcePosition)
    {
        Play(clip, sourcePosition, 1.0f, 1.0f, 0.0f);
    }

    public void Play(AudioClip clip, Vector3 sourcePosition, float pitch)
    {
        Play(clip, sourcePosition, pitch, 1.0f, 0.0f);
    }

    public void Play(AudioClip clip, Vector3 sourcePosition, float pitch, float volume)
    {
        Play(clip, sourcePosition, pitch, volume, 0.0f);
    }

	public void Play(AudioClip clip, Vector3 sourcePosition, float pitch, float volume, float delay)
    {
        GameObject newAudioSourceObject = new GameObject("AudioClip_" + clip.name);
        newAudioSourceObject.transform.parent = transform;
        newAudioSourceObject.transform.position = sourcePosition;
        AudioSource newAudioSource = newAudioSourceObject.AddComponent<AudioSource>();
        newAudioSource.pitch = pitch;
        newAudioSource.volume = volume;
        newAudioSource.PlayDelayed(delay);
        Destroy(newAudioSource, clip.length);
    }
}
