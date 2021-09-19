using System.Collections.Generic;

namespace MarsRover.UnitTest.MockData
{
    public class PlateauMockData
    {
        public PlateauMockData()
        {
            Coordinates = new List<Coordinate>();
        }
        public List<Coordinate> Coordinates { get; set; }
    }

    public class Coordinate
    {
        public Coordinate()
        {
            CoordinateParameters = new List<string>();
        }
        public List<string> CoordinateParameters { get; set; }
    }
}
