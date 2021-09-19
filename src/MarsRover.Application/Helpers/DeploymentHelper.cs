namespace MarsRover.Application.Helpers
{
    public static class DeploymentHelper
    {
        /// <summary>
        /// Check deployment point is valid on plateau
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool CheckDeploymentPoint(int width, int height, int x, int y)
        {
            if (width < x || height < y)
                return false;

            return true;
        }
    }
}
