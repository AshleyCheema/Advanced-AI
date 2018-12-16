using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The main goal here is to make the exit
/// </summary>
public class Player : PlayerIGoap
{
    public override HashSet<KeyValuePair<string, object>> createGoalState()
    {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();

        goal.Add(new KeyValuePair<string, object>("GoToExit", true));

        return goal;
    }
}
