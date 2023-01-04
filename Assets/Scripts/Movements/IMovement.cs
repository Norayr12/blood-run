using UnityEngine;

namespace Movements
{
    public interface IMovable
    {
        public void Move(Transform target, Vector3 targetPosition, float speed);
    }
}