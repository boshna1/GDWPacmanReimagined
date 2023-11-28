using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEditor.Experimental.GraphView;

public class Pacman : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] buttons = new Transform[4];
    int TargetButton;
    int[] enabledbuttons = new int[4];
    bool SetNewTarget;
    bool GoalOpened;
    public Transform Goal;
    bool GhostInRange;
    public Transform Ghost;
    Vector2 GoalOffset;
    public Transform pacman;

    private void Start()
    {
        for (int i = 0; i < buttons.Length; i++) 
        {
            enabledbuttons[i] = 0;
        }
        GoalOpened = false;
        TargetButton = Random.Range(0, 4);
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }
    // Update is called once per frame
    void Update()
    { 
        if (SetNewTarget == true)
        {
            TargetButton = Random.Range(0, 4);
                if (enabledbuttons[TargetButton] == 1)
                {
                    TargetButton = Random.Range(0, 4);
                    Debug.Log(TargetButton);
                }
            SetNewTarget = false;
        }
        if (GoalOpened == false && GhostInRange == false) 
        {
            agent.SetDestination(buttons[TargetButton].transform.position);
        }
        if (GoalOpened == true && GhostInRange == false)
        {
            agent.SetDestination(Goal.position);
        }
        if (GoalOpened == true && GhostInRange == true)
        {
            int random = Random.Range(0,1);
            if (random == 0)
            {
                GoalOffset = new Vector2(0,3);
            }
            if (random == 1)
            {
                GoalOffset = new Vector2(0, -3);
            }
            agent.SetDestination((Vector2)Goal.position + GoalOffset);
        }
        if (GhostInRange == true)
        {
            Vector2 tempVector = ((new Vector2(transform.position.x - Ghost.position.x,transform.position.y - Ghost.position.y) * 3) + new Vector2(transform.position.x,transform.position.y));
            Debug.Log(tempVector);
            agent.SetDestination(tempVector ); // add offset depending on quadrant
        }
        
        
    }

    public void SetNewButtonTarget(string button)
    {
        SetNewTarget = true;
        if (button == "Button1")
        {
            enabledbuttons[0] = 1;
        }
        if (button == "Button2")
        {
            enabledbuttons[1] = 1;
        }
        if (button == "Button3")
        {
            enabledbuttons[2] = 1;
        }
        if (button == "Button4")
        {
            enabledbuttons[3] = 1;
        }
    }

    public void GoalOpen()
    {
        GoalOpened = true;
    }

    public void InGhostRange(bool input, Transform GhostTrans)
    {
        GhostInRange = input;
        Ghost = GhostTrans;
    }

    public void setNewButtonTarget()
    {
        SetNewTarget = true;
    }

    public void disabePacman()
    {
        agent.SetDestination(this.transform.position);
    }
}
