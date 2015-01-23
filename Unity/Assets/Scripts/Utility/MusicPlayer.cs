using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MusicPlayer : Singleton<MusicPlayer>
{

    public enum MusicPlayerMode { Loop, Shuffle };
    public MusicPlayerMode PlayMode;

    public List<AudioClip> TrackList;

    private AudioSource MusicSourceOne;
    private AudioSource MusicSourceTwo;
    private AudioSource ActiveMusicSource;
    private AudioSource InactiveMusicSource
    {
        get
        {
            if (ActiveMusicSource == MusicSourceOne)
            { return MusicSourceTwo; }
            else { return MusicSourceOne; }
        }
    }

    void Start()
    {
        MusicSourceOne = gameObject.AddComponent<AudioSource>();
        MusicSourceTwo = gameObject.AddComponent<AudioSource>();
        PlayMode = MusicPlayerMode.Loop;
        ActiveMusicSource = MusicSourceOne;
        Play(TrackList[0]);
        StartCoroutine(TestCrossFade());
    }

    IEnumerator TestCrossFade()
    {
        yield return new WaitForSeconds(2.0f);
        CrossFade(TrackList[1], 1.0f);
    }

    AudioSource SetupAudioSource()
    {
        AudioSource newAudioSource = gameObject.AddComponent<AudioSource>();
        newAudioSource.loop = true;
        return newAudioSource;
    }

    public void Add(AudioClip clip)
    {
        TrackList.Add(clip);
    }

    public void AddAndPlay(AudioClip clip)
    {
        TrackList.Add(clip);
        ActiveMusicSource.clip = clip;
        ActiveMusicSource.Play();
    }

    public void Play(AudioClip clip)
    {
        ActiveMusicSource.clip = clip;
        ActiveMusicSource.Play();
    }

    public void CrossFade(AudioClip clip, float crossfadeDuration)
    {
        InactiveMusicSource.clip = clip;
        InactiveMusicSource.volume = 0.0f;
        InactiveMusicSource.Play();
        StartCoroutine(CrossFader(crossfadeDuration));
    }

    IEnumerator CrossFader(float crossFadeDuration)
    {
        while(ActiveMusicSource.volume>0.0f)
        {
            ActiveMusicSource.volume -= 0.01f;
            InactiveMusicSource.volume += 0.1f;
            yield return new WaitForSeconds(crossFadeDuration/60.0f);
        }
        ActiveMusicSource = InactiveMusicSource;
    }
}
