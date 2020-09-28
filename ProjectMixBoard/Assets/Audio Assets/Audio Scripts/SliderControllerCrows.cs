using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderControllerCrows : MonoBehaviour
{
    [SerializeField] private float delayTime; 
    [SerializeField] private Slider cawingOccurance;
    public Button yourButton;
    void OnEnable()
    {
        cawingOccurance.onValueChanged.AddListener(delegate { OnSliderWasChanged(); });
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void OnDisable()
    {
        cawingOccurance.onValueChanged.RemoveListener(delegate { OnSliderWasChanged(); });
        yourButton.onClick.RemoveListener(TaskOnClick);
    }


    void TaskOnClick()
    {

        Debug.Log("You have started the scene!");
        AudioManager.instance.Play("gustOccurance");
        AudioManager.instance.Play("Music");
        OnSliderWasChanged();
        Invoke("PlayBack", delayTime);

    }
    /*public void Start()
    {
        OnSliderWasChanged();
        Invoke("PlayBack", delayTime); 
    }*/
    private void PlayBack()
    {
        AudioManager.instance.Play("cawingOccurance"); //It fires a sound from the core audio manager
        OnSliderWasChanged(); 
        StartCoroutine(AmbiantController());
    }
    IEnumerator AmbiantController() 
    {
        yield return new WaitForSeconds(delayTime);
        PlayBack();
    }
    void OnSliderWasChanged() 
    { 
        delayTime = cawingOccurance.value; 
    }
}








