using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearestTarget : Action
{
    public FindNearestTarget(Agent owner) : base(owner)
    {

    }
	
	// Update is called once per frame
	//public override BEHAVIOUR_STATUS Update ()
    //{
    //    Agent newTarget = null;
    //    float distanceToTarget = float.MaxValue;
    //
    //    foreach(Agent a in Agent.agentList)
    //    {
    //        if(a == GetOwner() || a.isInfected || a.wasBitten)
    //        {
    //            continue;
    //        }
    //
    //        float newDistance = Vector3.Distance(GetOwner().GetPosition(), a.GetPosition());
    //        if(newDistance < distanceToTarget)
    //        {
    //            distanceToTarget = newDistance;
    //            newTarget = a;
    //        }
    //    }
    //
    //
    //    if (newTarget != null)
    //    {
    //        GetOwner().SetTargetPosition(newTarget.GetPosition());
    //        return BEHAVIOUR_STATUS.SUCCESS;
    //    }
    //    else
    //    {
    //        GetOwner().GetNavMesh().isStopped = true;
    //        return BEHAVIOUR_STATUS.RUNNING;
    //    }
    //}
}
