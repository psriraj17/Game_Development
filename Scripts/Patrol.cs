using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Patrol : MonoBehaviour
{
    public int index;
    public Transform[] points;
    public NavMeshAgent agent;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(points[0].position);
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("Walk", agent.speed);
        if(Vector3.Distance(transform.position, points[index].position) < 1)
        {
            index++;
            if (index >= points.Length)
                index = 0;
            agent.SetDestination(points[index].position);
        }
    }
}
