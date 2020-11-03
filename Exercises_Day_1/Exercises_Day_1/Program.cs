using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercises_Day_1
{
    class Program
    {
        // Complexity: O(n)
        static int MinFromArray(int[] v, int n)
        {
            int min = v[0];
            for (int i = 1; i < n; i++)
            {
                if (v[i] < min)
                {
                    min = v[i];
                }
            }
            return min;
        }

        // Complexity: O(1)
        static int SumFirstN(int n)
        {
            return (n * (n + 1)) / 2;
        }

        // Complexity: O(nlog(n))
        static void Merge(int[] v, int l, int m, int r)
        {
            int l1 = m - l + 1;
            int l2 = r - m;

            int[] L = new int[l1];
            int[] R = new int[l2];

            int i = 0, j = 0;
            for (i = 0; i < l1; i++)
                L[i] = v[l + i];
            for (j = 0; j < l2; j++)
                R[j] = v[m + 1 + j];

            i = 0; j = 0;
            int k = l;
            while (i < l1 && j < l2)
            {
                if (L[i] <= R[j])
                {
                    v[k] = L[i];
                    i++;
                } else
                {
                    v[k] = R[j];
                    j++;
                }
                k++;
            }
            while (i < l1)
            {
                v[k] = L[i];
                i++;
                k++;
            }
            while (j < l2)
            {
                v[k] = R[j];
                j++;
                k++;
            }
        }
        static void MergeSort(int[] v, int l, int r)
        {
            if (l < r)
            {
                int m = l + (r - l) / 2;

                MergeSort(v, l, m);
                MergeSort(v, m + 1, r);

                Merge(v, l, m, r);
            }
        }

        // Complexity O(nlog(n))
        static int BinarySearch(int[] v, int l, int r, int x)
        {
            if (l <= r)
            {
                int m = l + (r - l) / 2;
                if (v[m] == x)
                {
                    while (m != 0 && v[m - 1] == x) m--;
                    return m;
                }
                else if (v[m] < x)
                {
                    return BinarySearch(v, m + 1, r, x);
                }
                else
                {
                    return BinarySearch(v, l, m - 1, x);
                }
                
            }
            return -1;
        }

        // Complexity: O(log n)
        static int GCD(int a, int b)
        {
            return a == 0 ? b : GCD(b % a, a);
        }
        static void Main(string[] args)
        {
            int[] v = new int[] { 2, 3, 1, 3, 9, 2, 13, 2, 1, 5 };
            MergeSort(v, 0, v.Length - 1);
            int poz = BinarySearch(v, 0, v.Length - 1, 2);
            int gcd = GCD(24, 36);
            for (int i = 0; i < v.Length; i++)
            {
                Console.Write(v[i] + " ");
            }
            Console.WriteLine(poz);
            Console.WriteLine(gcd);
            Console.ReadKey();
        }
    }
}
