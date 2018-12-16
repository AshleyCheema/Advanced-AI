using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script will alert any enemies in the sphere check distance
/// which will then alert them of the players presence
/// </summary>
public class SuspiciousAlert : Action
{
    private bool isAlerted = false;
    //private float timestamp;

    public SuspiciousAlert(Agent ownerBrain) : base(ownerBrain)
    {
        
    }
	
	// Update is called once per frame
	public override BEHAVIOUR_STATUS Update ()
    {
        //Anyone within the sphere will be detected and shared the necessary info
        if(Physics.CheckSphere(GetOwner().Position().position, GetOwner().SphereAlert()))
        {
            //The info is first shared onto the blackboard so it is global
            isAlerted = true;
            GetOwner().Blackboard().SetPlayerSpotted(isAlerted);
            GetOwner().Blackboard().SetTimeLastSeen(Time.realtimeSinceStartup);

            //Any enemy within the sphere will check the blackboard if the player has been spotted
            Collider[] hitColliders = Physics.OverlapSphere(GetOwner().Position().position, GetOwner().SphereAlert());
            for (int i = 0; i < hitColliders.Length; i++)
            {
                if (hitColliders[i].GetComponent<Agent>() != null)
                {
                    hitColliders[i].GetComponent<Agent>().Alerted();
                    hitColliders[i].GetComponent<Agent>().QuestionMark().enabled = true;
                }
            }
        }

        return BEHAVIOUR_STATUS.SUCCESS;
	}
}
