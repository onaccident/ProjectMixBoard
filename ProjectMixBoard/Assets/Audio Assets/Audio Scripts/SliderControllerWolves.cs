using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderControllerWolves : MonoBehaviour
{
    [SerializeField] private float delayTime;
    [SerializeField] private Slider howlOccurance;
    public Button yourButton;
    void OnEnable()
    {
        howlOccurance.onValueChanged.AddListener(delegate { OnSliderWasChanged(); });
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void OnDisable()
    {
        howlOccurance.onValueChanged.RemoveListener(delegate { OnSliderWasChanged(); });
        yourButton.onClick.RemoveListener(TaskOnClick);
    }


    void TaskOnClick()
    {
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
        AudioManager.instance.Play("howlOccurance"); //It fires a sound from the core audio manager
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
        delayTime = howlOccurance.value;
    }
}










