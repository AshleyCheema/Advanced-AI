using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// This script allows the enemies to patrol from point to point
/// </summary>
public class Patrol : Action
{
    private Vector3 waypointPos;
    private int currentWaypoint;

    public Patrol(Agent ownerBrain) : base(ownerBrain)
    {

    }
	
	public override BEHAVIOUR_STATUS Update ()
    {
        //Disable Mark and return to patrolling
        GetOwner().QuestionMark().enabled = false;
        GetOwner().ExclamationMark().enabled = false;

        //Get current waypoint, get it's position and set that as the next destination
        GetOwner().currentWaypoint = currentWaypoint;
        waypointPos = GetOwner().waypoints[currentWaypoint].transform.position;
        GetOwner().GetNavMesh().SetDestination(waypointPos);
        
        //A check to know if it has reached it's destination. If so increment
        if (!GetOwner().GetNavMesh().pathPending && !GetOwner().GetNavMesh().hasPath)
        {
            currentWaypoint++; 

            //If the increment is bigger then the array length, back to zero
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
