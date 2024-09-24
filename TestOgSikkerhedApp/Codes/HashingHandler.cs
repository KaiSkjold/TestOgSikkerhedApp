using System.Security.Cryptography;
using System.Text;

namespace TestOgSikkerhedApp.Codes
{
    public class HashingHandler
    {
        // MD5 is now very easy to bruteforce, so it will soon be deprecated. DONT CHOOSE MD5
        public string MD5Hashing(string textToHash)
        {
            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            MD5 md5 = MD5.Create();
            byte[] hashedValue = md5.ComputeHash(inputByte);

            return Convert.ToBase64String(hashedValue);
        }

        // SHA256 is most commenly used now
        public string SHA256Hashing(string textToHash)
        {
            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            SHA256 sha256 = SHA256.Create();
            byte[] hashedValue = sha256.ComputeHash(inputByte);

            return Convert.ToBase64String(hashedValue);
        }
    }
}
