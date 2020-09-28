using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOnOFF : MonoBehaviour
{
    public GameObject walkRosa, walkTuck, walkGorn, walkSylric, sittingBodies, sittingHead, fire;
    public Button yourButton;
    
    void Start()
    {
        walkGorn.SetActive(false);
        walkRosa.SetActive(false);
        walkSylric.SetActive(false);
        walkTuck.SetActive(false);
        sittingBodies.SetActive(true);
        sittingHead.SetActive(true);
        fire.SetActive(true);

    }
    private void OnEnable()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    // Update is called once per frame

    void TaskOnClick()
    {
        StartCoroutine(waitToSet());

        IEnumerator waitToSet()
        {
            yield return new WaitForSeconds(4);
            AudioManager.instance.Play("Ploof");
            yield return new WaitForSeconds(1);
            fire.SetActive(false);
            walkTuck.SetActive(true);
            walkGorn.SetActive(true);
            walkRosa.SetActive(true);
            walkSylric.SetActive(true);
            sittingHead.SetActive(false);
            sittingBodies.SetActive(false);
        }
        Debug.Log("The adventurers set off!");
      
    }
}
