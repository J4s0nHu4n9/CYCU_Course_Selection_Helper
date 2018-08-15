using System.Text;
using System.Security.Cryptography;

namespace CYCU_Course_Selection_Helper
{
    public class Crypto
    {
        public static string GetEncrypt(string pw, string id, string secureRandom)
        {
            var MD5Hash = CalculateMd5Hash(pw);
            var result = CalculateSHA256Hash(MD5Hash, id, secureRandom);
            return result;
        }

        private static string CalculateMd5Hash(string input)
        {
            var key = Encoding.UTF8.GetBytes(input);
            var hash = MD5.Create().ComputeHash(key);
            var sb = new StringBuilder();
            foreach (var b in hash)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }

        private static string CalculateSHA256Hash(string _key, string _msg1, string _msg2)
        {
            var key = Encoding.UTF8.GetBytes(_key);
            var msg1 = Encoding.UTF8.GetBytes(_msg1);
            var msg2 = Encoding.UTF8.GetBytes(_msg2);

            var hmac = new HMACSHA256(key);
            hmac.TransformBlock(msg1, 0, msg1.Length, null, 0);
            hmac.TransformFinalBlock(msg2, 0, msg2.Length);

            var sb = new StringBuilder();
            foreach (var b in hmac.Hash)
                sb.Append(b.ToString("x2"));
            return sb.ToString();
        }
    }
}
