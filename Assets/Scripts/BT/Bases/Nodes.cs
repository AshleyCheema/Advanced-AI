using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BEHAVIOUR_STATUS
{
    SUCCESS,
    FAILURE,
    RUNNING,
    NONE
}

public class Nodes
{
    private BEHAVIOUR_STATUS behaviourStatus;

    public Nodes()
    {
        behaviourStatus = BEHAVIOUR_STATUS.NONE;
    }

    public virtual BEHAVIOUR_STATUS Update()
    {
        return BEHAVIOUR_STATUS.NONE;
    }
    

}
