using Amazon.DynamoDBv2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode.DAL
{
    public static class clsCrypto
    {
        static string testString = "WNCYnTYPCEHb0gmjXA/1VQ==";
        static string hex = ConvertStringToHex(testString, System.Text.Encoding.Unicode);
        static string normal = ConvertHexToString(hex, System.Text.Encoding.Unicode);


        public static string GetMasterPassword(string appName)
        {
            string name = "admin" + appName + 123;

            return name;

        }
        public static string ConvertStringToHex(string input, Encoding encoding)
        {
            Byte[] stringBytes = encoding.GetBytes(input);
            StringBuilder sbBytes = new StringBuilder(stringBytes.Length * 2);
            foreach (byte b in stringBytes)
            {
                sbBytes.AppendFormat("{0:X2}", b);
            }
            return sbBytes.ToString();
        }

        public static string ConvertHexToString(String hexInput, System.Text.Encoding encoding)
        {
            int numberChars = hexInput.Length;
            byte[] bytes = new byte[numberChars / 2];
            for (int i = 0; i < numberChars; i += 2)
            {
                bytes[i / 2] = Convert.ToByte(hexInput.Substring(i, 2), 16);
            }
            return encoding.GetString(bytes);
        }
        public static string test(ScanResponse scanResponse)
        {
            try
            {

                Cryptography cryptography = new Cryptography();
                string master_password = GetMasterPassword("DMC");// scanResponse.Items[0]["request_details"].M["master_password"].S;
                byte[] hash1 = cryptography.GenerateSHA256String(master_password);
                var str = cryptography.GetStringFromHash(hash1);
                var result = cryptography.EncryptString(master_password, hash1, cryptography.GetSecretKey());

                byte[] hash21 = cryptography.GenerateSHA256String(result);
                var hash2 = cryptography.GetStringFromHash(hash21);
                var result22 = cryptography.EncryptString(result, hash21, cryptography.GetSecretKey());

                string hash = "dZPslZ3DWGjxq7KKoCoUaEe29PeLA9uLZGiKyjeskfo=";

                //"Jqk3DL418cMqqxCc8KUyRGh4Z+RGae0VgT/F0VET8dU=";//cryptography.GetStringFromHash(hash1);//scanResponse.Items[0]["request_details"].M["hash_password"].S;
                string result2 = cryptography.DecryptString(result22, cryptography.GetBytes(hash), cryptography.GetSecretKey());

                // "r4NBtAC9LeQfwmenfvtJaBDTgn//KnWiDT3V0+hkGVw=",


                var result3 = cryptography.DecryptString(result2, cryptography.GenerateSHA256String(result2), cryptography.GetSecretKey());

                //var result3 = cryptography.DecryptString(result2, cryptography.GetBytes(hash), cryptography.GetSecretKey());

                return result2;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
