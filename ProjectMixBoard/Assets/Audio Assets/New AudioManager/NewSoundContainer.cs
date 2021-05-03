using UnityEngine.Audio;
//using this because the namespace above deals with Audio specific functionality
using System.Collections;
using UnityEngine;





//This means that the class Sound is an accessable array. Unity just needs this little tag to make everything below
// storable in a nifty field. 

[System.Serializable]
public class NewSoundContainer

//This is stating Sound is now a class that can be grabbed -> "call a play meathod" ultimately by our audio manager.
//It also does NOT derive from MonoBehavoiur as this script lives outside of the scene. It is being accessed in the scene;
//it is not doing the accessing. Think of it as a passive script.

{
    public string name;
    //each sound will hold an audioclip array
    [Range(0f, 1f)]
    public float volume;
    //each sound will have a volume, and the "range" function here indicates that volume can be adjusted on a slider.

    [Range(.7f, 1.5f)]
    public float pitch;
    public bool playOnAwake;
    //a bool creates a checkmark box so that the sound can play on awake or not per a normal unity soundsource. 
    //What I haven't figured out is why this doesn't seem to work the same way as instantiating a standard audiosource. 
    //Something is missing where "it's not triggered" until I call it manually. Need some study.

    public bool loop;
    public AudioMixerGroup group;
    //this allows you to dictate the audiomixer routing which will be helpful for AudioSnapshotSwitcher scripts in future endeavors


    public AudioSource[] sources;
    public UnityEngine.AudioClip[] soundclips;


    // Start is called before the first frame update



        //This is ultimately the "hook" between the audio manager and the soundclass. What we are doing is causing the audiosource
        //to be stored as a VARIABLE. When it's stored as a variable, it can be accessed by a Play Method (named PlaySoundFX) 
        //on the audiosource. 
    }




