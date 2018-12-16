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
    private bool alerted = false;
    private Vector3 LKP;
    private float distance;
    private float distanceBetween;
    private float timestamp;
    private Blackboard blackboard;
    private Distracted distracted;

    // Use this for initialization
    void Start()
    {
        behaviourTree = new BTEnemy(this);
        navAgent = gameObject.GetComponent<NavMeshAgent>();
        playerSeen = gameObject.GetComponentInChildren<BoxDetection>();
        distracted = gameObject.GetComponentInChildren<Distracted>();
        questionMark = gameObject.transform.Find("Question Mark").GetComponent<SpriteRenderer>();
        exclamationMark = gameObject.transform.Find("Exclamation Mark").GetComponent<SpriteRenderer>();
        sphereAlert = gameObject.GetComponentInChildren<SphereCollider>().radius;
        blackboard = gameObject.GetComponentInChildren<Blackboard>();
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

    public bool Alerted()
    {
        alerted = Blackboard().GetPlayerSpotted();
        return alerted;
    }
    
    public Vector3 LKPosition()
    {
       return LKP = playerSeen.HitPoint();
    }

    public Blackboard Blackboard()
    {
        return blackboard;
    }

    public Distracted Distraction()
    {
        return distracted;
    }

    public float GetTimestamp()
    {
        timestamp = Blackboard().GetTimeLastSeen();
        return timestamp;
    }

    public float DistanceBetween()
    {
        distance = playerSeen.HitDistance();
        distanceBetween = Mathf.Abs(distance - Position().transform.forward.z);

        return distanceBetween;
    }
}