using UnityEngine;

public class EnemyMoverType2 : EnemyMover, IMovableInDiraction
{
    public override void MoveInDirection(Vector3 targetPosition)
    {
        base.MoveInDirection(_direction);
    }
}