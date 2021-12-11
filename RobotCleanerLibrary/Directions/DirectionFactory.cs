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
                case "W":
                    return new West();
                case "N":
                    return new North();
                case "S":
                    return new South();
                default:
                    throw new NotSupportedException($"Direction {direction} is not supported.");
            }
        }
    }
}
