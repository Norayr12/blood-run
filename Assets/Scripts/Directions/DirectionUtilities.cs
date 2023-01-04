using UnityEngine;

namespace Directions
{
    public static class DirectionUtilities
    {
        public static Direction Vector2DIntToDirection(Vector2Int vector2Int)
        {
            if (vector2Int == Vector2Int.right)
                return Direction.Right;
            if (vector2Int == Vector2Int.left)
                return Direction.Left;
            if (vector2Int == Vector2Int.up)
                return Direction.Up;
            if (vector2Int == Vector2Int.down)
                return Direction.Down;
            return Direction.None;
        }

        public static float DirectionToAngle(Direction direction)
        {
            switch (direction)
            {
                case Direction.Right:
                    return 0;
                case Direction.Left:
                    return 180;
                case Direction.Up:
                    return 90;
                case Direction.Down:
                    return 270;
                default:
                    return 0;
            }
        }
    }
}