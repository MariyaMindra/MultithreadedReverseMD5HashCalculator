using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindPasswordMD5HashExem
{
    public static class RangeCalculateForThreads
    {
        public static int[][] GetStartingPoints(int threadCount, int passwdLength, int range)//(int threadCount, int passwdLength, PasswordOptions rangeOptions)
        {
            int[][] boundaries=new int[threadCount+1][];
            
            long possibleCombinations=(long)Math.Pow(range, passwdLength); 
            long combinationsPerThread = possibleCombinations / threadCount;  

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
                deltaChar[passwdLength-i-1] = mydeltaChar;
            }
            return deltaChar;
        }

     
    }
}
