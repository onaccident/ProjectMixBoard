using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;



public class NewAudioManager : MonoBehaviour
{
    public NewSoundContainer[] soundContainers;
    internal static NewAudioManager instance;
    public GameObject Poi;
    public Transform player;
    public AudioMixerSnapshot nonPOI;
    public AudioMixerSnapshot poiGaze;

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

        //so normally you can put a foreach loop here to define the audioPresets, however since we are simple taking the presets and playing 
        //"prehooked" sounds that is unnecessary
        //SetUpAudioSources("FlowerMoan");
        
         SetUpAudioSources("RedSquare");
         SetUpAudioSources("PurpleSquare");

        //play


    }
    

    /*void Play(string name)
    {        
        SoundContainer preset = Array.Find(soundContainers, soundContainers => soundContainers.name == name);//go find an "audioPreset" defined by a specific name that matches the name you are seeking
        int j = Random.Range(0, preset.sources.Length);//this audioPreset will have an array of sources from zero to specified length     
        AudioSource sources = preset.sources[j];//the sources here is meant to draw out the variable to be used in sources.clip
        //the way you break out arrays is through the below pattern, int z.....soundclips[z]
        int z = Random.Range(0, preset.soundclips.Length);//this specifies that soundclip (in the soundcontainer class) will be randomized
        AudioClip clips = preset.soundclips[z];//clips is drawing out the variable for sources.clip = clip
        sources.clip = clips;//the .clip is now hooked. so, a preset set of sources (defined in SoundContainer) will be connected to a random set of soundclips[] (random being defined above
        sources.Play();//the audio manager will now play them
        sources.outputAudioMixerGroup = preset.group;
        Debug.Log("Last sound played: " + clips.name); //and will now specify it in the console cause thats dope

    }
   


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
           Play("FlowerMoan");
            Debug.Log("ButtonPressed")
        }

    }*/


   /* public void AttentionGrab()
    {
        if (//PlayerCharacter.GazeAlignment(Poi.transform))
            nonPOI.TransitionTo(2.0f);
        else
            poiGaze.TransitionTo(2.0f);
    }
        */


    private void SetUpAudioSources(string name)
    {
        for (int i = 0; i < soundContainers.Length; i++) //iterating through the types of object, birds trees, flower
        {
            for (int n = 0; n < soundContainers[i].sources.Length; n++)//iterating through the length of the array, audio sources array
            {
                int z = Random.Range(0, soundContainers[i].soundclips.Length);//choosing from the random index of soundclips, we need the i because the i defines the type of sounds(flower, trees, grass
                soundContainers[i].sources[n].clip = soundContainers[i].soundclips[z];//connection nested array
                NewSoundContainer preset = Array.Find(soundContainers, soundContainers => soundContainers.name == name);
                AudioSource sources = preset.sources[n];
                sources.Play();
                sources.outputAudioMixerGroup = preset.group;
                sources.playOnAwake = preset.playOnAwake;
                sources.loop = preset.loop;
                Debug.Log("Last sound played: " + soundContainers[i].soundclips[z].name); //and will now specify it in the console cause thats dope
            }
        }
    }
    
}





