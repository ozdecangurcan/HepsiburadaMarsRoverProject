using MarsRover.Domain.Enums;
using System;
using System.Collections.Generic;

namespace MarsRover.Application.Extensions
{
    public static class DeploymentExtensions
    {
        /// <summary>
        /// Check rover deployment on plateau parameters is valid
        /// </summary>
        /// <param name="deploymentPoint"></param>
        /// <returns></returns>
        public static bool CheckDeploymentPointParameters(this List<string> deploymentPoint)
        {
            if (deploymentPoint.Count != 3)
            {
                return false;
            }

            var isFirstValueValid = int.TryParse(deploymentPoint[0], out int x);
            var isSecondValueValid = int.TryParse(deploymentPoint[1], out int y);
            _ = Enum.TryParse(deploymentPoint[2], out Directions direction);

            if (x < 0 || y < 0 || direction == 0 || !isFirstValueValid || !isSecondValueValid)
            {
                return false;
            }

            return true;
        }
    }
}
