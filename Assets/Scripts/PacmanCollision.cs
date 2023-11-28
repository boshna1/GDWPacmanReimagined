using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PacmanCollision : MonoBehaviour
{
    public PlayerMovement pm;
    public Text text;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Ghost1" || collision.transform.name == "Ghost2")
        {
            pm.setGameFalse();
            text.text = "Ghost Wins!";
        }
    }
}