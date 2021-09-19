using System.Collections.Generic;
using System.Linq;

namespace MarsRover.Application.Extensions
{
    public static class ListExtension
    {
        /// <summary>
        /// Convert a string to list of string
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public static List<string> ConvertToStringList(this string item)
        {
            return item.Trim().Split(' ').ToList();
        }
    }
}
