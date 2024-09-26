﻿using BCrypt.Net;
using System.Security.Cryptography;
using System.Text;

namespace SoftwareTest_and_Security.Code
{
    public class HashingHandler
    {
        //Deprication planned by 2030, DO NOT USE!
        public string MD5Hashing(string textToHash)
        {
            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            MD5 md5 = MD5.Create();
            byte[] hashedValue = md5.ComputeHash(inputByte);

            return Convert.ToBase64String(hashedValue);
        }

        public string SHA256Hashing(string textToHash)
        {
            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            SHA256 sha256 = SHA256.Create();
            byte[] hashedValue = sha256.ComputeHash(inputByte);

            return Convert.ToBase64String(hashedValue);
        }

        public string HMACHashing(string textToHash)
        {
            byte[] myKey = Encoding.ASCII.GetBytes("NielsErMinFavoritLære");
            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            HMACSHA256 hmacsha256 = new HMACSHA256();
            hmacsha256.Key = myKey;
            byte[] hashedValue = hmacsha256.ComputeHash(inputByte);

            return Convert.ToBase64String(hashedValue);
        }

        public string PBKDF2Hashing(string textToHash)
        {
            byte[] inputByte = Encoding.ASCII.GetBytes(textToHash);
            byte[] saltAsByteArray = Encoding.ASCII.GetBytes("SaltKanVæreHvadSomHelst");
            var hashAlgo = new System.Security.Cryptography.HashAlgorithmName("SHA256");
            byte[] hashedValue = System.Security.Cryptography.Rfc2898DeriveBytes.Pbkdf2(inputByte, saltAsByteArray, 11, hashAlgo, 32);

            return Convert.ToBase64String(hashedValue);
        }

        public string BCryptHashing(string textToHash)
        {
            //=> BCrypt.Net.BCrypt.HashPassword(textToHash);

            //int workFactor = 11;
            //string salt = BCrypt.Net.BCrypt.GenerateSalt();
            //bool enchancedEntropy = true;
            //return BCrypt.Net.BCrypt.HashPassword(textToHash, salt, enchancedEntropy);

            int workFactor = 11;
            string salt = BCrypt.Net.BCrypt.GenerateSalt();
            bool enchancedEntropy = true;
            HashType hashType = HashType.SHA256;
            return BCrypt.Net.BCrypt.HashPassword(textToHash, salt, enchancedEntropy, hashType);
        }

        public bool BCryptVerifyHashing(string textToHash, string hashedValueFromDb)
            //=> BCrypt.Net.BCrypt.Verify(textToHash, hashedValueFromDb);
            //=> BCrypt.Net.BCrypt.Verify(textToHash, hashedValueFromDb, true);
            => BCrypt.Net.BCrypt.Verify(textToHash, hashedValueFromDb, true, BCrypt.Net.HashType.SHA256);
    }
}
