using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Transform Exit;
    int ButtonPress;
    private void Update()
    {
        if (ButtonPress >= 3)
        {
            Exit.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Pacman")
        {
            ButtonPress++;
        }
    }
}
