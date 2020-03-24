using System.Security.Cryptography;
using System.Text;

namespace CYCU_Course_Selection_Helper.Models
{
    public static class Crypto
    {
        public static string GetEncrypt(string pw, string id, string secureRandom)
        {
            string md5Hash = CalculateMd5Hash(pw);
            string result = CalculateSha256Hash(md5Hash, id, secureRandom);
            return result;
        }

        private static string CalculateMd5Hash(string input)
        {
            byte[] key = Encoding.UTF8.GetBytes(input);
            byte[] hash = MD5.Create().ComputeHash(key);
            StringBuilder sb = new StringBuilder();
            foreach (var b in hash)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        private static string CalculateSha256Hash(string key, string msg1, string msg2)
        {
            byte[] encodedKey = Encoding.UTF8.GetBytes(key);
            byte[] encodedMsg1 = Encoding.UTF8.GetBytes(msg1);
            byte[] encodedMsg2 = Encoding.UTF8.GetBytes(msg2);

            HMACSHA256 hmac = new HMACSHA256(encodedKey);
            hmac.TransformBlock(encodedMsg1, 0, encodedMsg1.Length, null, 0);
            hmac.TransformFinalBlock(encodedMsg2, 0, encodedMsg2.Length);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hmac.Hash)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }
}
