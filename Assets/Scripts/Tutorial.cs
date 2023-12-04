using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{
    public Text text;
    public Animator transition;
    public GameObject Slime1;
    public GameObject Slime2;
    public GameObject Adventurer;
    public GameObject Button;
    public GameObject Button2;
    public GameObject Button3;
    public GameObject Exit;
    public GameObject Slime1Collision2;
    public GameObject Arrow;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PlayTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlayTutorial()
    {
        
        text.text = "You are the Slimes";
        Slime1.GetComponent<SpriteRenderer>().enabled = true;
        Slime2.GetComponent<SpriteRenderer>().enabled = true;

        yield return new WaitForSeconds(2f);
        Slime1.GetComponent<SpriteRenderer>().enabled = false;
        Slime2.GetComponent<SpriteRenderer>().enabled = false;
        Adventurer.GetComponent<SpriteRenderer>().enabled = true;
        text.text = "You must prevent the adventurer\nfrom escaping with your treasure!";

        yield return new WaitForSeconds(4f);
        Button.GetComponent<SpriteRenderer>().enabled = true;
        Button2.GetComponent<SpriteRenderer>().enabled = true;
        Button3.GetComponent<SpriteRenderer>().enabled = true;
        Exit.GetComponent<SpriteRenderer>().enabled = true;
        Arrow.GetComponent<SpriteRenderer>().enabled = true;
        Arrow.GetComponentInChildren<SpriteRenderer>().enabled = true;
        
        text.text = "The Adventurer has to press 3\nof the 4 buttons in your lair to get out";

        yield return new WaitForSeconds(6f);
        Exit.GetComponent<SpriteRenderer>().enabled = false;
        Arrow.GetComponent<SpriteRenderer>().enabled = false;
        Arrow.GetComponentInChildren<SpriteRenderer>().enabled = false;
        Button.GetComponent<SpriteRenderer>().enabled = false;
        Button2.GetComponent<SpriteRenderer>().enabled = false;
        Button3.GetComponent<SpriteRenderer>().enabled = false;
        Slime1Collision2.GetComponent<SpriteRenderer>().enabled = true;
        text.text = "Make contact with the Adventurer to imapir them!";

        yield return new WaitForSeconds(7.5f);
        Slime1Collision2.GetComponent<SpriteRenderer>().enabled = false;
        Adventurer.GetComponent <SpriteRenderer>().enabled = false;
        text.text = "Good Luck!";

        yield return new WaitForSeconds(2.5f);

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1.5f);

        SceneManager.LoadScene("MainGame");
    }
}
