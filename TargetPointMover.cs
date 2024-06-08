using UnityEngine;

public class TargetPointMover : MonoBehaviour
{
    [SerializeField] private Transform _point1;
    [SerializeField] private Transform _point2;
    [SerializeField] private Transform _point3;

    private int currentPointIndex = 0;

    private void Start()
    {
        transform.position = _point1.position;
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
                return _point1;
            case 1:
                return _point2;
            case 2:
                return _point3;
            default:
                return _point1;
        }
    }
}
