using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FindPasswordMD5HashExem
{
    class RangeCalculateForThreads
    {
        private int _threadCount;
        private int _passwdLength;
        private PasswordOptions _rangeOptions;
        

        public RangeCalculateForThreads(int ThreadCount, int length, PasswordOptions Range)
        {
            _threadCount = ThreadCount;
            _passwdLength = length;
            _rangeOptions = Range;

        }

        // If you can pass _threadCount, _passwdLength and _rangeOptions to this method directly 
        // this method could be made static and thread safe
        // you'll be able to delete constuctor and private fields in this case
        public char[,] GetStartingPoints ()
        {
            int range=0;
            if ((_rangeOptions & PasswordOptions.Capital) == PasswordOptions.Capital) range += 26;//65-90 A-Z
            if ((_rangeOptions & PasswordOptions.Lower) == PasswordOptions.Lower) range += 26; //97-122 a-z
            if ((_rangeOptions & PasswordOptions.Numbers) == PasswordOptions.Numbers) range += 10; //0-9
            char[,] startPoint = new char[_threadCount, _passwdLength]; // _threadCount+1 //startPoint better 'boundaries'

            long variant=(long)Math.Pow(range, _passwdLength); // variant == possibleCombinations
            long rangeForThread = variant / _threadCount;  // rangeForThread == combinationsPerThread

            // for i = 0 .. _threadCount
            //  boundaries[i] = GetBoundary(threadNo, combinationsPerThread, possibleCombinations)

            // this code should be moved to GetBoundary static method
            int [] deltaChar=new int[_passwdLength];
            int mydeltaChar = 0;
            for (int i=0; i<_passwdLength; i++)
            {
                mydeltaChar=(int)rangeForThread%range; //остаток от деления
                rangeForThread/=range;
                deltaChar[i] = mydeltaChar;
            }

            



            return startPoint;

        }

        public char[] CharForThread(int[] deltaChar)
        {
            char[] charForThread=new char[deltaChar.Length];
            if ((_rangeOptions & PasswordOptions.Capital) == PasswordOptions.Capital && (_rangeOptions & PasswordOptions.Lower) == PasswordOptions.Lower && (_rangeOptions & PasswordOptions.Numbers) == PasswordOptions.Numbers)
            {
                for (int i = 0; i < deltaChar.Length; i++)
                {
                     int symbolValue= 65 + deltaChar[i];
                     if (symbolValue <= 90) charForThread[i] = (char)symbolValue; 
                     else if ((deltaChar[i] - 26) <= 26) charForThread[i] = (char)(deltaChar[i]-26+97);
                     else charForThread[i] = (char)(deltaChar[i] - 52);
                }
                return charForThread;

            }

            if ((_rangeOptions & PasswordOptions.Capital) == PasswordOptions.Capital)
             {
                 for (int i=0; i<deltaChar.Length; i++)
                 {
                     charForThread[i] = (char) (65 + deltaChar[i]);
                 }
                 return charForThread;
             }
            if ((_rangeOptions & PasswordOptions.Lower) == PasswordOptions.Lower)
            {
                for (int i = 0; i < deltaChar.Length; i++)
                {
                    charForThread[i] = (char)(97 + deltaChar[i]);
                }
                return charForThread;
            }
            if ((_rangeOptions & PasswordOptions.Numbers) == PasswordOptions.Numbers)
            {
                 for (int i = 0; i < deltaChar.Length; i++)
                {
                    charForThread[i] = (char)(48 + deltaChar[i]);
                }
                return charForThread;
            }
            
            return charForThread;

        }
    }
}
