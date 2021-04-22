using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sounds[] sounds;

    public static AudioManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound file: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void Pause(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound file: " + name + " not found!");
            return;
        }
        s.source.Pause();
    }

    public void Stop(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound file: " + name + " not found!");
            return;
        }
        s.source.Stop();
    }

    public void StopAll()
    {
        foreach (Sounds track in sounds)
        {
            if (track == null)
            {
                Debug.LogWarning("Sound file: " + track.name + " not found!");
                return;
            }
            track.source.Stop();
        }
    }

    public void adjustVolume(float volume)
    {
        foreach (Sounds track in sounds)
        {
            if (track == null)
            {
                Debug.LogWarning("Sound file: " + track.name + " not found!");
                return;
            }
            track.source.volume = volume;
        }
    }
}
