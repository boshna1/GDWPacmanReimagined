using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRange : MonoBehaviour
{
    public Pacman pacman;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Pacman")
        {
            pacman.InGhostRange( this.transform, 1);
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Pacman")
        {
            pacman.InGhostRange( this.transform, -1);
            pacman.setNewButtonTarget();
        }
    }

    void Update()
    {
        
    }
}
