using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Once the key is retrieved the player can then exit the level
/// </summary>
public class GetToExit : GoapAction
{
    private bool hasExited = false;

    public GetToExit()
    {
        addPrecondition("hasKey", true);
        addPrecondition("Avoided", true);
        addEffect("GoToExit", true);
    }

    public override void reset()
    {
         
    }

    public override bool isDone()
    {
        return hasExited;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
        target = GameObject.FindGameObjectWithTag("Exit");
        return target != null;
    }

    public override bool perform(GameObject agent)
    {
        if (Vector3.Distance(target.transform.position, agent.transform.position) < 1)
        {
            Debug.Log("Huzzah, the greatest of escapes!");
            hasExited = true;
            return true;
        }

        return false;
    }
}
