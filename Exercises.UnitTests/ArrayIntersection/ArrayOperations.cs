using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayUtilities
{
    public interface IArrayOperations
    {
      int[]  GetArrayIntersection(int[] firstArray, int[] secondArray);
    }

    public class ArrayOperations : IArrayOperations
    {
        /// <summary>
        /// Method with two array of integer in input that return intersection
        /// </summary>
        /// <param name="firstArray">First array to intersect</param>
        /// <param name="secondArray">Second array to intersect</param>
        /// <returns>array intersection</returns>
        public int[] GetArrayIntersection(int[] firstArray, int[] secondArray)
        {
            if (firstArray != null && secondArray != null)
            {
                var result = firstArray.Intersect(secondArray).ToArray();
                return result;
            }
            return new int[0];
        }
    }
}
