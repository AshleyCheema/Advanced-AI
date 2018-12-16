using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This state is used a lot. This is needed so the enemy will wait in whatever position
/// Instead of falling back to the patrol state immediately, gives a sense of believability 
/// </summary>
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
            waitTimer = 2.0f;
            return BEHAVIOUR_STATUS.SUCCESS;
        }
        else
        {
            return BEHAVIOUR_STATUS.RUNNING;
        }
	}
}
