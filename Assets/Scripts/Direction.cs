using UnityEngine;
using UnityEngine.PlayerLoop;

namespace UnityTemplateProjects
{
    public class Direction
    {
        public enum RootDirection
        {
            Up,
            Down,
            Left,
            Right
        }

        public static RootDirection GetFacingDirection(Vector3 currentPoint, Vector3 newPoint)
        {
            if (currentPoint + Vector3.left == newPoint)
                return RootDirection.Left;
            if (currentPoint + Vector3.right == newPoint)
                return RootDirection.Right;
            if (currentPoint + Vector3.down == newPoint)
                return RootDirection.Down;
            return RootDirection.Up;
        }
        
        public static float GetRotation(RootDirection facing, RootDirection turn) => facing switch
        {
            RootDirection.Down => turn switch
            {
                RootDirection.Left => 90f,
                RootDirection.Right => -180f,
                _ => 0,
            },
            RootDirection.Left => turn switch
            {
                RootDirection.Right => 90f,
                RootDirection.Down => 90f,
                RootDirection.Up => 90f,
                _ => 0,
            },
            RootDirection.Right => turn switch
            {
                RootDirection.Left => -180f,
                RootDirection.Right => -90f,
                _ => -90f,
            },
            RootDirection.Up => turn switch
            {
                RootDirection.Left => -90f,
                _ => 0,
            }
        };

        public static RootDirection GetTurnDirection(RootDirection facing, Vector3 currentPoint, Vector3 newPoint)
        {
            switch (facing)
            {
                case RootDirection.Down:
                {
                    if (currentPoint + Vector3.right == newPoint)
                    {
                        return RootDirection.Right;
                    }
                    if (currentPoint + Vector3.left == newPoint)
                        return RootDirection.Left;
                    if (currentPoint + Vector3.down == newPoint)
                        return RootDirection.Down;
                    break;
                }
                case RootDirection.Left:
                {
                    if (currentPoint + Vector3.up == newPoint)
                        return RootDirection.Left;
                    if (currentPoint + Vector3.left == newPoint)
                        return RootDirection.Down;
                    if (currentPoint + Vector3.down == newPoint)
                        return RootDirection.Right;
                    break;
                }
                case RootDirection.Right:
                {
                    if (currentPoint + Vector3.up == newPoint)
                        return RootDirection.Right;
                    if (currentPoint + Vector3.right == newPoint)
                        return RootDirection.Down;
                    if (currentPoint + Vector3.down == newPoint)
                        return RootDirection.Left;
                    break;
                }
                case RootDirection.Up:
                {
                    if (currentPoint + Vector3.up == newPoint)
                        return RootDirection.Up;
                    if (currentPoint + Vector3.right == newPoint)
                        return RootDirection.Left;
                    if (currentPoint + Vector3.left == newPoint)
                        return RootDirection.Right;
                    break;
                }
            }
            return RootDirection.Down;
        }
    }
}