using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSight : MonoBehaviour {

    public bool enemySpotted;
    public GameObject enemy;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            enemySpotted = true;
            enemy = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        enemySpotted = false;
        enemy = null;
    }
}
