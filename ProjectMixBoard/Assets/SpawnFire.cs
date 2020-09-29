using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Audio;
using Random = UnityEngine.Random;
using System.Numerics;
using JetBrains.Annotations;

public class SpawnFire : MonoBehaviour
{
   
    public AudioSource aSource;
    public Transform target;
    public Transform Sylrictarget;
    private float distanceBetween;
    public AudioLowPassFilter AudioLowPassFilter;
    public float minPass = 500;
    public float maxPass = 22000;
    

    //private AudioSource sourcee;
    // Start is called before the first frame update
    void Start()
    {
        //AudioSource audio = gameObject.AddComponent<AudioSource>();
        AudioLowPassFilter.cutoffFrequency = minPass;
      
        //gameObject.AddComponent<AudioLowPassFilter>();
    }

    // Update is called once per frame
    void Update()
    {
        distanceBetween = UnityEngine.Vector3.Distance(target.transform.position, Sylrictarget.transform.position)/10;
       
        AudioLowPassFilter.cutoffFrequency = Mathf.Lerp(maxPass, minPass, distanceBetween);
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        aSource.Play();
    }
}
