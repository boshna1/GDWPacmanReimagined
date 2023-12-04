
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject LoseScreen;
    public Slider slider;
    public Slider sliderScore;
    float value = -1f;
    bool enableScreen;
    public GameObject BackgroundTheme;
    GameObject tempBackgroundTheme;
    public Text ButtonText;
    int ButtonCount;
    public GameObject[] buttons = new GameObject[3];
    public Sprite buttonsSprite;
    public Sprite buttonsSpriteUnpress;
   

    // Start is called before the first frame update
    void Start()
    {
        slider.GetComponent<Slider>().enabled = false;
        tempBackgroundTheme = Instantiate(BackgroundTheme);
    }

    // Update is called once per frame
    void Update()
    {
        ButtonText.text = "Buttons: " + ButtonCount.ToString() + "/3";
        if (enableScreen) 
        {
            tempBackgroundTheme.GetComponent<AudioSource>().enabled = false;
            value += 0.005f;
            slider.GetComponent<Slider>().value = value;
            if (sliderScore.GetComponent<Slider>().value < 0.681f)
            {
                sliderScore.GetComponent<Slider>().value = value;
            }
        }
        
}

    public void enableLoseScreen()
    {
        enableScreen = true;
        LoseScreen.GetComponent<Image>().enabled = true;
        slider.GetComponent<Slider>().value = value;
        slider.GetComponent<Slider>().enabled = true;
        sliderScore.GetComponent<Slider>().enabled = true;
    }

    public void enableWinScreen()
    {
        enableScreen = true;
        LoseScreen.GetComponent<Image>().enabled = true;
        slider.GetComponent<Slider>().value = value;
        slider.GetComponent <Slider>().enabled = true;
        sliderScore.GetComponent<Slider>().enabled = true;
    }

    public void ResetGame()
    {
        enableScreen = false;
        
        LoseScreen.GetComponent<Image>().enabled = false;
        slider.GetComponent<Slider>().enabled = false;
        sliderScore.GetComponent<Slider>().enabled = false;
        slider.GetComponent<Slider>().value = -1f;
        sliderScore.GetComponent<Slider>().value = 0.286f;   
        tempBackgroundTheme.GetComponent<AudioSource>().enabled = true;
        for (int i = 0; i < 3; i++) 
        {
            buttons[i].GetComponent<SpriteRenderer>().sprite = buttonsSpriteUnpress;
        }
        ButtonCount = 0;
        value = -1f;
    }

    public void addButton()
    {
        buttons[ButtonCount].GetComponent<SpriteRenderer>().sprite = buttonsSprite;
        ButtonCount++;
        
    }
        
}
