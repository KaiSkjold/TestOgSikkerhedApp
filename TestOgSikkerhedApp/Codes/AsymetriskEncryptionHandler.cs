namespace TestOgSikkerhedApp.Codes;

using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;

public class AsymetriskEncryptionHandler
{

    // In use with seperate web API project as proof of concept.

    // needs to be read from private file
    private string _privateEncryptionKey;
    // public key is the one you send to other people
    private string _publicEncryptionKey;
    private readonly HttpClient _httpClient;

    public AsymetriskEncryptionHandler(HttpClient httpClient)
    {
        _httpClient = httpClient;

        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            // make key in xml format, true means private key and false means a public key

            //Check if private key exists else create
            if(File.Exists("private.pem"))
            {
                _privateEncryptionKey = File.ReadAllText("private.pem");

            } else
            {
                _privateEncryptionKey = rsa.ToXmlString(true);

                string filePathPrivate = "private.pem";
                File.WriteAllText(filePathPrivate, _privateEncryptionKey);
            }

            //Check if public key exists else create
            if (File.Exists("public.pem"))
            {
                _publicEncryptionKey = File.ReadAllText("public.pem");
            }
            else
            {
                _publicEncryptionKey = rsa.ToXmlString(false);

                string filePathPublic = "public.pem";
                File.WriteAllText(filePathPublic, _publicEncryptionKey);
            }

        }

    }

    // PROOF OF CONCEPT

    //public async Task<string> AsymetricEncrypt(string textToEncrypt)
    //{
    //    string[] param = new string[] { textToEncrypt, _publicEncryptionKey };
    //    string serializeObject = JsonConvert.SerializeObject(param);
    //    StringContent sc = new StringContent(serializeObject, Encoding.UTF8, "application/json");

    //    var encryptedValue = await _httpClient.PostAsync("https://localhost:7177/api/Encrypter", sc);
    //    encryptedValue.EnsureSuccessStatusCode();

    //    string encryptedValueString = encryptedValue.Content.ReadAsStringAsync().Result;

    //    return encryptedValueString;
    //}

    public async Task<string> AsymetricEncrypt(string textToEncrypt)
    {

        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(_publicEncryptionKey);

            byte[] byteToArrayEncrypt = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
            byte[] encryptedDataAsByteArray = rsa.Encrypt(byteToArrayEncrypt, true);

            string encryptedDataString = Convert.ToBase64String(encryptedDataAsByteArray);

            return encryptedDataString;
        }
    }

    public string AsymetricDescrypt(string textToDecrypt)
    {
        using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
        {
            rsa.FromXmlString(_privateEncryptionKey);

            byte[] byteArrayTextToDecrypt = Convert.FromBase64String(textToDecrypt);
            byte[] decryptValue = rsa.Decrypt(byteArrayTextToDecrypt, true);
            string decryptValueString = UTF8Encoding.UTF8.GetString(decryptValue);

            return decryptValueString;
        }
    }
}
