using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WGPackage.Rendering.DynamicDensityMap.Helpers
{
    public static class MathExtensions
    {
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

        public static List<int> GetCommonNumbers ( List<int> p1, List<int> p2 )
        {
            return p1.Intersect ( p2 ).ToList ();
        }
    }
}
