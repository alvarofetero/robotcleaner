namespace RobotCleanerLibrary
{
    public class North : IDirection
    {
        private int MinNorthBoundary = -100000;
        public Position MoveForward(Position position, int numberOfSteps)
        {
            return position.y - numberOfSteps < MinNorthBoundary ?
                new Position(position.x, MinNorthBoundary) :
                new Position(position.x, position.y - numberOfSteps);
        }
           
    }
}
