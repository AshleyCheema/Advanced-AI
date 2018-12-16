using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// The blackboard is to make any information global to all enemies
/// If the enemy requires such information
/// </summary>
public class Blackboard : MonoBehaviour
{
    private bool playerSpotted = false;
    private float timeLastSeen;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void SetPlayerSpotted(bool b_playerSpotted)
    {
        playerSpotted = b_playerSpotted;
    }

    public bool GetPlayerSpotted()
    {
        return playerSpotted;
    }

    public void SetTimeLastSeen(float f_setTimeLastSeen)
    {
        timeLastSeen = f_setTimeLastSeen;
    }

    public float GetTimeLastSeen()
    {
        return timeLastSeen;
    }
}
