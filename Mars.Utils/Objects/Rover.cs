using Mars.Utils.Constants;
using System;

namespace Mars.Utils.Objects
{
    public class Rover
    {
        public CompassDirectionEnum FacingDirection { get; set; }

        public Coordinate Coordinates { get; set; }

        private void Rotate(char action)
        {
            if (FacingDirection.Equals(CompassDirectionEnum.N))
            {
                switch (action)
                {
                    case NasaActionConstants.SPIN_90_DEGREES_LEFT:
                        FacingDirection = CompassDirectionEnum.W;
                        break;
                    case NasaActionConstants.SPIN_90_DEGREES_RIGHT:
                        FacingDirection = CompassDirectionEnum.E;
                        break;
                    default:
                        Coordinates.Y++;
                        break;
                }
            }
            else if (FacingDirection.Equals(CompassDirectionEnum.S))
            {
                switch (action)
                {
                    case NasaActionConstants.SPIN_90_DEGREES_LEFT:
                        FacingDirection = CompassDirectionEnum.E;
                        break;
                    case NasaActionConstants.SPIN_90_DEGREES_RIGHT:
                        FacingDirection = CompassDirectionEnum.W;
                        break;
                    default:
                        Coordinates.Y--;
                        break;
                }
            }
            else if (FacingDirection.Equals(CompassDirectionEnum.E))
            {
                switch (action)
                {
                    case NasaActionConstants.SPIN_90_DEGREES_LEFT:
                        FacingDirection = CompassDirectionEnum.N;
                        break;
                    case NasaActionConstants.SPIN_90_DEGREES_RIGHT:
                        FacingDirection = CompassDirectionEnum.S;
                        break;
                    default:
                        Coordinates.X++;
                        break;
                }
            }
            else
            {
                switch (action)
                {
                    case NasaActionConstants.SPIN_90_DEGREES_LEFT:
                        FacingDirection = CompassDirectionEnum.S;
                        break;
                    case NasaActionConstants.SPIN_90_DEGREES_RIGHT:
                        FacingDirection = CompassDirectionEnum.N;
                        break;
                    default:
                        Coordinates.X--;
                        break;
                }
            }
        }

        public void Navigate(Coordinate upperRightCoordinates, string actionString)
        {
            foreach (var action in actionString)
                Rotate(action);
            if (upperRightCoordinates.X < Coordinates.X || upperRightCoordinates.Y < Coordinates.Y || Coordinates.X < decimal.Zero)
                throw new Exception("Position must be between (0,0) - (" + upperRightCoordinates.X + "," + upperRightCoordinates.Y + ")");
        }

    }
}
