using FluentAssertions;
using RobotCleanerLibrary;
using Xunit;

namespace RobotCleanerUnitTests
{
    public class TheRobotShoud
    {

        [Theory]
        [InlineData("1", new string[] { "E 1" })]
        [InlineData("2", new string[] { "E 1", "N 5" })]
        [InlineData("3", new string[] { "E 1", "N 5", "S 10" })]
        public void ReturnTrue_GivenFirstInputLine_NumnberOfCommandsIsCorrect(string numberOfCommandInInputLine, string[] inputCommands)
        {
            //Arrange - Given
            var numberOfCommand = int.Parse(numberOfCommandInInputLine);
            var startPosition = new Position(0, 0);
            
            string[] commands = inputCommands;

            var robotCleaner = new RobotCleaner(startPosition);

            //Act - When
            var result = robotCleaner.Clean(numberOfCommand, commands);

            //Assert - Then
            result.Should().Be(numberOfCommandInInputLine);
        }

        [Theory]
        [InlineData("1 1",1,1)]
        [InlineData("20 30", 20, 30)]
        [InlineData("-100000 -100000", -100000, -100000)]
        [InlineData("-200000 -100000", -100000, -100000)]
        [InlineData("-200000 -200000", -100000, -100000)]
        [InlineData("-99999 -100001", -99999, -100000)]
        public void ReturnTrue_GivenSecondInputLine_TheStartingCoordinatesAreCorrect(string secondLine, int xExpected, int yExpected)
        {
            //Arrange - Given
            var secondLineAsArray = secondLine.Split(' ');

            var x = int.Parse(secondLineAsArray[0]);
            var y = int.Parse(secondLineAsArray[1]);
            var startPosition = new Position(x, y);

            var robotCleaner = new RobotCleaner(startPosition);

            //Act - When
            var result = robotCleaner.CurrentPosition;

            //Assert - Then
            result.x.Should().Be(xExpected);
            result.y.Should().Be(yExpected);
        }

        [Theory]
        [InlineData("E 0", 1, 1)]
        [InlineData("E 1", 2, 1)]
        public void ReturnCurrentPositionCorrect_GivenThirdInputLineIs_East_WhenStartPositionIs_1_1(string commandLine, int xExpected, int yExpected)
        {
            //Arrange - Given
            var thirdLine = commandLine;
            string[] commands = { thirdLine };
            var startPosition = new Position(1, 1);
            var robotCleaner = new RobotCleaner(startPosition);

            //Act - When
            var numberOfCommands = robotCleaner.Clean(1, commands);
            var result = robotCleaner.CurrentPosition;

            //Assert - Then
            result.x.Should().Be(xExpected);
            result.y.Should().Be(yExpected);
        }

        [Theory]
        [InlineData("W 0", 1, 1)]
        [InlineData("W 1", 0, 1)]
        public void ReturnCurrentPositionCorrect_GivenThirdInputLineIs_West_WhenStartPositionIs_1_1(string commandLine, int xExpected, int yExpected)
        {
            //Arrange - Given
            var thirdLine = commandLine;
            string[] commands = { thirdLine };
            var startPosition = new Position(1, 1);
            var robotCleaner = new RobotCleaner(startPosition);

            //Act - When
            var numberOfCommands = robotCleaner.Clean(1, commands);
            var result = robotCleaner.CurrentPosition;

            //Assert - Then
            result.x.Should().Be(xExpected);
            result.y.Should().Be(yExpected);
        }


        [Theory]
        [InlineData("N 0", 1, 1)]
        [InlineData("N 1", 1, 0)]
        [InlineData("N 5", 1, -4)]
        [InlineData("N -1", 1, 1)]
        [InlineData("N 100000", 1, -99999)]
        public void ReturnCurrentPositionCorrect_GivenThirdInputLineIs_North_WhenStartPositionIs_1_1(string commandLine, int xExpected, int yExpected)
        {
            //Arrange - Given
            var thirdLine = commandLine;
            string[] commands = { thirdLine };
            var startPosition = new Position(1, 1);
            var robotCleaner = new RobotCleaner(startPosition);

            //Act - When
            var numberOfCommands = robotCleaner.Clean(1, commands);
            var result = robotCleaner.CurrentPosition;

            //Assert - Then
            result.x.Should().Be(xExpected);
            result.y.Should().Be(yExpected);
        }

        [Theory]
        [InlineData("S 0", 1, 1)]
        [InlineData("S 1", 1, 2)]
        [InlineData("S 5", 1, 6)]
        [InlineData("S -1", 1, 1)]
        [InlineData("S 100000", 1, 100001)]
        public void ReturnCurrentPositionCorrect_GivenThirdInputLineIs_South_WhenStartPositionIs_1_1(string commandLine, int xExpected, int yExpected)
        {
            //Arrange - Given
            var thirdLine = commandLine;
            string[] commands = { thirdLine };
            var startPosition = new Position(1, 1);
            var robotCleaner = new RobotCleaner(startPosition);

            //Act - When
            var numberOfCommands = robotCleaner.Clean(1, commands);
            var result = robotCleaner.CurrentPosition;

            //Assert - Then
            result.x.Should().Be(xExpected);
            result.y.Should().Be(yExpected);
        }
    }
}
