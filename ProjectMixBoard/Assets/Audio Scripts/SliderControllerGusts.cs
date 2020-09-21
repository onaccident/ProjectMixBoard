using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderControllerGusts : MonoBehaviour
{
    [SerializeField] private float delayTime;
    [SerializeField] private Slider gustOccurance;
    public Button yourButton;
    void OnEnable()
    {
        gustOccurance.onValueChanged.AddListener(delegate { OnSliderWasChanged(); });
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void OnDisable()
    {
        gustOccurance.onValueChanged.RemoveListener(delegate { OnSliderWasChanged(); });
        yourButton.onClick.RemoveListener(TaskOnClick);
    }


    void TaskOnClick()
    {

        Debug.Log("You have started the scene!");
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
        AudioManager.instance.Play("gustOccurance"); //It fires a sound from the core audio manager
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
        delayTime = gustOccurance.value;
    }
}









