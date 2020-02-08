using System.Linq;
using System.Numerics;

namespace VectorizedComputationsAndSimd
{
    public static class ArrayOperations
    {
        public static int LinqSum(int[] array)
        {
            return array.Sum();
        }
        
        public static int NaiveSum(int[] array)
        {
            var result = 0;
            for (var i = 0; i < array.Length; i++)
            {
                result += array[i];
            }

            return result;
        }
        
        public static int SimdSum(int[] array)
        {
            var vector = Vector<int>.Zero;
            var i = 0;
            for (; i <= array.Length - Vector<int>.Count; i += Vector<int>.Count)
            {
                vector += new Vector<int>(array, i);
            }

            var result = 0;
            for (var j = 0; j < Vector<int>.Count; j++)
            {
                result += vector[j];
            }

            for (; i < array.Length; i++)
            {
                result += array[i];
            }

            return result;
        }
    }
}