using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutate : Action
{
    private Color currentColour;

    public Mutate(Agent ownerBrain) : base(ownerBrain)
    {

    }
	
	// Update is called once per frame
	//public override BEHAVIOUR_STATUS Update ()
    //{
    //    currentColour = GetOwner().GetColor();
    //
    //    if(GetOwner().GetColor() != Color.green)
    //    {
    //        currentColour = Color.Lerp(currentColour, Color.green, 0.1f);
    //        GetOwner().ChangeColour(currentColour);
    //
    //        return BEHAVIOUR_STATUS.RUNNING;
    //    }
    //    else
    //    {
    //        GetOwner().isInfected = true;
    //        return BEHAVIOUR_STATUS.SUCCESS;
    //    }
	//}
}
