using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTZombieInfection : BehaviourTree {

    public const float chaserSpeed = 10.0f;
    public const float evaderSpeed = 50.0f;

    private Selector rootSelector;
    private Selector humanSelector;

    private Sequence infectedSequence;
    private Sequence humanMoveSequence;
    private Sequence mutateSequance;

    private AmIInfected amIInfected;
    private HaveIArrived haveIArrived;
    private WasIBitten wasIBitten;

    private FindNearestTarget findNearestTarget;
    private MoveToTarget zombieMoveToTarget;
    private MoveToTarget humanMoveToTarget;
    private Mutate mutate;

    public BTZombieInfection(Agent ownerBrain) : base(ownerBrain)
    {
        rootSelector = new Selector();
        humanSelector = new Selector();

        infectedSequence = new Sequence();
        humanMoveSequence = new Sequence();
        mutateSequance = new Sequence();

        amIInfected = new AmIInfected(GetOwner());
        haveIArrived = new HaveIArrived(GetOwner());
        wasIBitten = new WasIBitten(GetOwner());

        findNearestTarget = new FindNearestTarget(GetOwner());
        zombieMoveToTarget = new MoveToTarget(GetOwner());
        humanMoveToTarget = new MoveToTarget(GetOwner());
        mutate = new Mutate(GetOwner());

        //BT
        rootSelector.AddChild(infectedSequence);
        rootSelector.AddChild(humanSelector);

        infectedSequence.AddChild(amIInfected);
        infectedSequence.AddChild(findNearestTarget);
        infectedSequence.AddChild(zombieMoveToTarget);

        humanSelector.AddChild(humanMoveSequence);
        humanSelector.AddChild(mutateSequance);

        humanMoveSequence.AddChild(haveIArrived);
        humanMoveSequence.AddChild(humanMoveToTarget);

        mutateSequance.AddChild(wasIBitten);
        mutateSequance.AddChild(mutate);

    }
	
	public override void Update ()
    {
        rootSelector.Update();
	}

    public override void Interrupt()
    {
        
    }
}
