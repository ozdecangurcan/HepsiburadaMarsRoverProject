using MarsRover.Application.Dtos;
using MarsRover.Application.Dtos.Request;
using MarsRover.Application.Extensions;
using MarsRover.Application.Interfaces.Services;
using MarsRover.Domain.Entities;
using System.Linq;

namespace MarsRover.Infrastructure.Services
{
    public class PlateauService : IPlateauService
    {
        public PlateauResponseDto CreatePlateau(PlateauRequestDto plateauRequest)
        {
            if (!plateauRequest.PlateauDimensions.CheckDrawPlateauParameters())
            {
                return new PlateauResponseDto
                {
                    IsSuccess = false,
                    Message = "Invalid parameters for drawing plateau"
                };
            }

            var width = int.Parse(plateauRequest.PlateauDimensions.First());

            var height = int.Parse(plateauRequest.PlateauDimensions.Last());

            var plateau = new PlateauModel(width, height);

            return new PlateauResponseDto { Plateau = plateau, IsSuccess = true };
        }
    }
}
