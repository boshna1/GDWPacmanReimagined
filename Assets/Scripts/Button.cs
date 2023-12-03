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
    public Sprite ButtonUnpressed;
    public Score score;

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
            buttonPressed = true;
            string button = transform.tag.ToString();
            pacman.SetNewButtonTarget(button);
            score.ButtonPressed();
        }
    }

    public void GameReset()
    {
        buttonPressed = false;
    }

}
