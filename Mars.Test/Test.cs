using Mars.Utils;
using Mars.Utils.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Mars.Test
{
    [TestClass]
    public class Test
    {
        [DynamicData(nameof(GetTestData), DynamicDataSourceType.Method)]
        [TestMethod]
        public void MainTest(string actionString, Rover rover, Coordinate upperRightCoordinates, string correctResult)
        {
            rover.Navigate(upperRightCoordinates, actionString);
            var result = $"{rover.Coordinates.X} {rover.Coordinates.Y} {rover.FacingDirection}";
            Assert.AreEqual(correctResult, result);
        }

        public static IEnumerable<object[]> GetTestData()
        {
            yield return new object[]
            {
                "LMLMLMLMM",
                new Rover
                {
                    Coordinates = new Coordinate { X = 1, Y = 2 },
                    FacingDirection = CompassDirectionEnum.N
                },
                new Coordinate { X = 5, Y = 5 },
                "1 3 N"
            };
            yield return new object[]
            {
                "MMRMMRMRRM",
                new Rover
                {
                    Coordinates = new Coordinate { X = 3, Y = 3 },
                    FacingDirection = CompassDirectionEnum.E
                },
                new Coordinate { X = 5, Y = 5 },
                "5 1 E"
            };
        }

    }
}

