using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTEnemy : BehaviourTree
{
    private Selector rootSelector;

    private Sequence patrolSequence;
    private Sequence enemyCheck;
    private Sequence suspiciousSequence;
    private Sequence ChaseSequence;

    private Inverter checkInverter;
    private Parallel parallelDetection;

    private Patrol patrol;
    private Wait wait;
    private TurnToPoint turnToPoint;
    private Detection detection;
    private Suspicious suspicious;
    private Seen seen;
    private Chase chase;
    private SuspiciousAlert suspiciousAlert;
    private MoveToLKP moveToLKP;

	public BTEnemy(Agent ownerBrain) : base(ownerBrain)
    {
        rootSelector = new Selector();

        enemyCheck = new Sequence();
        patrolSequence = new Sequence();
        suspiciousSequence = new Sequence();
        ChaseSequence = new Sequence();

        parallelDetection = new Parallel();
        checkInverter = new Inverter();

        turnToPoint = new TurnToPoint(GetOwner());
        patrol = new Patrol(GetOwner());
        wait = new Wait(GetOwner());

        detection = new Detection(GetOwner());

        suspicious = new Suspicious(GetOwner());
        suspiciousAlert = new SuspiciousAlert(GetOwner());
        moveToLKP = new MoveToLKP(GetOwner());

        seen = new Seen(GetOwner());
        chase = new Chase(GetOwner());

        //Root -> Patrol and Check
        rootSelector.AddChild(parallelDetection);
        parallelDetection.AddChild(checkInverter);

        //A parallel to check for player
        checkInverter.AddChild(detection);

        //Patrol alongside checking for the player
        parallelDetection.AddChild(patrolSequence);
        patrolSequence.AddChild(patrol);
        patrolSequence.AddChild(wait);
        patrolSequence.AddChild(turnToPoint);

        //Root -> Check distance to chase
        rootSelector.AddChild(suspiciousSequence);
        rootSelector.AddChild(ChaseSequence);

        //Go to suspicious state
        suspiciousSequence.AddChild(suspicious);
        suspiciousSequence.AddChild(suspiciousAlert);
        suspiciousSequence.AddChild(moveToLKP);

        //Go to chase state
        ChaseSequence.AddChild(seen);
        ChaseSequence.AddChild(chase);

    }

    // Update is called once per frame
    public override void Update ()
    {
        rootSelector.Update();
	}
}
