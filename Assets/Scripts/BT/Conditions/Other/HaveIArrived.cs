using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HaveIArrived : Condition
{
    private const float arrivalRange = 1.1f;

    public HaveIArrived(Agent ownerBrain) : base(ownerBrain)
    {

    }
	
	// Update is called once per frame
	//public override BEHAVIOUR_STATUS Update ()
    //{
	//	if(GetOwner().GetTargetPosition() == Vector3.zero)
    //    {
    //        return BEHAVIOUR_STATUS.SUCCESS;
    //    }
    //
    //    float dist = GetOwner().GetNavMesh().remainingDistance;
    //    if(dist < arrivalRange)
    //    {
    //        return BEHAVIOUR_STATUS.SUCCESS;
    //    }
    //    else
    //    {
    //        return BEHAVIOUR_STATUS.FAILURE;
    //    }
	//}
}
