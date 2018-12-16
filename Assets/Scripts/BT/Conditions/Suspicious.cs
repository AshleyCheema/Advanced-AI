using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The Suspicious state actives if the player is too far but can be seen
/// If the enemy is suspicious they will stay suspicious for a while
/// If the player is to be spotted and the enemy is still suspicious they will go straight into the chase state
/// </summary>
public class Suspicious : Action
{
    //private float distance;
    //private float distanceBetween;
    private float distanceLenght = 9.0f;
    private float currentTime;
    private float timeLeft = 10.0f;

    public Suspicious(Agent ownerBrain) : base(ownerBrain)
    {

    }

    // Update is called once per frame
    public override BEHAVIOUR_STATUS Update ()
    {
        //distance = GetOwner().playerSeen.HitDistance();
        //distanceBetween = Mathf.Abs(distance - GetOwner().Position().transform.forward.z);

        currentTime = Time.realtimeSinceStartup;
        if(GetOwner().Alerted() == true)
        {
            if(currentTime >= GetOwner().GetTimestamp() + timeLeft)
            {
                GetOwner().Blackboard().SetPlayerSpotted(false);
            }
            else
            {
                return BEHAVIOUR_STATUS.FAILURE;
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
