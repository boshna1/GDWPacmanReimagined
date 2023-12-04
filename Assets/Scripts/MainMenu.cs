using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    public Animator PlayButton;
    public Animator ExitButton;
    public Animator ControlsButton;
    public Animator Title;

    public float Transitiontime = 1.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) 
        {
            LoadControlScreen();
        }
    }

    public void LoadControlScreen()
    {
        StartCoroutine(LoadControls());
    }

    public void LoadTutorial()
    {
        StartCoroutine(LoadTutorialScreen());
    }


    IEnumerator LoadControls()
    {
        yield return new WaitForSeconds(0.25f);
        Title.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        PlayButton.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        ExitButton.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        ControlsButton.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(Transitiontime);

        SceneManager.LoadScene("Controls");
    }
    IEnumerator LoadTutorialScreen()
    {
        yield return new WaitForSeconds(0.25f);
        Title.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        PlayButton.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        ExitButton.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        ControlsButton.SetTrigger("Start");
        yield return new WaitForSeconds(0.5f);
        transition.SetTrigger("Start");


        yield return new WaitForSeconds(Transitiontime);

        SceneManager.LoadScene("Tutorial");
    }
}
