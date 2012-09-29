using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FindPasswordMD5HashExem
{
    [Flags]
    public enum PasswordOptions
    {
        Capital = 1, Lower = 2, Numbers = 4
    }
    
    public class Generator
    {
        private char[] _innerString;
        private PasswordOptions _options;
        private string _md5;
        private int _passwdLength;
        private string Password = "";
        private int _threadCount;

        /// <summary>
        /// class RangealculateForThread public static int[][] GetStartingPoints (int threadCount, int passwdLength, PasswordOptions rangeOptions)
        /// </summary>

        public Generator(int passwdLength, PasswordOptions options, string md5, int threadCount) // StructureStringMd5 inputData
        {
            _options = options;
            _innerString = new char[passwdLength];
            _passwdLength = passwdLength;
            _md5 = md5;
            _threadCount = threadCount;
        }

        public CancellationTokenSource ThreadCracker(Action<string> sendPassword)
        {
            int range = GetRange();
            int [][]boundaries=RangeCalculateForThreads.GetStartingPoints(_threadCount, _passwdLength, range);
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            for (int i=0; i<_threadCount; i++)
            {
                int[] startBoundary = boundaries[i];
                int[] endBoundary = boundaries[i + 1];

                int[] probe = (int[])startBoundary.Clone();
                Task task=Task.Factory.StartNew(() => GeneratePasswords(probe, startBoundary,endBoundary, _passwdLength, range, token, tokenSource, sendPassword), token);

                //GeneratePasswords(probe, startBoundary, endBoundary, _passwdLength, range, token, tokenSource,
                //                  sendPassword);

            }
            return tokenSource;
        }

        private int GetRange()
        {
            int range = 0;
            if ((_options & PasswordOptions.Capital) == PasswordOptions.Capital) range += 26;//65-90 A-Z
            if ((_options & PasswordOptions.Lower) == PasswordOptions.Lower) range += 26; //97-122 a-z
            if ((_options & PasswordOptions.Numbers) == PasswordOptions.Numbers) range += 10; //0-9
            return range;
        }

        public bool VerifyMd5Hash (string probe)
        {
            return CalculateMd5.CalculateMd5Hash(probe) == _md5;
        }


        public bool GeneratePasswords(int[] probe, int[] startBoundary, int[] endBoundary, int depth, int range, CancellationToken ct, CancellationTokenSource tokenSource, Action<string> sendPassword) //probe==StartBounder
        {
            bool result = false;
            char[] probeChar = CharForThread(probe, _options);
            
            string probeString = String.Join("", probeChar);

            if (depth==0)
            {
                Console.WriteLine(probeString);
                if (VerifyMd5Hash(probeString))
                {
                    Password = probeString;
                    sendPassword(Password); 
                    return true;
                }
                return false;
            }
            if (ct.IsCancellationRequested)
            {
                Console.WriteLine("Task is canceled");
            }


            if (probe.SequenceEqual(endBoundary)) return false;

            for (int i = 0; i < range; i++)
                {
                    probe[depth - 1] = i;
                    result = GeneratePasswords(probe, startBoundary, endBoundary, depth - 1, range, ct, tokenSource, sendPassword);
                    if (result) break;
                }
                return result;
           
        }


        private static char[] CharForThread(int[] deltaChar, PasswordOptions rangeOptions)
        {
            char[] charForThread = new char[deltaChar.Length];
            bool capitals = (rangeOptions & PasswordOptions.Capital) == PasswordOptions.Capital;
            bool lower = (rangeOptions & PasswordOptions.Lower) == PasswordOptions.Lower;
            bool numbers = (rangeOptions & PasswordOptions.Numbers) == PasswordOptions.Numbers;

            List<Tuple<int, int>> ranges = new List<Tuple<int, int>>();
            if (numbers) ranges.Add(new Tuple<int, int>(48, 58));
            if (capitals) ranges.Add(new Tuple<int, int>(65, 91));
            if (lower) ranges.Add(new Tuple<int, int>(97, 123));

            for (int i = 0; i < deltaChar.Length; i++)
            {
                int currentChar = deltaChar[i];
                charForThread[i] = ConvertToChar(ranges, currentChar);
            }

            return charForThread;
        }

        private static char ConvertToChar(List<Tuple<int, int>> ranges, int currentChar)
        {
            foreach (var range in ranges)
            {
                int rangeLength = range.Item2 - range.Item1;
                if (currentChar < rangeLength) return (char) (range.Item1 + currentChar);
                currentChar -= rangeLength;
            }
            throw new Exception("Character not found");
        }
    }



}
