using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspicious : Action
{
    //private float distance;
    //private float distanceBetween;
    private float distanceLenght = 9.0f;
    private float currentTime;

    public Suspicious(Agent ownerBrain) : base(ownerBrain)
    {

    }

    // Update is called once per frame
    public override BEHAVIOUR_STATUS Update ()
    {
        //distance = GetOwner().playerSeen.HitDistance();
        //distanceBetween = Mathf.Abs(distance - GetOwner().Position().transform.forward.z);

        currentTime = Time.realtimeSinceStartup;

        if(GetOwner().alerted == true)
        {
            if(GetOwner().GetTimestamp() >= currentTime)
            {
                
            }
        }

        if (GetOwner().DistanceBetween() >= distanceLenght)
        {
            Debug.Log("Suspicious Script");
            return BEHAVIOUR_STATUS.SUCCESS;
        }

        return BEHAVIOUR_STATUS.FAILURE;
	}
}
