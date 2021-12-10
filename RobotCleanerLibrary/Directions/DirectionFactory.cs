using System;

namespace RobotCleanerLibrary
{
    public static class DirectionFactory
    {
        public static IDirection CreateDirectionFrom(string direction)
        {
            switch (direction)
            {
                case "E":
                    return new East();
                    break;
                case "W":
                    return new West();
                    break;
                case "N":
                    return new North();
                    break;
                case "S":
                    return new South();
                    break;
                default:
                    throw new NotSupportedException($"Direction {direction} is not supported.");
            }
        }
    }
}
