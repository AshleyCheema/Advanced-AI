using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public static List<Agent> agentList = new List<Agent>();
    public const float evadeSpeed = 5.0f;
    public const float pursueSpeed = 5.0f;

    public bool isIt = false;
    public bool wasBitten = false;
    public bool isInfected = false;

    private Vector3 targetPosition = Vector3.zero;
    private BTZombieInfection behaviourTree;
    private NavMeshAgent navAgent;
    private Renderer renderer;

    void Start()
    {
        //agentList.Add(this);

        navAgent = gameObject.GetComponent<NavMeshAgent>();

        //behaviourTree = new BTZombieInfection(this);

        renderer = GetComponent<Renderer>();
    }

    void Update()
    {
        behaviourTree.Update();
    }

    //public Agent FindWhoseIt()
    //{
    //    foreach (Agent b in agentList)
    //    {
    //        if (b.isIt)
    //        {
    //            return b;
    //        }
    //    }
    //
    //    return null;
    //}

    //Getters
    public void ChangeColour(Color newColor)
    {
        renderer.material.color = newColor;
    }

    public Color GetColor()
    {
        return renderer.material.color;
    }

    public Vector3 GetPosition()
    {
        return gameObject.transform.position;
    }

    public Transform GetTransform()
    {
        return gameObject.transform;
    }

    public Vector3 GetTargetPosition()
    {
        return targetPosition;
    }

    public NavMeshAgent GetNavMesh()
    {
        return navAgent;
    }

    public void SetTargetPosition(Vector3 targetPos)
    {
        targetPosition = targetPos;
    }
}