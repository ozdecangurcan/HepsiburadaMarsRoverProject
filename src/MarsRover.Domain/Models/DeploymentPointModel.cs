using MarsRover.Domain.Enums;

namespace MarsRover.Domain.Entities
{
    public class DeploymentPointModel
    {
        public DeploymentPointModel(int x, int y, Directions direction)
        {
            X = x;
            Y = y;
            Direction = direction;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Directions Direction { get; set; }
    }
}
