
using UnityEngine;
using UnityEngine.AI;

public class Pacman : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] buttons = new Transform[4];
    int TargetButton;
    int[] enabledbuttons = new int[4];
    bool SetNewTarget;
    bool GoalOpened;
    public Transform Goal;
    public Transform Goal2;
    bool isOneGhostRange;
    bool isTwoGhostRange;
    public Transform OneGhostRange;
    public Transform Ghost1;
    public Transform Ghost2;
    public int GhostCountInRange;
    bool GhostInRange;
    Vector2 Offset;
    public Transform pacman;
    bool pacmanChooseGoal = false;
    public GameObject destination;
    public Sprite[] PacmanSprites = new Sprite[4];
    Vector2 DestinationVec;
    bool Game;
    public UI ui;

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            enabledbuttons[i] = 0;
        }
        Game = true;
        GoalOpened = false;
        TargetButton = Random.Range(0, 4);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (Game)
        {
            if (SetNewTarget == true && GoalOpened == false)
            {
                TargetButton = Random.Range(0, 4);
                while (enabledbuttons[TargetButton] == 1)
                {
                    TargetButton = Random.Range(0, 4);
                }
                SetNewTarget = false;
                DestinationVec = buttons[TargetButton].transform.position;
            }
            if (GhostCountInRange == 1)
            {
                isOneGhostRange = true;
                GhostInRange = true;
            }
            if (GhostCountInRange == 2)
            {
                isTwoGhostRange = true;
                isOneGhostRange = false;
                GhostInRange = true;
            }
            if (GhostCountInRange == 0)
            {
                isTwoGhostRange = false;
                isOneGhostRange = false;
                GhostInRange = false;
            }

            if (GoalOpened == true && GhostInRange == false && pacmanChooseGoal == false)
            {
                if ((Goal.transform.position - this.transform.position).magnitude > (Goal2.transform.position - this.transform.position).magnitude)
                {
                    Debug.Log("Goal2 set");
                    DestinationVec = (Goal2.transform.position);
                }
                else
                {
                    Debug.Log("Goal1 set");
                    DestinationVec = (Goal.transform.position);
                }
                pacmanChooseGoal = true;
                agent.SetDestination(DestinationVec + Offset);
            }
            if (GhostInRange == true && GoalOpened == true)
            {
                pacmanChooseGoal = false;
            }
            if (GhostInRange == true && GoalOpened == false)
            {
                if (isOneGhostRange)
                {
                    DestinationVec = (Vector2)(pacman.transform.position - OneGhostRange.transform.position) * 1.5f + (Vector2)transform.position + new Vector2(0,1);
                }
                if (isTwoGhostRange)
                {
                    DestinationVec = (Vector2)(pacman.transform.position - Ghost1.transform.position + Ghost2.transform.position) * 1.5f + (Vector2)transform.position;
                }
                if (DestinationVec.x < -13 && DestinationVec.y < -16 && DestinationVec.y < 0 && isOneGhostRange)
                {
                    Offset = new Vector2(0, 2);
                }
                if (DestinationVec.x < -13 && DestinationVec.y < -16 && isOneGhostRange)
                {
                    Offset = new Vector2(2, 0);
                }
                if (DestinationVec.x > 13 && DestinationVec.y > -16 && DestinationVec.y < 0 && isOneGhostRange)
                {
                    Offset = new Vector2(0, 2);
                }
                if (DestinationVec.x > 13 && DestinationVec.y < -16 && isOneGhostRange)
                {
                    Offset = new Vector2(-2, 0);
                }

                if (DestinationVec.x < -13 && DestinationVec.y > 16 && DestinationVec.y > 0 && isOneGhostRange)
                {
                    Offset = new Vector2(0, 2);
                }
                if (DestinationVec.x < -13 && DestinationVec.y > 16 && isOneGhostRange)
                {
                    Offset = new Vector2(2, 0);
                }
                if (DestinationVec.x > 13 && DestinationVec.y < 16 && DestinationVec.y > 0 && isOneGhostRange)
                {
                    Offset = new Vector2(0, 2);
                }
                if (DestinationVec.x > 13 && DestinationVec.y > 16 && isOneGhostRange)
                {
                    Offset = new Vector2(-2, 0);
                }
                destination.transform.position = DestinationVec;
                agent.SetDestination(DestinationVec + Offset);
                
            }

            if (destination.transform.position.x - pacman.transform.position.x > 0 && (destination.transform.position.y - pacman.transform.position.y > 1 || destination.transform.position.y - pacman.transform.position.y < 1))
            {
                pacman.GetComponent<SpriteRenderer>().sprite = PacmanSprites[0];
            }
            if (destination.transform.position.x - pacman.transform.position.x < 0 && (destination.transform.position.y - pacman.transform.position.y > 1 || destination.transform.position.y - pacman.transform.position.y < 1))
            {
                pacman.GetComponent<SpriteRenderer>().sprite = PacmanSprites[1];
            }
            if (destination.transform.position.x - pacman.transform.position.y > 0 && (destination.transform.position.x - pacman.transform.position.x < 1 || destination.transform.position.x - pacman.transform.position.x < -1))
            {
                pacman.GetComponent<SpriteRenderer>().sprite = PacmanSprites[2];
            }
            if (destination.transform.position.x - pacman.transform.position.y < 0 && (destination.transform.position.x - pacman.transform.position.x < 1 || destination.transform.position.x - pacman.transform.position.x < -1))
            {
                pacman.GetComponent<SpriteRenderer>().sprite = PacmanSprites[3];
            }
            destination.transform.position = DestinationVec;
            agent.SetDestination(DestinationVec + Offset);
            Debug.Log(Offset);
        }
    }

    public void SetNewButtonTarget(string button)
    {
        SetNewTarget = true;
        if (button == "Button1")
        {
            enabledbuttons[0] = 1;
            Debug.Log("button1 disabled");
        }
        if (button == "Button2")
        {
            enabledbuttons[1] = 1;
            Debug.Log("button2 disabled");
        }
        if (button == "Button3")
        {
            enabledbuttons[2] = 1;
            Debug.Log("button3 disabled");
        }
        if (button == "Button4")
        {
            enabledbuttons[3] = 1;
            Debug.Log("button4 disabled");
        }
    }

    public void GoalOpen()
    {
        GoalOpened = true;
    }

    public void InGhostRange(Transform GhostTrans, int Ghosts)
    {
        OneGhostRange = GhostTrans;
        GhostCountInRange += Ghosts;
    }


    public void setNewButtonTarget()
    {
        SetNewTarget = true;
    }

    public void disabePacman()
    {
        agent.SetDestination(this.transform.position);
        Game = false;
        ui.enableWinScreen();
    }

    public void ResetGame()
    {
        for (int i = 0;i < 4; i++) 
        {
            enabledbuttons[i] = 0;
        }
        GoalOpened = false;
        pacman.transform.position = new Vector2(-3.43f, -5.93f);
        setNewButtonTarget();
        TargetButton = Random.Range(0, 4);
        Game = true;
    }
}
