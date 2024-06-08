using UnityEngine;

public class TargetPointMover : MonoBehaviour
{
    [SerializeField] private Transform[] _points;
    private int currentPointIndex = 0;

    private void Start()
    {
        transform.position = _points[currentPointIndex].position;
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
            currentPointIndex = (currentPointIndex + 1) % _points.Length;
        }
    }

    private Transform GetNextPoint()
    {
        return _points[currentPointIndex];
    }
}