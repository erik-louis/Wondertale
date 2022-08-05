﻿using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

    bool isDone = false;


    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mix;
        }
    }

    void Start()
    {
            Play("mainmenuV1");
    }

    

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }

        s.source.Play();

        // simply add the following code in any script: FindObjectOfType<AudioManager>().Play("AudioFileName");
    }


    public void StopPlaying(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound " + name + " not found!");
            return;
        }

        s.source.Stop();

        // simply add the following code in any script: FindObjectOfType<AudioManager>().StopPlaying("AudioFileName");
    }

    


}
