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
        //private StructureStringMd5 _inputData;
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

        //loop for GeneratePasswords
        // this thread cracker should receive delegate as an argument to let the application know that the search is finished.
        // and it should return a CancellationTokenSource - your token variable
        public CancellationTokenSource ThreadCracker(Action<string> sendPassword)
        {
            int range = GetRange();
            int [][]boundaries=RangeCalculateForThreads.GetStartingPoints(_threadCount, _passwdLength, range);
            var tokenSource = new CancellationTokenSource();
            var token = tokenSource.Token;

            // as you are passing cancelation token to each task, you don't need to store them in a list
            //List<Task> tasks = new List<Task>();

            for (int i=0; i<_threadCount; i++)
            {
                int[] startBoundary = boundaries[i];
                int[] endBoundary = boundaries[i + 1];
                // depth? 
                // if (GeneratePasswords(startBoundary, endBoundary, _passwdLength, range)) break;
                // it would be much better to pass a delegate to GeneratePasswords method
                // when the password is found, GeneratePasswords method will call the delegate and pass valid password as an argument
                // as ThreadCracker method returns a CancelationToken, it will be stored somewhere and when the password is received by delegate
                // it will call Cancel() method of your cancelation token source. All the tasks would be canceled. 
                // no complex logic
                Task task=Task.Factory.StartNew(() => GeneratePasswords(startBoundary, endBoundary, _passwdLength, range, token, tokenSource, sendPassword), token);

            }
            // no need to do anything here
            // let the scheduler do its work with the tasks


            
            return tokenSource;
            //try
            //{
            //    //wait all task complete 
            //    //???
            //}
            //catch (AggregateException e)
            //{
            //    for (int i=0; i<tasks.ToArray().Length; i++)
            //    {
            //        tasks[i].Dispose(); ///??????
            //    }
            //}

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


        public bool GeneratePasswords(int[] probe, int[] endBoundary, int depth, int range, CancellationToken ct, CancellationTokenSource tokenSource, Action<string> sendPassword) //probe==StartBounder
        {
            bool result = false;
            char[] probeChar = CharForThread(probe, _options);
            
            string probeString = String.Join("", probeChar);

            if (depth==0)
            {
                if (VerifyMd5Hash(probeString))
                {
                    Password = probeString;
                    sendPassword(Password); //???? 
                   // tokenSource.Cancel(); //тут не надо????
                    return true;
                }
                return false;
            }
            if (ct.IsCancellationRequested)
            {
                ct.ThrowIfCancellationRequested();
            }

            if (probe != endBoundary)
            {
                for (int i = 0; i <= range; i++)
                {
                    probe[depth - 1] = i;
                    result = GeneratePasswords(probe, endBoundary, depth - 1, range, ct, tokenSource, sendPassword);
                    if (result) break;
                }
                return result;
            }
            
            return false;
        }


        private static char[] CharForThread(int[] deltaChar, PasswordOptions rangeOptions)
        {
            char[] charForThread = new char[deltaChar.Length];
            if ((rangeOptions & PasswordOptions.Capital) == PasswordOptions.Capital && (rangeOptions & PasswordOptions.Lower) == PasswordOptions.Lower && (rangeOptions & PasswordOptions.Numbers) == PasswordOptions.Numbers)
            {
                for (int i = 0; i < deltaChar.Length; i++)
                {
                    int symbolValue = 65 + deltaChar[i];
                    if (symbolValue <= 90) charForThread[i] = (char)symbolValue;
                    else if ((deltaChar[i] - 26) <= 26) charForThread[i] = (char)(deltaChar[i] - 26 + 97);
                    else charForThread[i] = (char)(deltaChar[i] - 52);
                }
                return charForThread;
            }

            if ((rangeOptions & PasswordOptions.Capital) == PasswordOptions.Capital && (rangeOptions & PasswordOptions.Lower) == PasswordOptions.Lower)
            {
                for (int i = 0; i < deltaChar.Length; i++)
                {
                    int symbolValue = 65 + deltaChar[i];
                    if (symbolValue <= 90) charForThread[i] = (char)symbolValue;
                    else charForThread[i] = (char)(deltaChar[i] - 26 + 97);

                }
                return charForThread;
            }

            if ((rangeOptions & PasswordOptions.Capital) == PasswordOptions.Capital && (rangeOptions & PasswordOptions.Numbers) == PasswordOptions.Numbers)
            {
                for (int i = 0; i < deltaChar.Length; i++)
                {
                    int symbolValue = 65 + deltaChar[i];
                    if (symbolValue <= 90) charForThread[i] = (char)symbolValue;
                    else charForThread[i] = (char)(deltaChar[i] - 26);

                }
                return charForThread;
            }

            if ((rangeOptions & PasswordOptions.Lower) == PasswordOptions.Lower && (rangeOptions & PasswordOptions.Numbers) == PasswordOptions.Numbers)
            {
                for (int i = 0; i < deltaChar.Length; i++)
                {
                    int symbolValue = 97 + deltaChar[i];
                    if (symbolValue <= 122) charForThread[i] = (char)symbolValue;
                    else charForThread[i] = (char)(deltaChar[i] - 26);
                }
                return charForThread;
            }


            if ((rangeOptions & PasswordOptions.Capital) == PasswordOptions.Capital)
            {
                for (int i = 0; i < deltaChar.Length; i++)
                {
                    charForThread[i] = (char)(65 + deltaChar[i]);
                }
                return charForThread;
            }
            if ((rangeOptions & PasswordOptions.Lower) == PasswordOptions.Lower)
            {
                for (int i = 0; i < deltaChar.Length; i++)
                {
                    charForThread[i] = (char)(97 + deltaChar[i]);
                }
                return charForThread;
            }
            if ((rangeOptions & PasswordOptions.Numbers) == PasswordOptions.Numbers)
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
