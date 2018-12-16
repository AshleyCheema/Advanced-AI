using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The enemy will move to the spot where the player was last seen
/// </summary>
public class MoveToLKP : Action
{
    private Vector3 LKP;
    //private float hitDistance;
    //private float distanceBetween;
    private float distanceLength = 8.9f;

    public MoveToLKP(Agent ownerBrain) : base(ownerBrain)
    {

    }
	
	// Update is called once per frame
	public override BEHAVIOUR_STATUS Update ()
    {
        //Takes the last time the player is spotted and moves towards the destination
        LKP = GetOwner().LKPosition();

        GetOwner().GetNavMesh().SetDestination(LKP);
        
        if(GetOwner().Position().position.x == LKP.x)
        {
            return BEHAVIOUR_STATUS.SUCCESS;
        }

        //hitDistance = GetOwner().playerSeen.HitDistance();
        //distanceBetween = Mathf.Abs(hitDistance - GetOwner().Position().transform.forward.z);

        if (GetOwner().DistanceBetween() <= distanceLength)
        {
            return BEHAVIOUR_STATUS.FAILURE;
        }

         return BEHAVIOUR_STATUS.RUNNING;

    }
}
