using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxDetection : MonoBehaviour
{
    public bool canSeePlayer = false;
    private RaycastHit hit;
    public LayerMask layerMask;
    private float hitDistance;

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Vector3 direction = other.gameObject.transform.position - transform.position;

            if(Physics.Raycast(transform.position, direction, out hit, 20.0f, layerMask))
            {   
                canSeePlayer = true;
                Debug.Log(canSeePlayer);
                Debug.DrawRay(transform.position, direction, Color.red);
                hitDistance = hit.distance;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            canSeePlayer = false;
            Debug.Log(canSeePlayer);
        }
    }
    
    public float HitDistance()
    {
        return hitDistance;
    }

    public Vector3 HitPoint()
    {
        return hit.point;
    }
}
