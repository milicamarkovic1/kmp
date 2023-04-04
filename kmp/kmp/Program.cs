using System;

namespace kmp
{
    class Program
    {
        void pretraga(string pat, string txt)
        {
            int n = pat.Length;
            int m = txt.Length;
            int[] lps = new int[n];
            racunaj(pat, n, lps);
            int i = 0;
            int j = 0;
            while ((m-j)>=(n-i))
            {
                if (pat[i] == txt[j])
                {
                    i++;
                    j++;
                }
                if (i == n)
                {
                    Console.WriteLine(j - i);
                    i = lps[i - 1];
                }
                else if (j < m && pat[i] != txt[j])
                {
                    if (i != 0) i = lps[i - 1];
                    else j++;
                }
            }
        }
        void racunaj(string pat, int n, int[] lps)
        {
            int len = 0;
            int i = 1;
            lps[0] = 0;
            while (i < n)
            {
                if (pat[i] == pat[len])
                {
                    len++;
                    lps[i] = len;
                    i++;
                }
                else
                {
                    if (len != 0) len = lps[len - 1];
                    else
                    {
                        lps[i] = len;
                        i++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            /*
            char[] Pat = new char[30];
            int[] LPS = new int[30];
            string ulaz = Console.ReadLine();
            Pat = ulaz.ToCharArray();
            int n = ulaz.Length;
            int len = 0;
            LPS[0] = 0;
            int i = 1;
            while (i < n)
            {
                if (Pat[i] == Pat[len])
                {
                    //LPS[i++] = ++len;
                    len++;
                    LPS[i] = len;
                    i++;
                }
                else if (len > 0) len = LPS[len - 1];
                else
                {
                    LPS[i] = 0;
                    i++;
                }
            }
            for (int j = 0; j < n; j++) Console.WriteLine(LPS[j]);
            Console.ReadKey();
            */
            string pat = Console.ReadLine();
            string txt = Console.ReadLine();
            new Program().pretraga(txt, pat);
        }
    }
}
