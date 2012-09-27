using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindPasswordMD5HashExem
{
    public static class RangeCalculateForThreads
    {
        //private int threadCount;
        //private int passwdLength;
        //private PasswordOptions rangeOptions;
        

        //public RangeCalculateForThreads(int ThreadCount, int length, PasswordOptions Range)
        //{
        //    this.threadCount = ThreadCount;
        //    passwdLength = length;
        //    rangeOptions = Range;

        //}

        // If you can pass ThreadCount, passwdLength and _rangeOptions to this method directly 
        // this method could be made static and thread safe
        // you'll be able to delete constuctor and private fields in this case
        public static int[][] GetStartingPoints(int threadCount, int passwdLength, int range)//(int threadCount, int passwdLength, PasswordOptions rangeOptions)
        {
            //int range=0;
            //if ((rangeOptions & PasswordOptions.Capital) == PasswordOptions.Capital) range += 26;//65-90 A-Z
            //if ((rangeOptions & PasswordOptions.Lower) == PasswordOptions.Lower) range += 26; //97-122 a-z
            //if ((rangeOptions & PasswordOptions.Numbers) == PasswordOptions.Numbers) range += 10; //0-9
            //char[,] boundaries = new char[threadCount+1, passwdLength]; // ThreadCount+1 //startPoint better 'boundaries'

            int[][] boundaries=new int[threadCount+1][];
            
            long possibleCombinations=(long)Math.Pow(range, passwdLength); // variant == possibleCombinations
            long combinationsPerThread = possibleCombinations / threadCount;  // rangeForThread == combinationsPerThread

            // for i = 0 .. ThreadCount
            //  boundaries[i] = GetBoundary(threadNo, combinationsPerThread, possibleCombinations)
            for (int i=0; i<=threadCount; i++)
            {
                long combin = i != threadCount ? combinationsPerThread*i : possibleCombinations-1; 
                boundaries[i]=GetBoundary(passwdLength, combin, range);
            }
            return boundaries;
        }

        private static int[] GetBoundary(int passwdLength, long combinationsPerThread, int range)
        {
            int[] deltaChar = new int[passwdLength];
            int mydeltaChar = 0;
            for (int i = 0; i < passwdLength; i++)
            {
                mydeltaChar = (int) combinationsPerThread%range; //остаток от деления
                combinationsPerThread /= range;
                deltaChar[i] = mydeltaChar;
            }
            return deltaChar;
        }

     
    }
}
