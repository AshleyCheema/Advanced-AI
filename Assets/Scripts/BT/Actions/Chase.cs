using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// If the player is close enough for the enemy to spot the player then the chase state will activate
/// </summary>
public class Chase : Action
{
    private Vector3 LKP;
    private float distanceLength = 1.0f;

    public Chase(Agent ownerBrain) : base(ownerBrain)
    {


    }
	
	// Update is called once per frame
	public override BEHAVIOUR_STATUS Update()
    {
        GetOwner().GetNavMesh().SetDestination(GetOwner().LKPosition());

        if (!GetOwner().playerSeen.canSeePlayer)
        {
            return BEHAVIOUR_STATUS.SUCCESS;
        }

        if(GetOwner().DistanceBetween() <= distanceLength)
        {
            Debug.Log("You Dead");
            return BEHAVIOUR_STATUS.SUCCESS;
        }

        return BEHAVIOUR_STATUS.RUNNING;
	}
}
