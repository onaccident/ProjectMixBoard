using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepTrigger : MonoBehaviour
{
    void Footstep()
    {
    AudioManager.instance.Play("Footsteps");
        }
}
