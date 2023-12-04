
using UnityEngine;
using UnityEngine.UI;

public class PacmanCollision : MonoBehaviour
{
    public PlayerMovement pm;
    public Text text;
    public Pacman pacman;
    public UI ui;
    public Score score;
    public GameObject PacmanDeathSound;
    bool playsound;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.name == "Ghost1" || collision.transform.name == "Ghost2")
        {
            pm.setGameFalse();
            text.text = "Slimes Win!";
            pacman.disabePacman();
            score.setGameFalse();
            if (playsound == false)
            {
                Instantiate(PacmanDeathSound);
                playsound = true;
            }  
        }
    }

    public void ResetGame()
    {
        playsound = false;
    }
}
