using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotCleanerLibrary
{
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
                    var currentCommand=commands[0].Split(' ');
                    var directionFromInput = currentCommand[0];
                    var steps = currentCommand[1];
                    var stepsAsInt = int.Parse(steps);
                    if (stepsAsInt < minimumSteps) stepsAsInt = minimumSteps;
                    if (stepsAsInt > maximumSteps) stepsAsInt = maximumSteps;

                    this.currentDirection= DirectionFactory.CreateDirectionFrom(directionFromInput);
                    
                    AddVisitedPlacesToList(this.currentPosition, this.currentPosition);

                    var newPosition = this.currentDirection.MoveForward(this.currentPosition, stepsAsInt);

                    AddVisitedPlacesToList(this.currentPosition, newPosition);

                    this.currentPosition = newPosition;
                }
            }
            var placesCleaned = CalculateCleanedPlaces();
            return placesCleaned;
        }

        private void AddVisitedPlacesToList(Position startPosition, Position endPosition)
        {
            if (this.listOfVisitedPlaces == null)
            {
                this.listOfVisitedPlaces = new List<Position>();
            }
        
            Position newPosition;
            var diffX = endPosition.x - startPosition.x;
            var diffY = endPosition.y - startPosition.y;

            var tempX = 0;
            var tempY = 0;


            if (diffX == 0 && diffY ==0)
            {
                newPosition = new Position(startPosition.x,startPosition.y);
                if (PositionDoesNotExistInList(newPosition))
                {
                    this.listOfVisitedPlaces.Add(newPosition);
                }
                
            }

            if (diffY == 0)
            {
                tempY = endPosition.y;
            }

            if (diffX==0)
            {
                tempX = endPosition.x;
            }
            else
            {
               if (diffX > 0)
               {
                    var startAt = startPosition.x + 1;
                    for (int i=startAt; i<=endPosition.x; i++)
                    {
                        newPosition = new Position(i, tempY);
                        if (PositionDoesNotExistInList(newPosition))
                        {
                            this.listOfVisitedPlaces.Add(newPosition);
                        }
                        
                    }
               }
               if (diffX<0)
               {
                    var startAt = startPosition.x -1;
                    for (int i = startAt; i >= endPosition.x; i--)
                    {
                        newPosition = new Position(i, tempY);
                        if (PositionDoesNotExistInList(newPosition))
                        {
                            this.listOfVisitedPlaces.Add(newPosition);
                        }

                    }
                }
            }
        }

        private bool PositionDoesNotExistInList(Position positionToCheck)
        {
            return !this.listOfVisitedPlaces.Contains(positionToCheck);
        }

        private int CalculateCleanedPlaces()
        {
            if (this.listOfVisitedPlaces == null)
                return 0;
            return this.listOfVisitedPlaces.Count;
        }



       

        

    }
}
