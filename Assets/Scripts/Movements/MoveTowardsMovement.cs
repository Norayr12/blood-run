using UnityEngine;

namespace Movements
{
    public class MoveTowardsMovement : IMovable
    {
        public void Move(Transform target, Vector3 targetPosition, float speed)
        {
            target.position = Vector2.MoveTowards(target.position, targetPosition, speed);
        }
    }
}