using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankChalenges
{
    public static class CommonChild
    {

        public static int FindCommonChildSize(String s1, String s2)
        {
            /*
             
            function LCSLength(X[1..m], Y[1..n])
            C = array(0..m, 0..n)
            for i := 0..m
                C[i,0] = 0
            for j := 0..n
                C[0,j] = 0
            for i := 1..m
                for j := 1..n
                    if X[i] = Y[j]
                        C[i,j] := C[i-1,j-1] + 1
                    else
                        C[i,j] := max(C[i,j-1], C[i-1,j])
            return C[m,n]
             
              S H I N C H A N
            N 0 0 0 1 0 0 0 1
            O 0 0 0 0 0 0 0 0 
            H 0 1 0 0 0 2 0 0
            A 0 0 0 0 0 0 3 0
            R 0 0 0 0 0 0 0 0
            A 0 0 0 0 0 0 1 0
            A 0 0 0 0 0 0 1 0
            A 0 0 0 0 0 0 1 0
                
                    N   O   H   A   R   A   A   A
              	0	0	0	0	0	0	0	0	0
	          S 0	0	0	0	0	0	0	0	0
	          H 0	0	0	1	1	1	1	1	1
	          I 0	0	0	1	1	1	1	1	1
	          N 0	1	1	1	1	1	1	1	1
	          C 0	1	1	1	1	1	1	1	1
	          H 0	1	1	2	2	2	2	2	2
	          A 0	1	1	2	3	3	3	3	3
	          N 0	1	1	2	3	3	3	3	3
            
            
            F(N,SHINCAHAN)= 1+F(OHARAAA,CHAN)  OR 1+ F(OHORAAA,'')

            F(OHORAAA, CHAN

           AA=> 
             */

            LcsLength(s1, s2);
            return -1;
           

        }
        static int[,] LcsLength(string a, string b)
        {
            int[,] C = new int[a.Length + 1, b.Length + 1]; // (a, b).Length + 1
            for (int i = 0; i < a.Length; i++)
                C[i, 0] = 0;
            for (int j = 0; j < b.Length; j++)
                C[0, j] = 0;
            for (int i = 1; i <= a.Length; i++)
                for (int j = 1; j <= b.Length; j++)
                {
                    if (a[i - 1] == b[j - 1])//i-1,j-1
                        C[i, j] = C[i - 1, j - 1] + 1;
                    else
                        C[i, j] = Math.Max(C[i, j - 1], C[i - 1, j]);
                }

            PrintArray(C);

            return C;

        }

        private static void PrintArray(int[,] c)
        {
            Trace.WriteLine("PrintArray");
            int cCount = c.GetLength(0);
            int rCount = c.GetLength(1);
            for (int i = 0; i < cCount; i++)
            {
                for (int j = 0; j < rCount; j++)
                {
                    Trace.Write("\t"+c[i, j].ToString());
                    
                }
                Trace.WriteLine("");
            }
        }
    }
}
