using System.Security.Cryptography;
using System.Text;
using BCrypt;
using BCrypt.Net;

namespace TestOgSikkerhedApp.Codes;

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

    // special hashing way for messages or text or documents - USE for Todo Items?
    public string HMACHashing(string textToHash)
    {
        byte[] myKey = Encoding.ASCII.GetBytes("myKeyExample");
        byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);

        HMACSHA256 hmacsha256 = new HMACSHA256();
        hmacsha256.Key = myKey;

        byte[] hashedValue = hmacsha256.ComputeHash(inputByte);

        return Convert.ToBase64String(hashedValue);
    }

    // special hashing way for??? almost same as HMAC, no automatic implementation
    public string PBKDF2Hashing(string textToHash)
    {
        
        byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
        byte[] saltAsByteArray = Encoding.ASCII.GetBytes("Salt");

        var hashAl = new System.Security.Cryptography.HashAlgorithmName("SHA256");

        // Below, do eleven times and 32 bits
        var hashedValue = System.Security.Cryptography.Rfc2898DeriveBytes.Pbkdf2(inputByte, saltAsByteArray, 11, hashAl, 32);

        return Convert.ToBase64String(hashedValue);
    }

    // special hashing way with nuget p and automatic implemntation, used on crossplatform, used for automatic hashing of passwords by Idenity - very safe
    // Cannot compare hashed strings
    public string BCryptHashing(string textToHash)
    {
        // TYPE 1
        //return BCrypt.Net.BCrypt.HashPassword(textToHash);

        // TYPE 2
        //int workFactor = 11;
        //string salt = BCrypt.Net.BCrypt.GenerateSalt();
        //bool enhancedEntropy = true;
        //return BCrypt.Net.BCrypt.HashPassword(textToHash, salt, enhancedEntropy);

        // TYPE 3
        int workFactor = 11;
        string salt = BCrypt.Net.BCrypt.GenerateSalt();
        bool enhancedEntropy = true;
        HashType hashType = HashType.SHA256;
        return BCrypt.Net.BCrypt.HashPassword(textToHash, salt, enhancedEntropy, hashType);

    }

    public bool BCryptVerificationHasher(string textToHash, string hashedValueFromDb)
    {
        // TYPE 1
        //return BCrypt.Net.BCrypt.Verify(textToHash, hashedValueFromDb);

        // TYPE 2
        //return BCrypt.Net.BCrypt.Verify(textToHash, hashedValueFromDb, true);

        // TYPE 3
        return BCrypt.Net.BCrypt.Verify(textToHash, hashedValueFromDb, true, BCrypt.Net.HashType.SHA256);
    }

}