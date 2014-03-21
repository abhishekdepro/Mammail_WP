using System;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mammmail_WP8
{

    public class Encryption
    {
        public static int  logged_in=0;
        public static string encrypt(string s)
        {
            char[] input = s.ToCharArray(); /*converts string to character array*/

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] % 2 == 0)
                {
                    input[i] += Convert.ToChar(1);
                }
                else
                {
                    input[i] -= Convert.ToChar(1);
                }
            }
            string encrypted_string = new string(input);
            return encrypted_string;
        }

        
    }
}
