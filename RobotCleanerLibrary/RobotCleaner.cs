using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotCleanerLibrary
{
    public enum Direction
    {
        Right,
        Left,
        Up,
        Down,
        NoOne
    }

    public partial class RobotCleaner
    {
        private int maximumSteps = 100000;
        private int minimumSteps = 0;
        private int maxValueXPosition = 100000;
        private int maxValueYPosition = 100000;
        private int minValueXPosition = -100000;
        private int minValueYPosition = -100000;
        
        private Position currentPosition;
        public string[] commandsToExecute;
        List<Position> listOfVisitedPlaces;

        public Position CurrentPosition { get { return currentPosition; } }
        IDirection currentDirection;

        public RobotCleaner(Position initialPosition)
        {
            var x=initialPosition.x;
            var y=initialPosition.y;
            
            if (initialPosition.x > maxValueXPosition) x = maxValueXPosition;
            if (initialPosition.y > maxValueYPosition) y = maxValueYPosition;
            if (initialPosition.x < minValueXPosition) x = minValueXPosition;
            if (initialPosition.y < minValueYPosition) y = minValueYPosition;

            this.currentPosition = new Position(x, y);
            
        }

        public int Clean(string[] commands)
        {
            if (commands != null)
            { 
                commandsToExecute = commands;
                if (commands.Length>0)
                {
                    var commandProcessor = new CommandProcessor();
                    commandProcessor.ParseCommands(commandsToExecute);
                    foreach(Command command in commandProcessor.ListOfCommands)
                    {
                        var stepsAsInt = int.Parse(command.Steps);
                        if (stepsAsInt < minimumSteps) stepsAsInt = minimumSteps;
                        if (stepsAsInt > maximumSteps) stepsAsInt = maximumSteps;

                        this.currentDirection = DirectionFactory.CreateDirectionFrom(command.Direction);

                        AddVisitedPlacesToList(this.currentPosition, this.currentPosition);

                        var newPosition = this.currentDirection.MoveForward(this.currentPosition, stepsAsInt);

                        AddVisitedPlacesToList(this.currentPosition, newPosition);

                        this.currentPosition = newPosition;
                    }
                }
            }
            var placesCleaned = CalculateCleanedPlaces();
            return placesCleaned;
        }

        private Direction CalculateDirectionToAdd(Position startPosition, Position endPosition)
        {
            var direction = Direction.NoOne;
            var diffX = endPosition.x - startPosition.x;
            var diffY = endPosition.y - startPosition.y;

            if (diffX > 0) direction = Direction.Right;
            if (diffX < 0) direction =  Direction.Left;
            if (diffY > 0) direction = Direction.Down;
            if (diffY < 0) direction = Direction.Up;

            return direction;

        }

        private void AddVisitedPlacesToList(Position startPosition, Position endPosition)
        {
            if (this.listOfVisitedPlaces == null)
            {
                this.listOfVisitedPlaces = new List<Position>();
            }

            var directionToAdd=CalculateDirectionToAdd(startPosition, endPosition);
            
            if (directionToAdd==Direction.NoOne)
            {
                AddCurrentPosition(startPosition.x, startPosition.y);
            }
            else
            {
                if (directionToAdd == Direction.Down)  AddPositionsToTheDown(startPosition.y, endPosition.y, endPosition.x);
                if (directionToAdd == Direction.Up) AddPositionsToTheUp(startPosition.y, endPosition.y, endPosition.x);
                if (directionToAdd == Direction.Right) AddPositionsToTheRight(startPosition.x, endPosition.x, endPosition.y);
                if (directionToAdd == Direction.Left) AddPositionsToTheLeft(startPosition.x, endPosition.x, endPosition.y);
            }
        }

        private void AddCurrentPosition(int startX, int startY)
        {
            var newPosition = new Position(startX, startY);
            if (PositionDoesNotExistInList(newPosition))
            {
                this.listOfVisitedPlaces.Add(newPosition);
            }
        }

        private void AddPositionsToTheUp(int startY, int endY, int currentX)
        {
            var startAt = startY - 1;
            for (int i = startAt; i >= endY; i--)
            {
                var newPosition = new Position(currentX, i);
                if (PositionDoesNotExistInList(newPosition))
                {
                    this.listOfVisitedPlaces.Add(newPosition);
                }
            }
        }

        private void AddPositionsToTheDown(int startY, int endY, int currentX)
        {
            var startAt = startY + 1;
            for (int i = startAt; i <= endY; i++)
            {
                var newPosition = new Position(currentX, i);
                if (PositionDoesNotExistInList(newPosition))
                {
                    this.listOfVisitedPlaces.Add(newPosition);
                }
            }
        }

        private void AddPositionsToTheRight(int startX, int endX, int currentY)
        {
            var startAt = startX + 1;
            for (int i = startAt; i <= endX; i++)
            {
                var newPosition = new Position(i, currentY);
                if (PositionDoesNotExistInList(newPosition))
                {
                    this.listOfVisitedPlaces.Add(newPosition);
                }
            }
        }
        
        private void AddPositionsToTheLeft(int startX, int endX, int currentY)
        {
            var startAt = startX - 1;
            for (int i = startAt; i >= endX; i--)
            {
                var newPosition = new Position(i, currentY);
                if (PositionDoesNotExistInList(newPosition))
                {
                    this.listOfVisitedPlaces.Add(newPosition);
                }
            }
        }

        private bool PositionDoesNotExistInList(Position positionToCheck)
        {
            return !this.listOfVisitedPlaces.Contains(positionToCheck);
        }

        private int CalculateCleanedPlaces()
        {
            if (this.listOfVisitedPlaces == null)  return 0;
            return this.listOfVisitedPlaces.Count;
        }



       

        

    }
}
