using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    bool Loss;
    [SerializeField] private Text text;
    public PlayerMovement playerMovement;
    int buttonPress;
    public Pacman pacman;
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
            pacman.GoalOpen();
        }
        if (Loss)
        {
            text.text = "Pacman Escaped!";
            playerMovement.All0();
            playerMovement.setGameFalse();
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
    }
}
