using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction : Action {

    public Distraction(Agent ownerBrain) : base(ownerBrain)
    {

    }

    // Update is called once per frame
    public override BEHAVIOUR_STATUS Update ()
    {
        Vector3 DestinationOfDistraction = GetOwner().Distraction().DistractionDestination();
        
        if (GetOwner().Distraction().DistractedBool())
        {
            if (GetOwner().GetNavMesh().SetDestination(DestinationOfDistraction))
            {
                return BEHAVIOUR_STATUS.SUCCESS;
            }
        }

        return BEHAVIOUR_STATUS.FAILURE;
	}
}
