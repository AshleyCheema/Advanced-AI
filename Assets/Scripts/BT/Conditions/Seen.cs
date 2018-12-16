using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The Seen script checks the distance 
/// If the player is close enough they will begin the chase
/// </summary>
public class Seen : Condition
{
   //private float hitDistance;
   //private float distanceBetween;
    private float distanceLength = 8.9f;

    public Seen(Agent ownerBrain) : base(ownerBrain)
    {

    }

    // Update is called once per frame
    public override BEHAVIOUR_STATUS Update()
    {
        //hitDistance = GetOwner().playerSeen.HitDistance();
        //distanceBetween = Mathf.Abs(hitDistance - GetOwner().Position().transform.forward.z);
        if (GetOwner().playerSeen.canSeePlayer)
        {
            if (GetOwner().DistanceBetween() <= distanceLength)
            {
                GetOwner().ExclamationMark().enabled = true;
                GetOwner().QuestionMark().enabled = false;
                Debug.Log("Seen Script");
                return BEHAVIOUR_STATUS.SUCCESS;
            }
        }
        return BEHAVIOUR_STATUS.FAILURE;
    }
}
