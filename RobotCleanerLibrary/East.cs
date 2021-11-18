namespace RobotCleanerLibrary
{
    public class East : IDirection
    {
        public Position MoveForward(Position position, int numberOfSteps)
        {
            position.x += numberOfSteps;
            return position;
        }
    }

}
