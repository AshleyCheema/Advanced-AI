using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : Action
{
    private float waitTimer = 5.0f;
 
    public Wait(Agent ownerBrain) : base(ownerBrain)
    {

    }
	
	public override BEHAVIOUR_STATUS Update ()
    {
        if((waitTimer -= Time.deltaTime) < 0.0f)
        {
            waitTimer = 5.0f;
            return BEHAVIOUR_STATUS.SUCCESS;
        }
        else
        {
            return BEHAVIOUR_STATUS.RUNNING;
        }
	}
}
