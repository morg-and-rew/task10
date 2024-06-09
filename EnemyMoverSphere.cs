using UnityEngine;

public class EnemyMoverSphere : EnemyMover, IMovableInDiraction
{
    public override void MoveInDirection(Vector3 targetPosition)
    {
        base.MoveInDirection(_direction);
    }
}