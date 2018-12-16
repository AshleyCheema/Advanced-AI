using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distracted : MonoBehaviour
{
    private bool distracted = false;
    private Vector3 distractionDest;
    private float dist;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Distraction")
        {
            distracted = true;           
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Distraction")
        {
            if (distracted)
            {
                distractionDest = other.transform.position;
                Debug.Log(distractionDest);
                dist = Vector2.Distance(other.transform.position, transform.position);
                Debug.Log(dist);
            }

            if (dist <= 1)
            {
                other.gameObject.SetActive(false);
                distracted = false;
            }
        }
    }

    public bool DistractedBool()
    {
        return distracted;
    }

    public Vector3 DistractionDestination()
    {
        return distractionDest;
    }
}
