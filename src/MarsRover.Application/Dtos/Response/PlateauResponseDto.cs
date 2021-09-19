using MarsRover.Domain.Entities;

namespace MarsRover.Application.Dtos
{
    public class PlateauResponseDto : BaseDto
    {
        public PlateauModel Plateau { get; set; }
    }
}
