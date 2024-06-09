using UnityEngine;

public class EnemyMoverCube : EnemyMover, IMovableInDiraction
{
    public override void MoveInDirection(Vector3 targetPosition)
    {
        base.MoveInDirection(_direction);
    }
}