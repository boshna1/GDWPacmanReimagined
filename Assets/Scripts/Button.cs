using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Transform Exit;
    public Exit exit;
    public Exit exit2;
    bool buttonPressed;
    public Pacman pacman;
    public Sprite ButtonPressed;

    private void Start()
    {
        buttonPressed = false;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Pacman" && buttonPressed == false)
        {
            exit.addButtonPress();
            exit2.addButtonPress();
            this.transform.GetComponent<SpriteRenderer>().sprite = ButtonPressed;
            this.GetComponent<AudioSource>().enabled = true;
            buttonPressed = true;
            string button = transform.tag.ToString();
            pacman.SetNewButtonTarget(button);
        }
    }

}
