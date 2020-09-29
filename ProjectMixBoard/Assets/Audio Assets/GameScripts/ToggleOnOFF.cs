using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleOnOFF : MonoBehaviour
{
    public GameObject walkRosa, walkTuck, walkGorn, walkSylric, sittingBodies, sittingHead, fire, wolf, foreground, sign;
    public Button yourButton;
    public Button combatButton;
    
    void Start()
    {
        walkGorn.SetActive(false);
        walkRosa.SetActive(false);
        walkSylric.SetActive(false);
        walkTuck.SetActive(false);
        sittingBodies.SetActive(true);
        sittingHead.SetActive(true);
        fire.SetActive(true);
        wolf.SetActive(false);
        sign.SetActive(false);
        foreground.SetActive(true);

    }
    private void OnEnable()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        Button cbtn = combatButton.GetComponent<Button>();
        cbtn.onClick.AddListener(CombatBegins);
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
       
      
    }
    void CombatBegins()
    {
        StartCoroutine(waitToSet());
        AudioManager.instance.Play("Combat");
        IEnumerator waitToSet()
        {
            yield return new WaitForSeconds(2);
            wolf.SetActive(true);
            sign.SetActive(true);
            foreground.SetActive(false);
        }        
    }
}

