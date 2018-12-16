using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avoidance : GoapAction
{
    private bool avoided = false;
    PlayerSight playerSight;

    public void Start()
    {
        playerSight = GetComponentInChildren<PlayerSight>();
    }

    public Avoidance()
    {
        addPrecondition("Avoided", false);
        addEffect("Avoided", true);
    }

    public override void reset()
    {
        avoided = false;
    }

    public override bool isDone()
    {
        return avoided;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
        target = playerSight.enemy;

        return target != null;
    }

    public override bool perform(GameObject agent)
    {
        if (!playerSight.enemySpotted)
        {
            avoided = true;
            return true;
        }
        return false;
    }
}
