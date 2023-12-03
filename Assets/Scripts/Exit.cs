using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Exit : MonoBehaviour
{
    bool Loss;
    [SerializeField] private Text text;
    public PlayerMovement playerMovement;
    int buttonPress;
    public Pacman pacman;
    public AudioClip Lose;
    public GameObject floor;
    public UI ui;
    public Score score;
    public GameObject GoalOpenSound;
    public GameObject GameOverSound;
    GameObject tempGameOverSound;
    public GameObject ButtonPressSound;
    bool playsound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (buttonPress >= 3)
        {
            this.transform.GetComponent<SpriteRenderer>().color = Color.yellow;
            this.transform.GetComponent<BoxCollider2D>().isTrigger = true;
            Instantiate(GoalOpenSound);
            pacman.GoalOpen();
        }
        if (Loss)
        {
            Instantiate(Lose);         
            text.text = "Pacman Escaped!";
            playerMovement.All0();
            playerMovement.setGameFalse();
            ui.enableLoseScreen();
            score.setGameFalse();
            Loss = false;
            if (playsound == false) 
            {
                tempGameOverSound = Instantiate(GameOverSound);
                playsound = true;
            }
        }

    }

    void setPacWin()
    {
        Loss = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pacman")
        {
            setPacWin();
        }
    }

    public void addButtonPress()
    {
        buttonPress++;
        Instantiate(ButtonPressSound);
    }

    public void ResetGame()
    {
        buttonPress = 0;
        text.text = "";
        this.transform.GetComponent<SpriteRenderer>().color = Color.white;
        this.transform.GetComponent<BoxCollider2D>().isTrigger = false;
        this.GetComponent<AudioSource>().enabled = false;
        Loss = false;
        tempGameOverSound.GetComponent<AudioSource>().enabled = false;
    }
}
