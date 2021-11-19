﻿using FluentAssertions;
using RobotCleanerLibrary;
using Xunit;

namespace RobotCleanerUnitTests
{
    public class TheRobotCleanerShould
    {
        [Fact]
        public void Return0_WhenStartAt_1_1_And_CommandsAreNull()
        {
            //Arrange
            var initialPosition = new Position(1, 1);
            var robotCleaner = new RobotCleaner(initialPosition);
            string[] commands = null;

            //Act
            var places = robotCleaner.Clean(commands);

            //Assert
            places.Should().Be(0);

        }

        [Fact]
        public void Return2_WhenStartAt_1_1_And_CommandsAreE1()
        {
            //Arrange
            var initialPosition = new Position(1, 1);
            var robotCleaner = new RobotCleaner(initialPosition);
            string[] commands = { "E 1" };

            //Act
            var places = robotCleaner.Clean(commands);

            //Assert
            places.Should().Be(2);

        }

        [Fact]
        public void Return3_WhenStartAt_10_20_And_CommandsAreE2()
        {
            //Arrange
            var initialPosition = new Position(10, 22);
            var robotCleaner = new RobotCleaner(initialPosition);
            string[] commands = { "E 2" };

            //Act
            var places = robotCleaner.Clean(commands);

            //Assert
            places.Should().Be(3);
        }

        [Fact]
        public void Return5_WhenStartAt_10_20_And_CommandsAreE4()
        {
            //Arrange
            var initialPosition = new Position(10, 22);
            var robotCleaner = new RobotCleaner(initialPosition);
            string[] commands = { "E 4" };

            //Act
            var places = robotCleaner.Clean(commands);

            //Assert
            places.Should().Be(5);
        }

        [Fact]
        public void Return10_WhenStartAt_12_18_And_CommandsAreE9()
        {
            //Arrange
            var initialPosition = new Position(12, 18);
            var robotCleaner = new RobotCleaner(initialPosition);
            string[] commands = { "E 9" };

            //Act
            var places = robotCleaner.Clean(commands);

            //Assert
            places.Should().Be(10);
        }

        [Theory]
        [InlineData(12, 18, "E 9", 10)]
        [InlineData(10, 22, "E 4", 5)]
        [InlineData(1, 1, "E 100000", 100000)]
        [InlineData(10, 22, "E 100000", 100000 - 10 + 1)] //the current position 10 has to be counted although the robot was not be able to move more over boundary
        public void ReturnExpectedNumberOfCleanedPlaces_WhenMoveEast(int startingX, int staringY, string commandEast, int expectedResult)
        {
            //Arrange
            var initialPosition = new Position(startingX, staringY);
            var robotCleaner = new RobotCleaner(initialPosition);
            string[] commands = { commandEast };

            //Act
            var places = robotCleaner.Clean(commands);

            //Assert
            places.Should().Be(expectedResult);
        }


        [Fact]
        public void Return1_WhenStartAt_10_1_And_CommandsAreW0()
        {
            //Arrange
            var initialPosition = new Position(10, 1);
            var robotCleaner = new RobotCleaner(initialPosition);
            string[] commands = { "W 0" };

            //Act
            var places = robotCleaner.Clean(commands);

            //Assert
            places.Should().Be(1);
        }

        [Fact]
        public void Return5_WhenStartAt_10_22_And_CommandsAreW4()
        {
            //Arrange
            var initialPosition = new Position(10, 22);
            var robotCleaner = new RobotCleaner(initialPosition);
            string[] commands = { "W 4" };

            //Act
            var places = robotCleaner.Clean(commands);

            //Assert
            places.Should().Be(5);
        }


    }
}
