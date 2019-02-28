using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CarPath : MonoBehaviour
{
    private int destPoint = 0;
    private NavMeshAgent car;

    public Cars gm;

    void Start()
    {
        car = GetComponent<NavMeshAgent>();

        // Disabling auto-braking allows for continuous movement between points
        car.autoBraking = false;

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (gm.points.Length == 0)
            return;

        car.destination = gm.points[destPoint].position;

        destPoint = (destPoint + 1) % gm.points.Length;
    }

    private void Update()
    {
        if (!car.pathPending && car.remainingDistance < 0.5f)
        {
            GotoNextPoint();
        }
    }
}
