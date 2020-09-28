using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireScript : MonoBehaviour
{
    public Button startButton;
   
    public AudioSource fire;

    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }
    void TaskOnClick()
    {
        AudioSource audioSource = fire.GetComponent<AudioSource>();
        audioSource.PlayScheduled(3);
    }

}

