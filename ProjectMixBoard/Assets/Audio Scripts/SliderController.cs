using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private float delayTime; 
    [SerializeField] private Slider cawingOccurance;
    [SerializeField] private Slider howlOccurance;
    [SerializeField] private Slider gustOccurance;
    public Button yourButton;
    void OnEnable()
    {
        cawingOccurance.onValueChanged.AddListener(delegate { PlayCrows(); });
        howlOccurance.onValueChanged.AddListener(delegate { PlayWolves(); });
        gustOccurance.onValueChanged.AddListener(delegate { PlayGusts(); });
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void OnDisable()
    {
        cawingOccurance.onValueChanged.RemoveListener(delegate { PlayCrows(); });
        howlOccurance.onValueChanged.RemoveListener(delegate { PlayWolves(); });
        gustOccurance.onValueChanged.RemoveListener(delegate { PlayGusts(); });

        yourButton.onClick.RemoveListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have started the scene!");
        AudioManager.instance.Play("Music");
        PlayCrows();
        PlayWolves();
        PlayGusts();
        Invoke("PlayCrows", delayTime);
        Invoke("PlayWolves", delayTime);
        Invoke("PlayGusts", delayTime);
        Invoke("PlayGusts", delayTime);

    }
    /*public void Start()
    {
        OnSliderWasChanged();
        Invoke("PlayBack", delayTime); 
    }*/
    private void PlayCrows()
    {
        AudioManager.instance.Play("cawingOccurance"); //It fires a sound from the core audio manager
        CrowsCawing(); 
        StartCoroutine(AmbiantController());
    }
    private void PlayWolves()
    {
        AudioManager.instance.Play("howlOccurance"); //It fires a sound from the core audio manager
        WolfHowling();
        StartCoroutine(AmbiantController());
    }
    private void PlayGusts()
    {
        AudioManager.instance.Play("gustOccurance"); //It fires a sound from the core audio manager
        GustsGusting();
        StartCoroutine(AmbiantController());
    }
    IEnumerator AmbiantController() 
    {
        yield return new WaitForSeconds(delayTime);
        PlayCrows();
        PlayWolves();
        PlayGusts();

    }
    void CrowsCawing() 
    { 
        delayTime = cawingOccurance.value; 
    }
    void WolfHowling()
    {
        delayTime = howlOccurance.value;
    }
    void GustsGusting()
    {
        delayTime = gustOccurance.value;
    }

}








