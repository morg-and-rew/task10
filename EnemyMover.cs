using UnityEngine;

public abstract class EnemyMover : MonoBehaviour, IMovableInDiraction
{
    [SerializeField] private float _moveSpeed = 2f;

    public Vector3 _direction;

    public  void SetRandomDirection(Vector3 newDirection)
    {
        _direction = newDirection;
    }

    private void Update()
    {
        MoveInDirection(_direction);
    }

    public virtual void MoveInDirection(Vector3 targetPosition)
    {
        Vector3 currentPosition = transform.position;

        float step = _moveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(currentPosition, targetPosition, step);
    }
}
