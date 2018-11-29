using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : Action
{
    private Vector3 waypointPos;
    private int currentWaypoint;

    public Patrol(Agent ownerBrain) : base(ownerBrain)
    {

    }
	
	public override BEHAVIOUR_STATUS Update ()
    {
        GetOwner().QuestionMark().enabled = false;
        GetOwner().ExclamationMark().enabled = false;

        GetOwner().currentWaypoint = currentWaypoint;

        waypointPos = GetOwner().waypoints[currentWaypoint].transform.position;
        GetOwner().GetNavMesh().SetDestination(waypointPos);

        if (!GetOwner().GetNavMesh().pathPending && !GetOwner().GetNavMesh().hasPath)
        {
            currentWaypoint++; 

            if (currentWaypoint > GetOwner().waypoints.Length - 1)
            {
                currentWaypoint = 0;
            }

            GetOwner().currentWaypoint = currentWaypoint;

            return BEHAVIOUR_STATUS.SUCCESS;
        }

        return BEHAVIOUR_STATUS.RUNNING;
    }
}
