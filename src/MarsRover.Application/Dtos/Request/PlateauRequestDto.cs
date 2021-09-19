using System.Collections.Generic;

namespace MarsRover.Application.Dtos.Request
{
    public class PlateauRequestDto
    {
        public PlateauRequestDto(List<string> plateauDimensions)
        {
            PlateauDimensions = plateauDimensions;
        }
        public List<string> PlateauDimensions { get; set; }
    }
}
