using MarsRover.Domain.Enums;
using System.Collections.Generic;

namespace MarsRover.Domain.Entities
{
    public class RoverModel
    {
        public PlateauModel Plateau { get; set; }
        public DeploymentPointModel DeploymentPoint { get; set; }
        public List<Moves> Movements { get; set; }
    }
}
