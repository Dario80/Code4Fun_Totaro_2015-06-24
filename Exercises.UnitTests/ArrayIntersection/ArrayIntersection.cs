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


            return new int[0];
        }
    }
}
