using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : Action
{
    public MoveToTarget(Agent owner) : base(owner)
    {

    }
	
	// Update is called once per frame
	//public override BEHAVIOUR_STATUS Update ()
    //{
	//	if(GetOwner().GetTargetPosition() != Vector3.zero)
    //    {
    //        GetOwner().GetNavMesh().isStopped = false;
    //        GetOwner().GetNavMesh().SetDestination(GetOwner().GetTargetPosition());
    //
    //        return BEHAVIOUR_STATUS.SUCCESS;
    //    }
    //
    //    return BEHAVIOUR_STATUS.FAILURE;
	//}
}
