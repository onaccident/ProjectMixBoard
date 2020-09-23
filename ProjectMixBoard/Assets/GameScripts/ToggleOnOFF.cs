using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleOnOFF : MonoBehaviour
{
    public GameObject walkRosa, walkTuck, walkGorn, walkSylric, sittingBodies, sittingHead;
    // Start is called before the first frame update
    void Start()
    {
        walkGorn.SetActive(false);
        walkRosa.SetActive(false);
        walkSylric.SetActive(false);
        walkTuck.SetActive(false);
        sittingBodies.SetActive(true);
        sittingHead.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            walkTuck.SetActive(true);
            walkGorn.SetActive(true);
            walkRosa.SetActive(true);
            walkSylric.SetActive(true);
            sittingHead.SetActive(false);
            sittingBodies.SetActive(false);
        }
        if (Input.GetKey(KeyCode.Q))
        {
            walkTuck.SetActive(false);
            walkGorn.SetActive(false);
            walkRosa.SetActive(false);
            walkSylric.SetActive(false);
            sittingBodies.SetActive(true);
            sittingHead.SetActive(false);
        }
    }
}
