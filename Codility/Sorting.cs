using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Codility
{
    public class Sorting
    {
        public static int NumberOfDiscIntersections(int[] A) 
        {
            // The force forward solution which is O(N^2) complexity
            /*
            int intersections = 0;
            int n = A.Length;
            for (long i = 0; i < n - 1; i++)
            {
                for (long j = i + 1; j < n; j++)
                {
                    if (i + A[i] >= j - A[j] && i - A[i] <= j + A[j])
                    {
                        if (intersections == 10E6)
                        {
                            return -1;
                        }
                        else
                        {
                            intersections++;
                        }
                    }
                }
            }
            return intersections; */

            // O(N*log(N)) complexity by using sorting
            long n = A.Length;
            if (n < 2) 
            {
                return 0;
            }

            long intersecs = n * (n - 1) / 2; // max possible intersects between n discs: (n-1)+(n-2)+...3+2+1 = n*(n-1)/2
            long[] highValue = new long[n]; // high x values
            long[] lowValue = new long[n]; // low x values
            for (long i = 0; i < n; i++) 
            {
                highValue[i] = i + A[i];
                lowValue[i] = i - A[i];
            }
            Array.Sort(highValue);
            Array.Sort(lowValue);

            int j = 0; // initialize inner iteration only once
            for (int i = 0; i < n; i++) 
            {
                for (; j < n; j++) 
                {
                    if (lowValue[j] > highValue[i]) // discs dont intersect when low > high (x values)
                    {
                        intersecs -= n - j; // remove all discs where low > high
                        break;
                    }
                }

                if (j == n) // no more low values greater than high values
                {
                    break;
                }
            }

            if (intersecs > 10E6) // if number of intersects greater than 10,000,000
            {
                return -1;
            }
            return (int) intersecs;
        }
    }
}
