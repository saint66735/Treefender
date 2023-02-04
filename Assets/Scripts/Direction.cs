using UnityEngine;
using UnityEngine.PlayerLoop;

namespace UnityTemplateProjects
{
    public class Direction
    {
        public enum rootDirection
        {
            Up,
            Down,
            Left,
            Right
        }

        public static rootDirection GetFacingDirection(Vector3 currentPoint, Vector3 newPoint)
        {
            if (currentPoint + Vector3.left == newPoint)
                return rootDirection.Left;
            if (currentPoint + Vector3.right == newPoint)
                return rootDirection.Right;
            if (currentPoint + Vector3.down == newPoint)
                return rootDirection.Down;
            return rootDirection.Up;
        }

        public static Quaternion GetQuaternionFromDirection(rootDirection facing, rootDirection turn)
        {
            switch (facing)
            {
                case rootDirection.Down:
                {
                    switch (turn)
                    {
                        case rootDirection.Left:
                        {
                            return Quaternion.Euler(0, 0, 90f);
                        }
                        case rootDirection.Right:
                        {
                            return Quaternion.Euler(0, 0, -180f);
                        }
                    }
                    break;
                }
                case rootDirection.Left:
                {
                    switch (turn)
                    {
                        case rootDirection.Right:
                        {
                            return Quaternion.Euler(0, 0, 90f);
                        }
                        case rootDirection.Down:
                        case rootDirection.Up:
                        {
                            return Quaternion.Euler(0, 0, 90f);
                        }    
                    }
                    break;
                }
                case rootDirection.Right:
                {
                    switch (turn)
                    {
                        case rootDirection.Left:
                        {
                            return Quaternion.Euler(0, 0, -180f);
                        }
                        case rootDirection.Right:
                        {
                            return Quaternion.Euler(0, 0, -90f);
                        }
                        case rootDirection.Down:
                        case rootDirection.Up:
                        {
                            return Quaternion.Euler(0, 0, -90f);
                        }    
                    }

                    break;
                }
                case rootDirection.Up:
                {
                    switch (turn)
                    {
                        case rootDirection.Left:
                        {
                            return Quaternion.Euler(0, 0, -90f);
                        }
                    }
                    break;
                }
            }

            return Quaternion.identity;
        }

        public static rootDirection GetTurnDirection(rootDirection facing, Vector3 currentPoint, Vector3 newPoint)
        {
            switch (facing)
            {
                case rootDirection.Down:
                {
                    if (currentPoint + Vector3.right == newPoint)
                    {
                        return rootDirection.Right;
                    }
                    if (currentPoint + Vector3.left == newPoint)
                        return rootDirection.Left;
                    if (currentPoint + Vector3.down == newPoint)
                        return rootDirection.Down;
                    break;
                }
                case rootDirection.Left:
                {
                    if (currentPoint + Vector3.up == newPoint)
                        return rootDirection.Left;
                    if (currentPoint + Vector3.left == newPoint)
                        return rootDirection.Down;
                    if (currentPoint + Vector3.down == newPoint)
                        return rootDirection.Right;
                    break;
                }
                case rootDirection.Right:
                {
                    if (currentPoint + Vector3.up == newPoint)
                        return rootDirection.Right;
                    if (currentPoint + Vector3.right == newPoint)
                        return rootDirection.Down;
                    if (currentPoint + Vector3.down == newPoint)
                        return rootDirection.Left;
                    break;
                }
                case rootDirection.Up:
                {
                    if (currentPoint + Vector3.up == newPoint)
                        return rootDirection.Up;
                    if (currentPoint + Vector3.right == newPoint)
                        return rootDirection.Left;
                    if (currentPoint + Vector3.left == newPoint)
                        return rootDirection.Right;
                    break;
                }
            }
            return rootDirection.Down;
        }
    }
}