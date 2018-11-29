using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmIInfected : Condition
{
    public AmIInfected(Agent ownerBrain) : base(ownerBrain)
    {

    }

	
	// Update is called once per frame
	//public override BEHAVIOUR_STATUS Update ()
    //{
	//    if(GetOwner().isInfected)
    //    {
    //        return BEHAVIOUR_STATUS.SUCCESS;
    //    }
    //    else
    //    {
    //        return BEHAVIOUR_STATUS.FAILURE;
    //    }
	//}
}
