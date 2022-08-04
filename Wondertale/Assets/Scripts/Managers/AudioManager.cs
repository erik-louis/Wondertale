using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager instance;

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
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Play("mainmenuV1");
        }

    }

    private void Update()
    {
        // Intro Black Cutscene: Stop MainMenuMusic and Play Hospital Music
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            StopPlaying("mainmenuV1");
            Play("Hospital");
        }

        // Zuzu Awakening Cutscene: Stop Hospital Music and Play Awakening/Welcome Music
        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            StopPlaying(sounds[1].clip.name);
            Play(sounds[2].clip.name);
        }

        // Corridor Level: Stop Awakening/Welcome Music and Play MainMenu Music
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            StopPlaying(sounds[2].clip.name);
            Play(sounds[0].clip.name);
        }

        // Tent Level: Stop MainMenu Music and Play Inside Tent Music
        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            StopPlaying(sounds[0].clip.name);
            Play(sounds[3].clip.name);
        }
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
