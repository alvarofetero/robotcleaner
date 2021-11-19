using System;
using System.Collections.Generic;
using System.Text;

namespace RobotCleanerLibrary
{
    public class Position : IEquatable<Position>
    {
        public int x;
        public int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Equals(Position other)
        {
            return this.x == other.x && this.y == other.y;
        }
    }
}
