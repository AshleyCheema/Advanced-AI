using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script will work parallel to the patrol state
/// Constantly checking if the player has been seen or not
/// </summary>
public class Detection : Condition
{

    public Detection(Agent ownerBrain) : base(ownerBrain)
    {

    }
	
	// Update is called once per frame
	public override BEHAVIOUR_STATUS Update ()
    {
        if(GetOwner().Distraction().DistractedBool())
        {
            return BEHAVIOUR_STATUS.SUCCESS;
        }

        if(GetOwner().playerSeen.canSeePlayer)
        {
            return BEHAVIOUR_STATUS.SUCCESS;
        }
        
        return BEHAVIOUR_STATUS.FAILURE;
    }
}
