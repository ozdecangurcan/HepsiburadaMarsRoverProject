using MarsRover.Domain.Enums;
using System;

namespace MarsRover.Application.Extensions
{
    public static class RoverExtension
    {
        /// <summary>
        /// Check Movements Parameters is Valid
        /// </summary>
        /// <param name="movements"></param>
        /// <returns></returns>
        public static bool CheckMovementParameters(this string movements)
        {
            if (string.IsNullOrWhiteSpace(movements))
            {
                return false;
            }

            movements = movements.Trim();

            var movementArray = movements.ToCharArray();

            foreach (var move in movementArray)
            {
                _ = Enum.TryParse(move.ToString(), out Moves movement);

                if (movement == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
