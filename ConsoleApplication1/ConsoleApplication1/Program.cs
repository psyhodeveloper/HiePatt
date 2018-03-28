using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
namespace ConsoleApplication1
{
    class Program
    {       
        static void Main(string[] args)
        {
            string[] inputstring = { "2", "<><", "<>>>>", "2", "2", "2" };
            Console.WriteLine(GetSizeExpressionsArray(inputstring));
            Console.WriteLine(GetSizemaxReplacementsArray(inputstring));
            foreach(string s in GetExpressionsArray(inputstring))
            Console.WriteLine(s);
            foreach (int i in GetmaxReplacementsArray(inputstring))
            Console.WriteLine(i);
            Console.WriteLine("isbalnced:"+ isBalanced(inputstring[1]));
            Console.ReadLine();
        }
        static int GetSizeExpressionsArray(string[] input)
        {
            return Int32.Parse(input[0]);
        }
        static int GetSizemaxReplacementsArray(string[] input)
        {
            return Int32.Parse(input[GetSizeExpressionsArray(input)+1]);
        }
        static string[] GetExpressionsArray(string[] input)
        {
            string[] expressions = new string[GetSizeExpressionsArray(input)];
            for(int i=0;i<expressions.Length;i++)
                {
                expressions[i] = input[i + 1];
                }
            return expressions;
        }
        static int[] GetmaxReplacementsArray(string[] input)
        {
            int expresssizearray = GetSizeExpressionsArray(input);
            int maxReplacementssizearray=  Int32.Parse(input[expresssizearray + 1]);
            int[] maxReplacements = new int[maxReplacementssizearray];
            for(int i=0;i<maxReplacementssizearray;i++)
            {
                maxReplacements[i] = Int32.Parse( input[i + expresssizearray + 1]);
            }
            return maxReplacements;
        }
        //static int[] balancedOrNot(string[] expressions, int[] maxReplacements)
        //{
        //    bool isbalanced;
        //    int[] resultarray = new int[expressions.Length];
        //    if(expressions[0][0]!= expressions[0][1])
        //    {


        //    }
        //}
        static int StringCompare(string s)
        {
            int i=0;
            int result=0;
            foreach (char c in s)
            {
                if (c != s[i+1])
                    result++;
                if(i+2!=s.Length)
                    i++;         
            }
            return result;
        }
        static bool isBalanced(string s)
        {
            if (StringCompare(s)+1 == s.Length)
                return true;
            else
                return false;
        }
    }
}
