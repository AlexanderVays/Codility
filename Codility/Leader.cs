using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codility
{
    class Leader
    {
        public int solution(int[] A)
        {
            int n = A.Length;
            Dictionary<int, int> result = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int[] firstPart = new int[i + 1];
                int[] secondPart = new int[n - i - 1];
                int firstTop = 0, secondTop = 0;
                Dictionary<int, int> first = new Dictionary<int, int>();
                Dictionary<int, int> second = new Dictionary<int, int>();

                for (int j = 0; j < firstPart.Length; j++)
                {
                    if (!first.ContainsKey(A[j]))
                    {
                        first.Add(A[j], 1);
                    }
                    else
                    {
                        first[A[j]]++;
                    }
                }

                if (first.Count > 0)
                {
                    firstTop = first.OrderByDescending(pair => pair.Value).Take(1).First().Value;
                }

                if (firstTop > first.Count / 2 || i == 0)
                {
                    for (int j = 0; j < firstPart.Length; j++)
                    {
                        if (!second.ContainsKey(A[j]))
                        {
                            second.Add(A[j], 1);
                        }
                        else
                        {
                            second[A[j]]++;
                        }
                    }
                }
                if (second.Count > 0)
                {
                    secondTop = second.OrderByDescending(pair => pair.Value).Take(1).First().Value;
                }

                if (secondTop > second.Count / 2 || i == n - 1)
                {
                    if (firstTop == secondTop)
                    {
                        if (!result.ContainsKey(firstTop))
                        {
                            result.Add(firstTop, 1);
                        }
                        else
                        {
                            result[firstTop]++;
                        }
                    }
                }
            }

            if (result.Count > 0)
            {
                return result.OrderByDescending(pair => pair.Value).Take(1).First().Value;
            }

            return -1;
        }
    }
}
