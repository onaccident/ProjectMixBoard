using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footing : MonoBehaviour
{
    public List<GroundType> GroundTypes = new List<GroundType>();
    public GameObject Sprite;
    public string currentground;
    // Start is called before the first frame update
    void Start()
    {
        setGroundType(GroundTypes[0]);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag == "dirtFloor")
            setGroundType(GroundTypes[1]);
        else setGroundType(GroundTypes[0]);
        }
     
    public void setGroundType(GroundType ground)
    {
        if (currentground != ground.name)
        {
            currentground = ground.name;

        }
    } 
    [System.Serializable]
    public class GroundType
    {
        public string name;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        currentground = "mudFloor";
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        currentground = "dirtFloor";
    }
    void Footsteps()
    {
        if (currentground == "dirtFloor")
            AudioManager.instance.Play("dirtFootsteps");
        if (currentground == "mudFloor")
            AudioManager.instance.Play("mudFootsteps");
        else return;
    }
}

