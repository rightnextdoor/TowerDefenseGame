using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;

    public static AudioManager instance;

    void Awake()
    {
       

        if (instance == null)
        {
            instance = this;
            SceneManager.sceneLoaded += OnSceneLoaded;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.output;
        }

    }

    public void Play(string name) {

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) {
            Debug.LogWarning("Sounds: " + name + " not found");
            return;
        }
            
        s.source.Play();
    }

    public void StopMusic() {
        foreach (Sound s in sounds)
            s.source.Stop();

    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.buildIndex == 0)
        {
            StopMusic();
            Play("MenuTheme");
            Debug.Log("play menu theme");
        }
        else if (scene.buildIndex == 2)
        {
            StopMusic();
            Play("Level01Theme");
            
            Debug.Log("Play level 01");
        }

        //switch (scene.buildIndex)
        //{
        //    case 0:
        //        Debug.Log("play menu theme");
        //        audioManager.Play("MenuTheme");
        //        break;
        //    case 2:
        //        Debug.Log("Play level 01");
        //        audioManager.Play("Level01Theme");
        //        break;
        //    default:
        //        Debug.Log("continue playing current music");

        //        break;
        //}

    }
}
