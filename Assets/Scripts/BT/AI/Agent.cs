using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Agent : MonoBehaviour
{
    private NavMeshAgent navAgent;
    public GameObject[] waypoints;
    private BTEnemy behaviourTree;
    public int currentWaypoint = 0;
    public BoxDetection playerSeen;
    private SpriteRenderer questionMark;
    private SpriteRenderer exclamationMark;
    private float sphereAlert;
    public bool alerted = false;
    public LayerMask enemyLayer;
    private Vector3 LKP;
    private float distance;
    private float distanceBetween;
    private float timestamp;
    public Blackboard blackboard;

    // Use this for initialization
    void Start()
    {
        behaviourTree = new BTEnemy(this);
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        playerSeen = gameObject.GetComponentInChildren<BoxDetection>();
        questionMark = gameObject.transform.Find("Question Mark").GetComponent<SpriteRenderer>();
        exclamationMark = gameObject.transform.Find("Exclamation Mark").GetComponent<SpriteRenderer>();
        sphereAlert = gameObject.GetComponentInChildren<SphereCollider>().radius;
    }

    // Update is called once per frame
    void Update()
    {
        behaviourTree.Update();
    }

    public NavMeshAgent GetNavMesh()
    {
        return navAgent;
    }

    public Transform Position()
    {
        return gameObject.transform;
    }

    public SpriteRenderer QuestionMark()
    {
        return questionMark;
    }

    public SpriteRenderer ExclamationMark()
    {
        return exclamationMark;
    }

    public float SphereAlert()
    {
        return sphereAlert;
    }

    public void Alerted(bool isAlert)
    {
        alerted = isAlert;
    }

    public LayerMask EnemyLayer()
    {
        return enemyLayer;
    }
    
    public Vector3 LKPosition()
    {
       return LKP = playerSeen.HitPoint();
    }

    public float SetTimestamp(float t_timestamp)
    {
        timestamp = t_timestamp;
        return timestamp;
    }

    public float GetTimestamp()
    {
        return timestamp;
    }

    public float DistanceBetween()
    {
        distance = playerSeen.HitDistance();
        distanceBetween = Mathf.Abs(distance - Position().transform.forward.z);

        return distanceBetween;
    }

    private void isMarkActive()
    {
        if(QuestionMark().enabled == true)
        {
            ExclamationMark().enabled = false;
        }
        else if(ExclamationMark().enabled == true)
        {
            QuestionMark().enabled = false;
        }
    }
}