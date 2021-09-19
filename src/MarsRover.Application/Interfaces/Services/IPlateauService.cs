using MarsRover.Application.Dtos;
using MarsRover.Application.Dtos.Request;

namespace MarsRover.Application.Interfaces.Services
{
    public interface IPlateauService
    {
        /// <summary>
        /// Create Mars plateau
        /// </summary>
        /// <param name="plateauRequest"></param>
        /// <returns></returns>
        PlateauResponseDto CreatePlateau(PlateauRequestDto plateauRequest);
    }
}
