using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Transform Exit;
    public Exit exit;
    bool buttonPressed;
    public Pacman pacman;

    private void Start()
    {
        buttonPressed = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Pacman" && buttonPressed == false)
        {
            exit.addButtonPress();
            this.transform.GetComponent<SpriteRenderer>().color = Color.green;
            buttonPressed = true;
            Debug.Log("press");
            string button = transform.tag.ToString();
            pacman.SetNewButtonTarget(button);
        }
    }

}
