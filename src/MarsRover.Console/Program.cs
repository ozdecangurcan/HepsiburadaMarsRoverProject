using MarsRover.Application.Dtos.Request;
using MarsRover.Application.Extensions;
using MarsRover.Application.Interfaces.Services;
using MarsRover.Domain.Enums;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace MarsRover.ConsoleApp
{
    class Program
    {
        static IRoverService _roverService;
        static IPlateauService _plateauService;
        static IDeploymentPointService _deploymentPointService;
        static void Main(string[] args)
        {
            var serviceProvider = ServiceProviderHelper.GetServiceProvider();

            _roverService = serviceProvider.GetService<IRoverService>();
            _plateauService = serviceProvider.GetService<IPlateauService>();
            _deploymentPointService = serviceProvider.GetService<IDeploymentPointService>();

            StartRover();
        }

        private static void StartRover()
        {
            Console.WriteLine("Mars Rover Started\n");

            Console.WriteLine("Enter Plateau Parameter (Exp:5 5) : ");

            var plateauParameters = Console.ReadLine().ToUpper().ConvertToStringList();

            var plateauResponse = _plateauService.CreatePlateau(
                new PlateauRequestDto(plateauParameters));

            if (!plateauResponse.IsSuccess)
            {
                Console.WriteLine($"{plateauResponse.Message}");
                Environment.Exit(0);
            }

            Console.WriteLine("Enter rover deployment point of plateau parameter: (Exp: 1 2 N)");

            var deploymentPointParameters = Console.ReadLine().ToUpper().ConvertToStringList();

            var deploymentPointResponse = _deploymentPointService.PrepareDeploymentPoint(new DeploymentPointRequestDto(deploymentPointParameters, plateauResponse));

            if (!deploymentPointResponse.IsSuccess)
            {
                Console.WriteLine($"{deploymentPointResponse.Message}");
                Environment.Exit(0);
            }

            Console.WriteLine("Enter rover movement parameter: (Exp: LMLMLMLMM)");

            var movementParameters = Console.ReadLine().ToUpper();

            if (!movementParameters.CheckMovementParameters())
            {
                Console.WriteLine($"Invalid parameters of movement");
                Environment.Exit(0);
            }

            var movements = movementParameters.ToCharArray()
                .Select(x => Enum.Parse<Moves>(x.ToString())).ToList();

            var roverRequest = new RoverRequestDto
            {
                DeploymentPointResponse = deploymentPointResponse,
                PlateauResponse = plateauResponse,
                Movements = movements
            };

            var roverResponse = _roverService.CalculateMovement(roverRequest);

            if (!roverResponse.IsSuccess)
            {
                Console.WriteLine($"{roverResponse.Message}");
                Environment.Exit(0);
            }
            else
            {
                var roverResult = roverResponse.Rover;

                Console.WriteLine($"Last Position: {roverResult.DeploymentPoint.X} {roverResult.DeploymentPoint.Y} {roverResult.DeploymentPoint.Direction}");

                Environment.Exit(0);
            }
        }
    }
}
