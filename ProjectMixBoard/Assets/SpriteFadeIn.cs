using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Experimental.U2D;
using UnityEngine.UI;

public class SpriteFadeIn : MonoBehaviour
{
    public float duration = 5f;
    public SpriteRenderer sprite;

    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            StartCoroutine(FogFader(0f, duration));
        }

        
        if (Input.GetKeyDown(KeyCode.F))
        {
            StartCoroutine(FogFader(1f, duration));
        }
        

        IEnumerator FogFader(float aValue, float aTime)
        {
            Debug.Log("coroutine started");
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

