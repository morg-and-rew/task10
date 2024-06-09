using UnityEngine;

public class EnemyMoverCapsule : EnemyMover, IMovableInDiraction
{
    public override void MoveInDirection(Vector3 targetPosition)
    {
        base.MoveInDirection(_direction);
    }

}