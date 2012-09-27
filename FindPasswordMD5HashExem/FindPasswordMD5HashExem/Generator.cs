using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
        private int _length;
        public string Password = "";

        public Generator(int length, PasswordOptions options, string md5) // StructureStringMd5 inputData
        {
            _options = options;
            _innerString = new char[length];
            _length = length;
            _md5 = md5;
        }

        //public StructureStringMd5 FindPassword()
        //{
        //    // password generation logic
           

        //    string Password=null;

        //    string _md5Conv=CalculateMd5.CalculateMd5Hash(Password);

        //    StructureStringMd5 result = new StructureStringMd5
        //                                 {
        //                                     Md5Byte = _md5Conv, 
        //                                     Password = String.Join("", _innerString)
        //                                 };
        //    if (VerifyMd5Hash(result))  
        //                return result;
        //    return null;

        //}

        public bool VerifyMd5Hash (string probe)
        {
            return CalculateMd5.CalculateMd5Hash(probe) == _md5;
            //return (System.String.Compare(result.Md5Byte, _md5)==0);
        }

        public bool GeneratePasswords (char[] probe, int depth)
        {
            bool result = false;
            string probeString = String.Join("", probe);

            if (depth==0)
            {
                if (VerifyMd5Hash(probeString))
                {
                    //new StructureStringMd5 {Md5Byte = _md5, Password = probeString};}
                    Password = probeString;
                    return true;
                }
                
                //Console.WriteLine(probeString);
                return false;
            }
                

            for (int i = 48; i <= 57; i++)
            {
                probe[depth-1]= Convert.ToChar(i);
                result = GeneratePasswords(probe, depth - 1);
                if (result) break;
            }
            return result;
            //char[] nextAttempt = lastPassword.Password.ToCharArray();

            //if ((_options & PasswordOptions.Capital) == PasswordOptions.Capital)
            //{

            //}

            //for (var i = 0; i < lastPassword.Password.Length; i++)
            //{
            //    nextAttempt[lastPassword.Password.Length-depth]=
            //}
            //return new StructureStringMd5()}
        }
    }



}
