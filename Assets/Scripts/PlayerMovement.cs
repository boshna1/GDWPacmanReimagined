using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject Ghost1;
    public GameObject Ghost2;
    Vector2 tempdirection;
    Vector2 Ghost1direction;
    Vector2 Ghost2direction;
    public float speed;
    string currentGhost;
    bool PlayGame;
    public Pacman pacman;
    public Sprite[] Ghost1Sprites = new Sprite[4];
    public Sprite[] Ghost2Sprites = new Sprite[4];

    // Start is called before the first frame update
    void Start()
    {
        tempdirection = Vector2.zero;
        PlayGame = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayGame) 
        {
            ChangeSprite();
        Ghost1.transform.Translate(Ghost1direction);
        Ghost2.transform.Translate(Ghost2direction);
        if (Input.GetKeyDown(KeyCode.W))
        {
            tempdirection = Vector2.up * speed;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            tempdirection = Vector2.left * speed;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            tempdirection = Vector2.down * speed;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            tempdirection = Vector2.right * speed;
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            switchGhost1();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            switchGhost2();
        }
        if (currentGhost == "Red")
        {
            Ghost1direction = tempdirection;
        }
        if (currentGhost == "Blue")
        {
            Ghost2direction = tempdirection;
        }
            
        }
    }

    void switchGhost1()
    {
        tempdirection =  Vector2.zero;
        currentGhost = "Red";
    }
    void switchGhost2()
    {
        tempdirection = Vector2.zero;
        currentGhost = "Blue";
    }

    public void setGameFalse()
    {
        PlayGame = false; ;
    }

    public void All0()
    {
        Ghost1direction = Vector2.zero;
        Ghost2direction = Vector2.zero;
        pacman.disabePacman();
    }

    void ChangeSprite()
    {
        if (Input.GetKeyDown(KeyCode.W) && currentGhost == "Red")
        {
            Ghost1.GetComponent<SpriteRenderer>().sprite = Ghost1Sprites[3];
        }
        if (Input.GetKeyDown(KeyCode.A) && currentGhost == "Red")
        {
            Ghost1.GetComponent<SpriteRenderer>().sprite = Ghost1Sprites[0];
        }
        if (Input.GetKeyDown(KeyCode.S) && currentGhost == "Red")
        {
            Ghost1.GetComponent<SpriteRenderer>().sprite = Ghost1Sprites[2];
        }
        if (Input.GetKeyDown(KeyCode.D) && currentGhost == "Red")
        {
            Ghost1.GetComponent<SpriteRenderer>().sprite = Ghost1Sprites[1];
        }

        if (Input.GetKeyDown(KeyCode.W) && currentGhost == "Blue")
        {
            Ghost2.GetComponent<SpriteRenderer>().sprite = Ghost2Sprites[3];
        }
        if (Input.GetKeyDown(KeyCode.A) && currentGhost == "Blue")
        {
            Ghost2.GetComponent<SpriteRenderer>().sprite = Ghost2Sprites[0];
        }
        if (Input.GetKeyDown(KeyCode.S) && currentGhost == "Blue")
        {
            Ghost2.GetComponent<SpriteRenderer>().sprite = Ghost2Sprites[2];
        }
        if (Input.GetKeyDown(KeyCode.D) && currentGhost == "Blue")
        {
            Ghost2.GetComponent<SpriteRenderer>().sprite = Ghost2Sprites[1];
        }
    }
}
