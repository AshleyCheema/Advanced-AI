using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Using the Unity NavMesh enemies would turn while moving
/// To stop this state was created so they turn to face their next position before moving
/// </summary>
public class TurnToPoint : Action
{
    private int currentWaypoint;
    private float rotate;
    private float speed = 1;

    public TurnToPoint(Agent ownerBrain) : base(ownerBrain)
    {

    }
	
	// Update is called once per frame
	public override BEHAVIOUR_STATUS Update ()
    {
        currentWaypoint = GetOwner().currentWaypoint;


        //find the vector pointing from our position to the target
        Vector3 _direction = (GetOwner().waypoints[currentWaypoint].transform.position - GetOwner().transform.position).normalized;

        //create the rotation we need to be in to look at the target
        Quaternion _lookRotation = Quaternion.LookRotation(_direction);

        //rotate us over time according to speed until we are in the required rotation
        GetOwner().transform.rotation = Quaternion.Slerp(GetOwner().transform.rotation, _lookRotation, Time.deltaTime * speed);

        if (Mathf.Round(GetOwner().transform.rotation.y) == Mathf.Round(_lookRotation.y))
        {
            return BEHAVIOUR_STATUS.SUCCESS;
        }

        return BEHAVIOUR_STATUS.RUNNING;
    }
}
