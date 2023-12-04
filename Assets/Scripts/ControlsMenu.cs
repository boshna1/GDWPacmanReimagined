using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlsMenu : MonoBehaviour
{
    public Animator transition;
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
            StartCoroutine(LoadMainMenuScreen());
        }
    }
    IEnumerator LoadMainMenuScreen()
    {
        transition.SetTrigger("Start");


        yield return new WaitForSeconds(Transitiontime);

        SceneManager.LoadScene("MainMenu");
    }
}
