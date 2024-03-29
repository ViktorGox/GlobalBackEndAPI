using GlobalBackEndAPI.EncryptionHandling;
using System.Security.Cryptography;
using System.Text;

namespace GlobalBackEndAPI.Encryption
{
    public class BasicEncryption : IEncryption
    {
        private static readonly string _key;
        static BasicEncryption()
        {
            _key = KeySetUp.GetKey();
        }
        public string Decrypt(string toDecrypt)
        {
            byte[] combinedBytes = Convert.FromBase64String(toDecrypt);
            byte[] iv = new byte[16];

            Array.Copy(combinedBytes, 0, iv, 0, iv.Length);

            byte[] cipherText = new byte[combinedBytes.Length - iv.Length];
            Array.Copy(combinedBytes, iv.Length, cipherText, 0, cipherText.Length);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_key);
                aesAlg.IV = iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        public string Encrypt(string toEncrypt)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(_key);
                aesAlg.GenerateIV();
                byte[] iv = aesAlg.IV;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, iv);
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(toEncrypt);
                        }
                    }
                    // Concatenate IV with ciphertext and return base64 string
                    byte[] encryptedBytes = msEncrypt.ToArray();
                    byte[] combinedBytes = new byte[iv.Length + encryptedBytes.Length];
                    Array.Copy(iv, 0, combinedBytes, 0, iv.Length);
                    Array.Copy(encryptedBytes, 0, combinedBytes, iv.Length, encryptedBytes.Length);
                    return Convert.ToBase64String(combinedBytes);
                }
            }
        }
    }
}
