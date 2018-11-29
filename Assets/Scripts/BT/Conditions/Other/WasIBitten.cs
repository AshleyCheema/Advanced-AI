using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasIBitten : Condition
{
    private const float biteDistance = 1.2f;

    public WasIBitten(Agent ownerBrain) : base (ownerBrain)
    {

    }	

	// Update is called once per frame
	//public override BEHAVIOUR_STATUS Update ()
    //{
    //    foreach(Agent a in Agent.agentList)
    //    {
    //        if(a == GetOwner() || !a.isInfected)
    //        {
    //            continue;
    //        }
    //
    //        float newDistance = Vector3.Distance(GetOwner().GetPosition(), a.GetPosition());
    //        if(newDistance < biteDistance)
    //        {
    //            GetOwner().wasBitten = true;
    //            GetOwner().GetNavMesh().isStopped = true;
    //            return BEHAVIOUR_STATUS.SUCCESS;
    //        }
    //    }
    //
    //    return BEHAVIOUR_STATUS.FAILURE;
    //}
}
