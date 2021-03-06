﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Experimental.U2D;
using UnityEngine.UI;

public class SpriteFadeIn : MonoBehaviour
{
    public float duration = 5f;
    public SpriteRenderer sprite;
    public Button startButton;
    public Button moveButton;
    public Button combatButton;
    public AudioMixerSnapshot Fog;
    public AudioMixerSnapshot NoFog;



    void Start()
    {
        Button sbtn = startButton.GetComponent<Button>();
        Button mbtn = moveButton.GetComponent<Button>();
        Button cbtn = combatButton.GetComponent<Button>();
        sbtn.onClick.AddListener(FadeFog);
        mbtn.onClick.AddListener(FadeFogIn);
    }
   void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            FadeFog();
        }
    }
    void FadeFog()
    {
        NoFog.TransitionTo(5f);
        StartCoroutine(FogFader(0f, duration));
        
        IEnumerator FogFader(float aValue, float aTime)
        {
            float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
            {

                Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
                transform.GetComponent<SpriteRenderer>().material.color = newColor;
                yield return null;
            }
        }
    }


    void FadeFogIn()
    {
        Fog.TransitionTo(5f);
        StartCoroutine(FogFader(1f, duration));
        
        IEnumerator FogFader(float aValue, float aTime)
        {
            float alpha = transform.GetComponent<SpriteRenderer>().material.color.a;
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
            {
                Color newColor = new Color(1, 1, 1, Mathf.Lerp(alpha, aValue, t));
                transform.GetComponent<SpriteRenderer>().material.color = newColor;
                yield return null;
            }

        }
    }
    



}

