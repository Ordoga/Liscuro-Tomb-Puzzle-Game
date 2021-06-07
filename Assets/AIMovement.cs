using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMovement : MonoBehaviour
{
    [SerializeField] Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("White Hand").transform;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    
    void Update()
    {
        if (GetComponent<FollowHolder>().pickedUp)
        {
            agent.SetDestination(target.position);
        }
    }
}
