using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Before being able to exit the level the player needs to get the key
/// </summary>
public class GetKey : GoapAction
{
    private bool hasKey = false;

    public GetKey()
    {
        addPrecondition("hasKey", false);
        addPrecondition("Avoided", true);
        addEffect("hasKey", true);
        //addEffect("Avoided", false);
    }

    public override void reset()
    {

    }

    public override bool isDone()
    {
        return hasKey;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
        target = GameObject.FindGameObjectWithTag("Key");
        return target != null;
    }

    public override bool perform(GameObject agent)
    {
        //Check whether the player is close enough to the key
        if(Vector3.Distance(target.transform.position, agent.transform.position) < 1)
        {
            target.SetActive(false);
            hasKey = true;
            return true;
        }

        return false;

    }
}
