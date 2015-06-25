using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayOperations
{
    public interface IIntersection
    {
      int[]  GetArrayIntersection(int[] firstArray, int[] secondArray);
    }

    public class Intersection : IIntersection
    {

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
