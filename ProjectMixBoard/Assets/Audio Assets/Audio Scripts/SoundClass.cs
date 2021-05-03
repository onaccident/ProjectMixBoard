using UnityEngine.Audio;
using UnityEngine;
 

[System.Serializable]
public class RandomContainer

{
    public string name;
    public AudioClip[] clip;
    [Range(0f, 1f)]
    public float volume = 1;
    [Range(.7f, 1.5f)]
    public float pitch = 1;
    public bool playOnAwake;
    public bool loop;
    public AudioMixerGroup group;
    [HideInInspector]
    public UnityEngine.AudioSource source;
 }
