using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetPointMover : MonoBehaviour
{
    public Transform point1;
    public Transform point2;
    public Transform point3;

    private int currentPointIndex = 0;

    private void Start()
    {
        transform.position = point1.position;
    }

    private void Update()
    {
        MoveToNextPoint();
    }

    private void MoveToNextPoint()
    {
        Transform targetPoint = GetNextPoint();
        float step = 0.1f;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);

        if (Vector3.Distance(transform.position, targetPoint.position) < 0.01f)
        {
            currentPointIndex = (currentPointIndex + 1) % 3;
        }
    }

    private Transform GetNextPoint()
    {
        switch (currentPointIndex)
        {
            case 0:
                return point1;
            case 1:
                return point2;
            case 2:
                return point3;
            default:
                return point1;
        }
    }
}
