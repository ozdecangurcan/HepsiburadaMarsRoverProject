using MarsRover.Application.Dtos.Request;
using MarsRover.Application.Extensions;
using MarsRover.Infrastructure.Services;
using System.Linq;
using Xunit;

namespace MarsRover.UnitTest
{
    public class PlateauTest
    {
        private readonly PlateauService _plateauService;

        public PlateauTest()
        {
            _plateauService = new PlateauService();
        }

        [Theory]
        [InlineData("5 5")]
        public void CreatePlateau_WhenValidParameters_ReturnSuccess(string plateau)
        {

            var plateauValue = plateau.ConvertToStringList();
            var request = new PlateauRequestDto(plateauValue);

            var result = _plateauService.CreatePlateau(request);

            Assert.True(result.IsSuccess);
            Assert.Equal(result.Plateau.Width, int.Parse(plateauValue.First()));
            Assert.Equal(result.Plateau.Height, int.Parse(plateauValue.Last()));
            Assert.Null(result.Message);
        }

        [Theory]
        [InlineData("0 5")]
        [InlineData("0 5 3")]
        [InlineData("5 A")]
        [InlineData("A 5")]
        [InlineData("A A")]
        [InlineData("5 0")]
        [InlineData("0 0")]
        [InlineData("")]
        public void CreatePlateau_WhenInvalidParameters_ReturnError(string plateau)
        {

            var plateauValue = plateau.ConvertToStringList();
            var request = new PlateauRequestDto(plateauValue);

            var result = _plateauService.CreatePlateau(request);

            Assert.False(result.IsSuccess);
            Assert.Null(result.Plateau);
            Assert.NotNull(result.Message);
        }
    }
}
