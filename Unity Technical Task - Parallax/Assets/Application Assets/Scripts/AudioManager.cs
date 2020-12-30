using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundData
{
    public string name;
    public AudioClip clip;
    public float volume;
}

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Music"), SerializeField]
    AudioSource musicPlayer;

    [Header("Sound"), SerializeField]
    AudioSource soundPlayer;

    [SerializeField]
    List<SoundData> sounds;

    Dictionary<string, SoundData> clipsDict = new Dictionary<string, SoundData>();
    Coroutine resumeMusic;

    private void Awake()
    {
        instance = this;

        foreach (SoundData data in sounds)
        {
            clipsDict[data.name] = data;
        }
    }

    public void ResumeMusic()
    {
        soundPlayer.Stop();
        if (resumeMusic != null)
            StopCoroutine(resumeMusic);
        musicPlayer.mute = false;
    }

    public void PlayAudio(string name, bool stopMusic = false)
    {
        soundPlayer.clip = clipsDict[name].clip;
        soundPlayer.volume = clipsDict[name].volume;
        soundPlayer.Play();

        if (stopMusic)
        {
            musicPlayer.mute = true;
            if (resumeMusic != null)
                StopCoroutine(resumeMusic);
            resumeMusic = StartCoroutine(ResumeMusicEnumerator());
        }
    }

    IEnumerator ResumeMusicEnumerator()
    {
        yield return new WaitWhile(()=>soundPlayer.isPlaying);
        musicPlayer.mute = false;
    }
}
