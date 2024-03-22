using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public SoundData[] sfxSounds, musicSounds;
    public AudioSource sfxSource, musicSource;

    public float sfxMasterVolume;
    public float musicMasterVolume;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(string name)
    {
        SoundData s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            CustomDebug.Instance.Log("Error: Sound " + name + " Not Found", this.ToString(), 16, CustomDebug.Instance.ErrorColor, 24);
        }
        else
        {
            float soundNormalized = s.volume / 100;
            float masterNormalized = musicMasterVolume / 100;

            float finalVolume = soundNormalized * masterNormalized;
            musicSource.volume = finalVolume;
            musicSource.pitch = s.pitch;
            musicSource.Play();

        }
    }

    public void PlaySFX(string name)
    {
        SoundData s = Array.Find(sfxSounds, x => x.name == name);
        if(s == null)
        {
            CustomDebug.Instance.Log("Error: Sound " + name + " Not Found", this.ToString(), 16, CustomDebug.Instance.ErrorColor, 24);
        }
        else
        {
            float soundNormalized = s.volume / 100;
            float masterNormalized = sfxMasterVolume / 100;

            float finalVolume = soundNormalized * masterNormalized;
            sfxSource.volume = finalVolume;
            sfxSource.pitch = s.pitch;
            sfxSource.PlayOneShot(s.clip);

        }
    }
}
