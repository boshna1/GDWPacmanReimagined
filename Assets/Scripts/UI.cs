using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject LoseScreen;
    public Slider slider;
    float value = -1f;
    bool enableScreen;
    public GameObject BackgroundTheme;
    GameObject tempBackgroundTheme;

    // Start is called before the first frame update
    void Start()
    {
        slider.GetComponent<Slider>().enabled = false;
        tempBackgroundTheme = Instantiate(BackgroundTheme);
    }

    // Update is called once per frame
    void Update()
    {
        if (enableScreen) 
        {
            tempBackgroundTheme.GetComponent<AudioSource>().enabled = false;
            value += 0.005f;
            slider.GetComponent<Slider>().value = value;
        }
        
}

    public void enableLoseScreen()
    {
        enableScreen = true;
        LoseScreen.GetComponent<Image>().enabled = true;
        slider.GetComponent<Slider>().value = value;
        slider.GetComponent<Slider>().enabled = true;
    }

    public void enableWinScreen()
    {
        enableScreen = true;
        LoseScreen.GetComponent<Image>().enabled = true;
        slider.GetComponent<Slider>().value = value;
        slider.GetComponent <Slider>().enabled = true;
    }

    public void ResetGame()
    {
        enableScreen = false;
        value = -1f;
        LoseScreen.GetComponent<Image>().enabled = false;
        slider.GetComponent<Slider>().value = -1f;
        slider.GetComponent<Slider>().enabled = false;
        tempBackgroundTheme.GetComponent<AudioSource>().enabled = true;
    }
        
}
