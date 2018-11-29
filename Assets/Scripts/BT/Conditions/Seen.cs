using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

        if (GetOwner().DistanceBetween() <= distanceLength)
        {
            GetOwner().ExclamationMark().enabled = true;
            Debug.Log("Seen Script");
            return BEHAVIOUR_STATUS.SUCCESS;
        }

        return BEHAVIOUR_STATUS.FAILURE;
    }
}
