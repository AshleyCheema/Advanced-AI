using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class PlayerIGoap : MonoBehaviour, IGoap
{
    private NavMeshAgent navMesh;
    private PlayerSight playerSight;

    // Use this for initialization
    void Start ()
    {
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        playerSight = gameObject.GetComponentInChildren<PlayerSight>();
    }
    
	// Update is called once per frame
	void Update ()
    {
		
	}

    public HashSet<KeyValuePair<string, object>> getWorldState()
    {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();

        worldData.Add(new KeyValuePair<string, object>("Avoided", false));
        worldData.Add(new KeyValuePair<string, object>("hasKey", false));
        worldData.Add(new KeyValuePair<string, object>("GoToExit", false));

        return worldData;
    }

    public abstract HashSet<KeyValuePair<string, object>> createGoalState();

    public void planFailed (HashSet<KeyValuePair<string, object>> failedGoal)
    {

    }

    public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<GoapAction> actions)
    {
        // Yay we found a plan for our goal
        Debug.Log("<color=green>Plan found</color> " + GoapAgent.prettyPrint(actions));
    }

    public void actionsFinished()
    {
        // Everything is done, we completed our actions for this gool. Hooray!
        Debug.Log("<color=blue>Actions completed</color>");
    }

    public void planAborted(GoapAction aborter)
    {
        Debug.Log("<color=red>Plan Aborted</color> " + GoapAgent.prettyPrint(aborter));
    }

    public bool moveAgent(GoapAction nextAction)
    {
        //This moves the player to the position it needs too
        //Then moves to the next action once it is complete
        if (nextAction.cost != 0)
        {
            navMesh.isStopped = false;
            navMesh.SetDestination(nextAction.target.transform.position);

            if(playerSight.enemySpotted)
            {
                nextAction.doReset();
            }

            if (Vector3.Distance(gameObject.transform.position, nextAction.target.transform.position) < 1)
            {
                nextAction.setInRange(true);
                return true;
            }
        }
        if(nextAction.cost == 0)
        {
            navMesh.isStopped = true;
            nextAction.setInRange(true);
            return true;
        }
        return false;
    }
}
