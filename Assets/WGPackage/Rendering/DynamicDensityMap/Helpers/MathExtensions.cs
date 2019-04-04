using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGPackage.Rendering.DynamicDensityMap.Helpers
{
    public static class MathExtensions
    {
        /// <summary>
        /// Gets all divisors, that the input number can be divided by, and produce a whole number.
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static List<int> GetAllDivisors ( int number )
        {
            List<int> d = new List<int> ();
            int i = 1;
            while ( number != i )
            {
                if ( number % i == 0 )
                    d.Add ( i );
                i++;
            }
            d.Add ( number );
            return d;
        }

        /// <summary>
        /// Returns an array with common numbers from two input arrays.
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static List<int> GetCommonNumbers ( List<int> p1, List<int> p2 )
        {
            return p1.Intersect ( p2 ).ToList ();
        }
    }
}
