using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 2f;

    private Vector3 _direction;

    public void SetRandomDirection(Vector3 newDirection)
    {
        _direction = newDirection;
    }

    private void Update()
    {
        MoveInDirection();
    }

    private void MoveInDirection()
    {
        Vector3 targetPosition = _direction;
        Vector3 currentPosition = transform.position;

        float step = _moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, step);
    }
}
