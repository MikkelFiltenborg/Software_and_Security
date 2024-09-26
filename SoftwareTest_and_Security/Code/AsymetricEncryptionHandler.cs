using Newtonsoft.Json;
using System.Security.Cryptography;

namespace SoftwareTest_and_Security.Code
{
    public class AsymetricEncryptionHandler
    {
        private string _privateKey;
        private string _publicKey;
        private readonly HttpClient _httpClient;

        public AsymetricEncryptionHandler(HttpClient httpClient)
        {
            _httpClient = httpClient;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                if (File.Exists("privateKey.txt") && File.Exists("publicKey.txt"))
                {
                    _privateKey = File.ReadAllText("privateKey.txt");
                    _publicKey = File.ReadAllText("publicKey.txt");
                }
                else
                {
                    _privateKey = rsa.ToXmlString(true);
                    _publicKey = rsa.ToXmlString(false);

                    File.WriteAllText("privateKey.txt", _privateKey);
                    File.WriteAllText("publicKey.txt", _publicKey);
                }
            }
        }

        //public async Task<string> AsymetricEncrypt(string textToEncrypt)
        //{
        //    string[] param = new string[] { textToEncrypt, _publicKey };
        //    string serializeObject = JsonConvert.SerializeObject(param);
        //    StringContent sc = new StringContent(serializeObject, System.Text.Encoding.UTF8, "application/json");

        //    var encryptedValue = await _httpClient.PostAsync("https://localhost:7007/api/Encrypter", sc);
        //    string encryptedValueAsString = encryptedValue.Content.ReadAsStringAsync().Result;
        //    return encryptedValueAsString;
        //}

        public async Task<string> AsymetricEncrypt(string textToEncrypt)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(_publicKey);

                byte[] byteArrayTextToEncrypt = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                byte[] encryptedDataAsByteArray = rsa.Encrypt(byteArrayTextToEncrypt, true);
                var encryptedDataAsString = Convert.ToBase64String(encryptedDataAsByteArray);

                return encryptedDataAsString;
            }
        }

        public string AsymetricDecrypt(string textToDecrypt)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(_privateKey);

                byte[] byteArrayTextToDecrypt = Convert.FromBase64String(textToDecrypt);
                byte[] decryptValue = rsa.Decrypt(byteArrayTextToDecrypt, true);
                string decryptValueAsString = System.Text.Encoding.UTF8.GetString(decryptValue);

                return decryptValueAsString;
            }
        }
    }
}
