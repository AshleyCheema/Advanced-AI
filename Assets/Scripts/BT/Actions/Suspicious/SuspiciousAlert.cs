using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// This script will alert any enemies in the sphere check distance
/// which will then alert them of the enemies presence
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
        if(Physics.CheckSphere(GetOwner().Position().position, GetOwner().SphereAlert(), GetOwner().EnemyLayer()))
        {
            isAlerted = true;
            Collider[] hitColliders = Physics.OverlapSphere(GetOwner().Position().position, GetOwner().SphereAlert(), GetOwner().EnemyLayer());

            for (int i = 0; i < hitColliders.Length; i++)
            {
                hitColliders[i].GetComponent<Agent>().Alerted(isAlerted);
                hitColliders[i].GetComponent<Agent>().QuestionMark().enabled = true;
                hitColliders[i].GetComponent<Agent>().SetTimestamp(Time.realtimeSinceStartup);
            }
        }

        return BEHAVIOUR_STATUS.SUCCESS;
	}
}
