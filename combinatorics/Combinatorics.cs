using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace combinatorics
{
    static class Combinatorics
    {
        public static int Permutations(int n)
        {
            int number = 1;
            for (int i = 1; i < n + 1; i++)
            {
                number *= i;
            }
            return number;
        }
        public static int Permutation_WithRep(int n, int[] k)
        {
            int fakt = Permutations(k[0]);
            for (int i = 1; i < k.Length; i++)
            {
                fakt *= Permutations(k[i]);
            }
            return Permutations(n) / fakt;
        }
        public static int Variations(int n, int k)
        {
            return Permutations(n) / Permutations(n - k);
        }
        public static int Variations_WithRep(int n, int k)
        {
            double n1 = n;
            double k1 = k;
            return Convert.ToInt32(Math.Pow(n1, k1));
        }
        public static int Combinations(int n, int k)
        {
            return Permutations(n) / (Permutations(k) * Permutations(n - k));
        }
        public static int Combinations_WithRep(int n, int k)
        {
            int j = n + k - 1;
            return Permutations(j) / (Permutations(k) * Permutations(j - k));
        }
    }
}
