using Mars.Utils;
using Mars.Utils.Extensions;
using Mars.Utils.Objects;
using System;
using System.Linq;

namespace Mars.ConsoleApp
{
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Please enter the upper-right coordinates of the pleteau:");
            var upperRightCoordinatesInput = Console.ReadLine().Trim().Split(' ').ToList();
            var upperRightCoordinates = new Coordinate
            {
                X = upperRightCoordinatesInput.First().ToDecimal(),
                Y = upperRightCoordinatesInput.ElementAt(1).ToDecimal()
            };
            for (var i = 1; ; i++)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine($"Please enter the initial position of rover #{i}:");
                var roverPositionData = Console.ReadLine().Trim().Split(' ').ToList();
                var rover = new Rover
                {
                    Coordinates = new Coordinate { X = roverPositionData.First().ToDecimal(), Y = roverPositionData.ElementAt(1).ToDecimal() },
                    FacingDirection = (CompassDirectionEnum)Enum.Parse(typeof(CompassDirectionEnum), roverPositionData.ElementAt(2).ToUpper())
                };
                Console.WriteLine(string.Empty);
                Console.WriteLine($"Please enter the navigation data for rover #{i}:");
                var roverNavigationData = Console.ReadLine().ToUpper();
                try
                {
                    rover.Navigate(upperRightCoordinates, roverNavigationData);
                    Console.WriteLine(string.Empty);
                    Console.WriteLine($"Current position of the rover #{i}: \r\n{rover.Coordinates.X} {rover.Coordinates.Y} {rover.FacingDirection}");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
