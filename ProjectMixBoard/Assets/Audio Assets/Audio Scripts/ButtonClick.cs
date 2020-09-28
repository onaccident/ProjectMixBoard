﻿ using UnityEngine;
using UnityEngine.Audio;
 using UnityEngine.UI;
 using System.Collections;
 
 public class ButtonClick : MonoBehaviour
 {
    
     public Button yourButton;
    private void OnEnable()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    private void OnDisable()
    {
        yourButton.onClick.RemoveListener(TaskOnClick);
    }
 

void TaskOnClick()
{
        
        Debug.Log("You have clicked the button!");
     
        AudioManager.instance.Play("Music");
        AudioManager.instance.Play("gustOccurance");

    }
}





//FindObjectsOfType<AudioManager>.Play("PlayerDeath");
//AudioManager.FindObjectOfType<AudioManager>().Play("PlayerDeath");
//AudioManager.instance.Play("PlayerDeath");