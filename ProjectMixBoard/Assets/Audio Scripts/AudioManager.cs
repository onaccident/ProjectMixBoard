﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;



public class AudioManager : MonoBehaviour
{
    public RandomContainer[] sounds;
    internal static AudioManager instance;
    public bool isGated = true;
    public bool isPlaying;
   

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
        foreach (RandomContainer c in sounds)
        {
            c.source = gameObject.AddComponent<AudioSource>();
            c.source.pitch = c.pitch;
            c.source.loop = c.loop;
            c.source.playOnAwake = c.playOnAwake;
            c.source.outputAudioMixerGroup = c.group;
        }

    }
    public void Play(string name)
    {
        RandomContainer soundContainer = Array.Find(sounds, sound => sound.name == name);
        var i = Random.Range(0, soundContainer.clip.Length);
        if (soundContainer.source.isPlaying == true && isGated == true)
        {
            Debug.Log("container" + soundContainer.clip[i].name + "is playing");
            soundContainer.source.clip = soundContainer.clip[i];
            soundContainer.source.PlayOneShot(soundContainer.source.clip );
            return;
        }
        soundContainer.source.clip = soundContainer.clip[i];
        soundContainer.source.Play();
        Debug.Log("Last sound played: " + soundContainer.clip[i].name);
    }
}


