using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : Condition
{

    public Detection(Agent ownerBrain) : base(ownerBrain)
    {

    }
	
	// Update is called once per frame
	public override BEHAVIOUR_STATUS Update ()
    {

        if(GetOwner().playerSeen.canSeePlayer)
        {
            return BEHAVIOUR_STATUS.SUCCESS;
        }
        
        return BEHAVIOUR_STATUS.FAILURE;
    }
}
