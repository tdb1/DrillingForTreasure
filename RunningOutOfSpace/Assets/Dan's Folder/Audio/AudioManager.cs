﻿using UnityEngine;
using System;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    [HideInInspector] static public bool sfxMute, musicMute;

    public static AudioManager instance;

    // all sounds used in the game go here!
    public Sound[] sounds;

    Sound currentSong;

    public void Awake()
    {

        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }



    // Use this for initialization
    void Start()
    {
        sfxMute = false; //  PlayerPrefsHandler.GetSFXMute();
        musicMute = false; // PlayerPrefsHandler.GetMusicMute();

        //SetMusic("MenuMusic", true);
        //PlayOneShot(menuMusic.clip);
        //print("I should be playing " + menuMusic.clip.name + "!");
    }


    public void StopMusic()
    {
        if (currentSong != null) currentSong.source.Stop();
    }

    /*
    public Sound StartAdLoop(string name)
    {
        if (musicMute) return null;

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Audio " + name + " not found!");
            return null;
        }

        if (currentSong != null) currentSong.source.Stop();
        currentSong = s;
        s.source.loop = true;
        s.source.Play();
        return s;
    }

    public void StopAdLoop(Sound s)
    {
        s.source.Stop();
    }
    */


    public void SetMusic(string name, bool loop)
    {
        if (musicMute) return;

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Audio " + name + " not found!");
            return;
        }

        if (currentSong != null) currentSong.source.Stop();
        currentSong = s;
        s.source.loop = loop;
        s.source.Play();
    }
    

    public void Play(string name)
    {

        if (sfxMute) return;

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Audio " + name + " not found!");
            return;
        }
        s.source.Play();
        print("Play!");

    }

    public void PlayAtPitch(string name, float pitch)
    {
        if (sfxMute) return;

        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Audio " + name + " not found!");
            return;
        }
        s.source.pitch = pitch;
        s.source.Play();


    }
}
