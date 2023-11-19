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
    // Start is called before the first frame update
    void Start()
    {
        tempdirection = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {
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
            Ghost1direction = Vector2.zero;
            Ghost1direction = tempdirection;
        }
        if (currentGhost == "Blue")
        {
            Ghost2direction = Vector2.zero;
            Ghost2direction = tempdirection;
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
}
