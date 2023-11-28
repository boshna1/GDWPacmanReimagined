using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostRange : MonoBehaviour
{
    public Pacman pacman;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Pacman")
        {
            pacman.InGhostRange(true,this.transform);
            Debug.Log("Pacman enter");
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Pacman")
        {
            pacman.InGhostRange(false,this.transform);
            pacman.setNewButtonTarget();
            Debug.Log("Pacman Exit");
        }
    }

    void Update()
    {
        
    }
}
