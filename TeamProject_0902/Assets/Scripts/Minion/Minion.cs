using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Minion : MonoBehaviour
{
    NavMeshAgent navAgent;
    public Transform target;
    private int wavePointIndex = 0;         //Node Index
    void Start()
    {
        navAgent = GetComponentInChildren<NavMeshAgent>();
        target = WayPoints.wayPoints[0];
    }

    void Update()
    {
        if (target != null)
        {
            navAgent.SetDestination(target.position);
            if(navAgent.remainingDistance<=0.01f)
            {
                GetNextWayPoint();
            }
        }
        else
        {
            //Combat when get destination
        }
    }

    void GetNextWayPoint()
    {
        wavePointIndex++;
        target = WayPoints.wayPoints[wavePointIndex-1];
        navAgent.SetDestination(target.position);

        if(wavePointIndex>=WayPoints.wayPoints.Length-1)
        {
            wavePointIndex = WayPoints.wayPoints.Length-1;
        }
    }
}
