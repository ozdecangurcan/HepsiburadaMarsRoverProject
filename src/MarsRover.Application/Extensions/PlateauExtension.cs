using System.Collections.Generic;

namespace MarsRover.Application.Extensions
{
    public static class PlateauExtension
    {
        /// <summary>
        /// Check Draw Plateau Parameters is Valid
        /// </summary>
        /// <param name="plateau"></param>
        /// <returns></returns>
        public static bool CheckDrawPlateauParameters(this List<string> plateau)
        {
            if (plateau.Count != 2)
            {
                return false;
            }

            _ = int.TryParse(plateau[0], out int width);
            _ = int.TryParse(plateau[1], out int height);

            if (width == 0 || height == 0)
            {
                return false;
            }

            return true;
        }
    }
}
